namespace DigitalLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    using DigitalLibrary.Models;

    public sealed class Configuration : DbMigrationsConfiguration<LibraryDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LibraryDbContext context)
        {
            //if (context.Authors.Any())
            //{
            //    return;
            //}

            //// var userId = "Archaeology";
            //var User = new User { Email = "Pesho2@abv.bg", UserName = "Pesho2@abv.bg" };
            
            //List<Author> authors = new List<Author>()
            //{
            //    new Author{ Name = "������ �������", PictureUrl= "\\UploadedFiles\\Archaeology\\������ �������\\������ �������.jpg"},
            //    new Author{ Name = "������ ������", PictureUrl= "\\UploadedFiles\\Archaeology\\������ ������\\������ ������.jpg"},
            //    new Author{ Name = "������� �������", PictureUrl= "\\UploadedFiles\\Archaeology\\������� �������\\������� �������.jpg"}
            //};

            //foreach (var work in authors)
            //{
            //    context.Authors.Add(work);
            //}

            //context.SaveChanges();


            //var genre = new Genre { GenreName = "Archaeology" };
            //var genreName = genre.GenreName;
            //List<Work> works = new List<Work>()
            //{
            //    new Work
            //    {
            //        Author = authors[0],
            //        Title = "������������",
            //        Genre = genre,
            //        UploadedBy = User,
            //        Year = 2013,
            //        ZipFileLink = "\\UploadedFiles\\"+genreName+"\\" + authors[0].Name + "\\Works\\2013\\������������\\������������.rar",
            //        PictureLink = "\\UploadedFiles\\"+genreName+"\\" + authors[0].Name+ "\\Works\\2013\\������������\\������������.jpg",  
            //        Description = "Lorem Ipsum � ����������� �������� �����, ��������� � ������������ � ������������� ���������. Lorem Ipsum � ������������ �������� �� ����� 1500 ������, ������ ���������� ������� ����� ������� ���������� ����� � �� ���������, �� �� �������� � ��� ����� � �������� ��������. ���� ����� �� ���� � ������ ������ �� 5 ����, �� � �������� � � ������������� �� ���������� ������� ���� � ������� ����� ��� �������. ������������� � ���� 60�� ������ �� 20�� ��� ��� ���������� �� Letraset �����, ��������� Lorem Ipsum ������, ��������� � � � ���� ��� ��� ������� �� ������� ������� ���� Aldus PageMaker, ����� ������� �������� ������ �� Lorem Ipsum.",
            //     //   Tags = "Arheologiq chavdar zlatna livada",
            //        Comments = new HashSet<Comment>()
            //        {
            //            new Comment{ Content="test comment", PostedBy=User, DatePosted = DateTime.Now},
            //            new Comment{ Content="test comment2", PostedBy=User, DatePosted = DateTime.Now},
            //            new Comment{ Content="test comment3", PostedBy=User, DatePosted = DateTime.Now},
            //        }
            //    }
            //    ,
            //    new Work
            //        {
            //            Author = authors[1],
            //            Title = "��������",
            //            Genre = genre,
            //            UploadedBy = User,
            //            Year = 2013,
            //            ZipFileLink = "\\UploadedFiles\\"+genreName+"\\"+authors[1].Name+"\\Works/2013\\��������\\��������.rar",
            //            PictureLink = "\\UploadedFiles\\"+genreName+"\\"+authors[1].Name+"\\Works\\2013\\��������\\��������.jpg",
            //            Description = "Lorem Ipsum � ����������� �������� �����, ��������� � ������������ � ������������� ���������. Lorem Ipsum � ������������ �������� �� ����� 1500 ������, ������ ���������� ������� ����� ������� ���������� ����� � �� ���������, �� �� �������� � ��� ����� � �������� ��������. ���� ����� �� ���� � ������ ������ �� 5 ����, �� � �������� � � ������������� �� ���������� ������� ���� � ������� ����� ��� �������. ������������� � ���� 60�� ������ �� 20�� ��� ��� ���������� �� Letraset �����, ��������� Lorem Ipsum ������, ��������� � � � ���� ��� ��� ������� �� ������� ������� ���� Aldus PageMaker, ����� ������� �������� ������ �� Lorem Ipsum.",
            //          //  Tags = "Arheologiq rumqna ��������",
            //            Comments = new HashSet<Comment>()
            //            {
            //                new Comment{ Content="test comment", PostedBy=User, DatePosted = DateTime.Now},
            //                new Comment{ Content="test comment2", PostedBy=User, DatePosted = DateTime.Now},
            //                new Comment{ Content="test comment3", PostedBy=User, DatePosted = DateTime.Now},
            //            }
            //        },
            //     new Work
            //        {
            //            Author = authors[2],
            //            Title = "����������",
            //            Genre = genre,
            //            UploadedBy = User,
            //            Year = 2013,
            //            ZipFileLink = "\\UploadedFiles\\"+genreName+"\\"+authors[2].Name+"\\Works\\2013\\����������\\����������.rar",
            //            PictureLink = "\\UploadedFiles\\"+genreName+"\\"+authors[2].Name+"\\Works\\2013\\����������\\����������.jpg",  
            //            Description = "Lorem Ipsum � ����������� �������� �����, ��������� � ������������ � ������������� ���������. Lorem Ipsum � ������������ �������� �� ����� 1500 ������, ������ ���������� ������� ����� ������� ���������� ����� � �� ���������, �� �� �������� � ��� ����� � �������� ��������. ���� ����� �� ���� � ������ ������ �� 5 ����, �� � �������� � � ������������� �� ���������� ������� ���� � ������� ����� ��� �������. ������������� � ���� 60�� ������ �� 20�� ��� ��� ���������� �� Letraset �����, ��������� Lorem Ipsum ������, ��������� � � � ���� ��� ��� ������� �� ������� ������� ���� Aldus PageMaker, ����� ������� �������� ������ �� Lorem Ipsum.",
            //         //   Tags = "���������� �������",
            //            Comments = new HashSet<Comment>()
            //            {
            //                new Comment{ Content="test comment", PostedBy=User, DatePosted = DateTime.Now},
            //                new Comment{ Content="test comment2", PostedBy=User, DatePosted = DateTime.Now},
            //                new Comment{ Content="test comment3", PostedBy=User, DatePosted = DateTime.Now},
            //            }
            //        },
            //        new Work
            //    {
            //        Author = authors[0],
            //        Title = "������������",
            //        Genre = genre,
            //        UploadedBy = User,
            //        Year = 2013,
            //        ZipFileLink = "\\UploadedFiles\\"+genreName+"\\" + authors[0].Name + "\\Works\\2013\\������������\\������������.rar",
            //        PictureLink = "\\UploadedFiles\\"+genreName+"\\" + authors[0].Name+ "\\Works\\2013\\������������\\������������.jpg",  
            //        Description = "Lorem Ipsum � ����������� �������� �����, ��������� � ������������ � ������������� ���������. Lorem Ipsum � ������������ �������� �� ����� 1500 ������, ������ ���������� ������� ����� ������� ���������� ����� � �� ���������, �� �� �������� � ��� ����� � �������� ��������. ���� ����� �� ���� � ������ ������ �� 5 ����, �� � �������� � � ������������� �� ���������� ������� ���� � ������� ����� ��� �������. ������������� � ���� 60�� ������ �� 20�� ��� ��� ���������� �� Letraset �����, ��������� Lorem Ipsum ������, ��������� � � � ���� ��� ��� ������� �� ������� ������� ���� Aldus PageMaker, ����� ������� �������� ������ �� Lorem Ipsum.",
            //      //  Tags = "Arheologiq chavdar zlatna livada",
            //        Comments = new HashSet<Comment>()
            //        {
            //            new Comment{ Content="test comment", PostedBy=User, DatePosted = DateTime.Now},
            //            new Comment{ Content="test comment2", PostedBy=User, DatePosted = DateTime.Now},
            //            new Comment{ Content="test comment3", PostedBy=User, DatePosted = DateTime.Now},
            //        }
            //    }
            //    ,
            //    new Work
            //        {
            //            Author = authors[1],
            //            Title = "��������",
            //            Genre = genre,
            //            UploadedBy = User,
            //            Year = 2013,
            //            ZipFileLink = "\\UploadedFiles\\"+genreName+"\\"+authors[1].Name+"\\Works/2013\\��������\\��������.rar",
            //            PictureLink = "\\UploadedFiles\\"+genreName+"\\"+authors[1].Name+"\\Works\\2013\\��������\\��������.jpg",
            //            Description = "Lorem Ipsum � ����������� �������� �����, ��������� � ������������ � ������������� ���������. Lorem Ipsum � ������������ �������� �� ����� 1500 ������, ������ ���������� ������� ����� ������� ���������� ����� � �� ���������, �� �� �������� � ��� ����� � �������� ��������. ���� ����� �� ���� � ������ ������ �� 5 ����, �� � �������� � � ������������� �� ���������� ������� ���� � ������� ����� ��� �������. ������������� � ���� 60�� ������ �� 20�� ��� ��� ���������� �� Letraset �����, ��������� Lorem Ipsum ������, ��������� � � � ���� ��� ��� ������� �� ������� ������� ���� Aldus PageMaker, ����� ������� �������� ������ �� Lorem Ipsum.",
            //         //   Tags = "Arheologiq rumqna ��������",
            //            Comments = new HashSet<Comment>()
            //            {
            //                new Comment{ Content="test comment", PostedBy=User, DatePosted = DateTime.Now},
            //                new Comment{ Content="test comment2", PostedBy=User, DatePosted = DateTime.Now},
            //                new Comment{ Content="test comment3", PostedBy=User, DatePosted = DateTime.Now},
            //            }
            //        },
            //     new Work
            //        {
            //            Author = authors[2],
            //            Title = "����������",
            //            Genre = genre,
            //            UploadedBy = User,
            //            Year = 2013,
            //            ZipFileLink = "\\UploadedFiles\\"+genreName+"\\"+authors[2].Name+"\\Works\\2013\\����������\\����������.rar",
            //            PictureLink = "\\UploadedFiles\\"+genreName+"\\"+authors[2].Name+"\\Works\\2013\\����������\\����������.jpg",  
            //            Description = "Lorem Ipsum � ����������� �������� �����, ��������� � ������������ � ������������� ���������. Lorem Ipsum � ������������ �������� �� ����� 1500 ������, ������ ���������� ������� ����� ������� ���������� ����� � �� ���������, �� �� �������� � ��� ����� � �������� ��������. ���� ����� �� ���� � ������ ������ �� 5 ����, �� � �������� � � ������������� �� ���������� ������� ���� � ������� ����� ��� �������. ������������� � ���� 60�� ������ �� 20�� ��� ��� ���������� �� Letraset �����, ��������� Lorem Ipsum ������, ��������� � � � ���� ��� ��� ������� �� ������� ������� ���� Aldus PageMaker, ����� ������� �������� ������ �� Lorem Ipsum.",
            //          //  Tags = "���������� �������",
            //            Comments = new HashSet<Comment>()
            //            {
            //                new Comment{ Content="test comment", PostedBy=User, DatePosted = DateTime.Now},
            //                new Comment{ Content="test comment2", PostedBy=User, DatePosted = DateTime.Now},
            //                new Comment{ Content="test comment3", PostedBy=User, DatePosted = DateTime.Now},
            //            }
            //        }  ,
            //        new Work
            //    {
            //        Author = authors[0],
            //        Title = "������������",
            //        Genre = genre,
            //        UploadedBy = User,
            //        Year = 2013,
            //        ZipFileLink = "\\UploadedFiles\\"+genreName+"\\" + authors[0].Name + "\\Works\\2013\\������������\\������������.rar",
            //        PictureLink = "\\UploadedFiles\\"+genreName+"\\" + authors[0].Name+ "\\Works\\2013\\������������\\������������.jpg",  
            //        Description = "Lorem Ipsum � ����������� �������� �����, ��������� � ������������ � ������������� ���������. Lorem Ipsum � ������������ �������� �� ����� 1500 ������, ������ ���������� ������� ����� ������� ���������� ����� � �� ���������, �� �� �������� � ��� ����� � �������� ��������. ���� ����� �� ���� � ������ ������ �� 5 ����, �� � �������� � � ������������� �� ���������� ������� ���� � ������� ����� ��� �������. ������������� � ���� 60�� ������ �� 20�� ��� ��� ���������� �� Letraset �����, ��������� Lorem Ipsum ������, ��������� � � � ���� ��� ��� ������� �� ������� ������� ���� Aldus PageMaker, ����� ������� �������� ������ �� Lorem Ipsum.",
            //       // Tags = "Arheologiq chavdar zlatna livada",
            //        Comments = new HashSet<Comment>()
            //        {
            //            new Comment{ Content="test comment", PostedBy=User, DatePosted = DateTime.Now},
            //            new Comment{ Content="test comment2", PostedBy=User, DatePosted = DateTime.Now},
            //            new Comment{ Content="test comment3", PostedBy=User, DatePosted = DateTime.Now},
            //        }
            //    }
            //    ,
            //    new Work
            //        {
            //            Author = authors[1],
            //            Title = "��������",
            //            Genre = genre,
            //            UploadedBy = User,
            //            Year = 2013,
            //            ZipFileLink = "\\UploadedFiles\\"+genreName+"\\"+authors[1].Name+"\\Works/2013\\��������\\��������.rar",
            //            PictureLink = "\\UploadedFiles\\"+genreName+"\\"+authors[1].Name+"\\Works\\2013\\��������\\��������.jpg",
            //            Description = "Lorem Ipsum � ����������� �������� �����, ��������� � ������������ � ������������� ���������. Lorem Ipsum � ������������ �������� �� ����� 1500 ������, ������ ���������� ������� ����� ������� ���������� ����� � �� ���������, �� �� �������� � ��� ����� � �������� ��������. ���� ����� �� ���� � ������ ������ �� 5 ����, �� � �������� � � ������������� �� ���������� ������� ���� � ������� ����� ��� �������. ������������� � ���� 60�� ������ �� 20�� ��� ��� ���������� �� Letraset �����, ��������� Lorem Ipsum ������, ��������� � � � ���� ��� ��� ������� �� ������� ������� ���� Aldus PageMaker, ����� ������� �������� ������ �� Lorem Ipsum.",
            //         //   Tags = "Arheologiq rumqna ��������",
            //            Comments = new HashSet<Comment>()
            //            {
            //                new Comment{ Content="test comment", PostedBy=User, DatePosted = DateTime.Now},
            //                new Comment{ Content="test comment2", PostedBy=User, DatePosted = DateTime.Now},
            //                new Comment{ Content="test comment3", PostedBy=User, DatePosted = DateTime.Now},
            //            }
            //        },
            //     new Work
            //        {
            //            Author = authors[2],
            //            Title = "����������",
            //            Genre = genre,
            //            UploadedBy = User,
            //            Year = 2013,
            //            ZipFileLink = "\\UploadedFiles\\"+genreName+"\\"+authors[2].Name+"\\Works\\2013\\����������\\����������.rar",
            //            PictureLink = "\\UploadedFiles\\"+genreName+"\\"+authors[2].Name+"\\Works\\2013\\����������\\����������.jpg",  
            //            Description = "Lorem Ipsum � ����������� �������� �����, ��������� � ������������ � ������������� ���������. Lorem Ipsum � ������������ �������� �� ����� 1500 ������, ������ ���������� ������� ����� ������� ���������� ����� � �� ���������, �� �� �������� � ��� ����� � �������� ��������. ���� ����� �� ���� � ������ ������ �� 5 ����, �� � �������� � � ������������� �� ���������� ������� ���� � ������� ����� ��� �������. ������������� � ���� 60�� ������ �� 20�� ��� ��� ���������� �� Letraset �����, ��������� Lorem Ipsum ������, ��������� � � � ���� ��� ��� ������� �� ������� ������� ���� Aldus PageMaker, ����� ������� �������� ������ �� Lorem Ipsum.",
            //          //  Tags = "���������� �������",
            //            Comments = new HashSet<Comment>()
            //            {
            //                new Comment{ Content="test comment", PostedBy=User, DatePosted = DateTime.Now},
            //                new Comment{ Content="test comment2", PostedBy=User, DatePosted = DateTime.Now},
            //                new Comment{ Content="test comment3", PostedBy=User, DatePosted = DateTime.Now},
            //            }
            //        }  
            //};

            //foreach (var work in works)
            //{
            //    context.Works.Add(work);
            //}

            //context.SaveChanges();
        }
    }
}