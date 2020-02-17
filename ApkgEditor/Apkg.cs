using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Text.Json;
using Microsoft.Data.Sqlite;

namespace ApkgEditor
{
    public class MediaFile
    {
        private FileInfo file;
        private string _name;

        public FileInfo File { get => file;  }
        public string Name { get => _name;  }
        public string Id { get => file.Name; }
        public bool Exists { get => File.Exists; }
        /// <summary>
        /// 录入媒体文件映射，不检查文件存在
        /// </summary>
        /// <param name="id">文件在apkg里的编号</param>
        /// <param name="name">文件原来的名字</param>
        /// <param name="Folder">apkg文件夹</param>
        public MediaFile(int id, string name, string folder)
        {
            file = new FileInfo(Path.Combine(folder, id.ToString()));
            _name = name;
        }
        /// <summary>
        /// 改变媒体文件映射，不检查文件存在
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public void Set(int id, string name)
        {
            File.MoveTo(id.ToString());
            _name = name;
        }

    }
    /// <summary>
    /// Representation of Apkg file
    /// </summary>
    public class AnkiPkg
    {
        private DirectoryInfo pkgDir;
        private FileInfo mediaList;

        public FileInfo Database { get; set; }
        public List<MediaFile> Media { get; set; } 
        /// <summary>
        /// 解包apkg文件
        /// </summary>
        /// <param name="apkgPath"></param>
        /// <param name="dirPath">可为null，默认放在临时文件夹</param>
        public AnkiPkg(string apkgPath, string dirPath)
        {
            if (dirPath == null)
                dirPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            pkgDir = new DirectoryInfo(dirPath);
            if (!pkgDir.Exists)
                pkgDir.Create();
            //Load Database FileInfo
            Database = new FileInfo(Path.Combine(dirPath, "collection.anki2"));
            //Load MediaList FileInfo
            mediaList = new FileInfo(Path.Combine(dirPath, "media"));
            //Instantiate Media
            Media = new List<MediaFile>();
            //Unzip Apkg
            var apkg = new FileInfo(apkgPath);
            if (apkg.Exists && apkg.Extension == "akpg")
                ZipFile.ExtractToDirectory(apkgPath, dirPath);
            else
                throw new FileNotFoundException("Apkg File not Found");
        }

        /// <summary>
        /// 使用现有的package
        /// </summary>
        /// <param name="dirPath">已解压的Apkg文件夹路径</param>
        public AnkiPkg(string dirPath)
        {
            pkgDir = new DirectoryInfo(dirPath);
            if (!pkgDir.Exists)
                throw new DirectoryNotFoundException("No existing Apkg folder");
            //Load Database FileInfo
            Database = new FileInfo(Path.Combine(dirPath, "collection.anki2"));
            //Load MediaList FileInfo
            mediaList = new FileInfo(Path.Combine(dirPath, "media"));
            //Instantiate Media
            Media = new List<MediaFile>();
        }
        /// <summary>
        /// 检查文件结构并根据MediaList加载Media
        /// </summary>
        public void Load()
        {
            //检查medialist存在
            if (Database.Exists&&mediaList.Exists)
                LoadMediaList();
            else
                throw new FileNotFoundException("Database and/or MediaList missing");
            var list = CheckMedia();
            //检查到mediaFile不存在时输出错误信息
            if (list.Count != 0)
            {
                string missingList = "";
                foreach (var item in list)
                    missingList += $"{item.Id}: {item.Name}; ";
                throw new FileNotFoundException("MediaFile Missing: " + missingList);
            }
        }
        /// <summary>
        /// Load Database and mediaList Index, no checks included
        /// </summary>
        /// <returns></returns>
        private void LoadMediaList()
        {
            using (FileStream stream = mediaList.Open(FileMode.Open, FileAccess.Read))
                foreach (var item in JsonDocument.Parse(stream).RootElement.EnumerateObject())
                {
                    Media.Add(new MediaFile(
                        int.Parse(item.Name),
                        item.Value.GetString(),
                        pkgDir.FullName
                        ));
                }
        }
        /// <returns>
        /// 不存在MediaFile的原文件名
        /// </returns>
        private List<MediaFile> CheckMedia()
        {
            var resultMedia = new List<MediaFile>();
            foreach (var item in Media)
            {
                if (!item.Exists)
                    resultMedia.Add(item);
            }
            return resultMedia;
        }
    }
}
