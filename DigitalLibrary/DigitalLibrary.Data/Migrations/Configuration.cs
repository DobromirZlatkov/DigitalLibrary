namespace DigitalLibrary.Data.Migrations
{
    using DigitalLibrary.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DigitalLibraryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DigitalLibraryDbContext context)
        {
<<<<<<< HEAD
            if (context.Roles.Any())
            {
                return;
            }
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
            {
                Name = "trusted"
            });
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
            {
                Name = "admin"
            });
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
            {
                Name = "non-trusted"
            });
            context.SaveChanges();
=======
            //if (context.Authors.Any())
            //{
            //    return;
            //}

            //// var userId = "Archaeology";
            //var User = new User { Email = "Pesho2@abv.bg", UserName = "Pesho2@abv.bg" };
            
            //List<Author> authors = new List<Author>()
            //{
            //    new Author{ Name = "Чавдар Кирилов", PictureUrl= "\\UploadedFiles\\Archaeology\\Чавдар Кирилов\\Чавдар Кирилов.jpg"},
            //    new Author{ Name = "Румяна Колева", PictureUrl= "\\UploadedFiles\\Archaeology\\Румяна Колева\\Румяна Колева.jpg"},
            //    new Author{ Name = "Николай Овчаров", PictureUrl= "\\UploadedFiles\\Archaeology\\Николай Овчаров\\Николай Овчаров.jpg"}
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
            //        Title = "ЗлатнаЛивада",
            //        Genre = genre,
            //        UploadedBy = User,
            //        Year = 2013,
            //        ZipFileLink = "\\UploadedFiles\\"+genreName+"\\" + authors[0].Name + "\\Works\\2013\\ЗлатнаЛивада\\ЗлатнаЛивада.rar",
            //        PictureLink = "\\UploadedFiles\\"+genreName+"\\" + authors[0].Name+ "\\Works\\2013\\ЗлатнаЛивада\\ЗлатнаЛивада.jpg",  
            //        Description = "Lorem Ipsum е елементарен примерен текст, използван в печатарската и типографската индустрия. Lorem Ipsum е индустриален стандарт от около 1500 година, когато неизвестен печатар взема няколко печатарски букви и ги разбърква, за да напечата с тях книга с примерни шрифтове. Този начин не само е оцелял повече от 5 века, но е навлязъл и в публикуването на електронни издания като е запазен почти без промяна. Популяризиран е през 60те години на 20ти век със издаването на Letraset листи, съдържащи Lorem Ipsum пасажи, популярен е и в наши дни във софтуер за печатни издания като Aldus PageMaker, който включва различни версии на Lorem Ipsum.",
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
            //            Title = "Силистра",
            //            Genre = genre,
            //            UploadedBy = User,
            //            Year = 2013,
            //            ZipFileLink = "\\UploadedFiles\\"+genreName+"\\"+authors[1].Name+"\\Works/2013\\Силистра\\Силистра.rar",
            //            PictureLink = "\\UploadedFiles\\"+genreName+"\\"+authors[1].Name+"\\Works\\2013\\Силистра\\Силистра.jpg",
            //            Description = "Lorem Ipsum е елементарен примерен текст, използван в печатарската и типографската индустрия. Lorem Ipsum е индустриален стандарт от около 1500 година, когато неизвестен печатар взема няколко печатарски букви и ги разбърква, за да напечата с тях книга с примерни шрифтове. Този начин не само е оцелял повече от 5 века, но е навлязъл и в публикуването на електронни издания като е запазен почти без промяна. Популяризиран е през 60те години на 20ти век със издаването на Letraset листи, съдържащи Lorem Ipsum пасажи, популярен е и в наши дни във софтуер за печатни издания като Aldus PageMaker, който включва различни версии на Lorem Ipsum.",
            //          //  Tags = "Arheologiq rumqna Силистра",
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
            //            Title = "Перперикон",
            //            Genre = genre,
            //            UploadedBy = User,
            //            Year = 2013,
            //            ZipFileLink = "\\UploadedFiles\\"+genreName+"\\"+authors[2].Name+"\\Works\\2013\\Перперикон\\Перперикон.rar",
            //            PictureLink = "\\UploadedFiles\\"+genreName+"\\"+authors[2].Name+"\\Works\\2013\\Перперикон\\Перперикон.jpg",  
            //            Description = "Lorem Ipsum е елементарен примерен текст, използван в печатарската и типографската индустрия. Lorem Ipsum е индустриален стандарт от около 1500 година, когато неизвестен печатар взема няколко печатарски букви и ги разбърква, за да напечата с тях книга с примерни шрифтове. Този начин не само е оцелял повече от 5 века, но е навлязъл и в публикуването на електронни издания като е запазен почти без промяна. Популяризиран е през 60те години на 20ти век със издаването на Letraset листи, съдържащи Lorem Ipsum пасажи, популярен е и в наши дни във софтуер за печатни издания като Aldus PageMaker, който включва различни версии на Lorem Ipsum.",
            //         //   Tags = "Перперикон Овчаров",
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
            //        Title = "ЗлатнаЛивада",
            //        Genre = genre,
            //        UploadedBy = User,
            //        Year = 2013,
            //        ZipFileLink = "\\UploadedFiles\\"+genreName+"\\" + authors[0].Name + "\\Works\\2013\\ЗлатнаЛивада\\ЗлатнаЛивада.rar",
            //        PictureLink = "\\UploadedFiles\\"+genreName+"\\" + authors[0].Name+ "\\Works\\2013\\ЗлатнаЛивада\\ЗлатнаЛивада.jpg",  
            //        Description = "Lorem Ipsum е елементарен примерен текст, използван в печатарската и типографската индустрия. Lorem Ipsum е индустриален стандарт от около 1500 година, когато неизвестен печатар взема няколко печатарски букви и ги разбърква, за да напечата с тях книга с примерни шрифтове. Този начин не само е оцелял повече от 5 века, но е навлязъл и в публикуването на електронни издания като е запазен почти без промяна. Популяризиран е през 60те години на 20ти век със издаването на Letraset листи, съдържащи Lorem Ipsum пасажи, популярен е и в наши дни във софтуер за печатни издания като Aldus PageMaker, който включва различни версии на Lorem Ipsum.",
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
            //            Title = "Силистра",
            //            Genre = genre,
            //            UploadedBy = User,
            //            Year = 2013,
            //            ZipFileLink = "\\UploadedFiles\\"+genreName+"\\"+authors[1].Name+"\\Works/2013\\Силистра\\Силистра.rar",
            //            PictureLink = "\\UploadedFiles\\"+genreName+"\\"+authors[1].Name+"\\Works\\2013\\Силистра\\Силистра.jpg",
            //            Description = "Lorem Ipsum е елементарен примерен текст, използван в печатарската и типографската индустрия. Lorem Ipsum е индустриален стандарт от около 1500 година, когато неизвестен печатар взема няколко печатарски букви и ги разбърква, за да напечата с тях книга с примерни шрифтове. Този начин не само е оцелял повече от 5 века, но е навлязъл и в публикуването на електронни издания като е запазен почти без промяна. Популяризиран е през 60те години на 20ти век със издаването на Letraset листи, съдържащи Lorem Ipsum пасажи, популярен е и в наши дни във софтуер за печатни издания като Aldus PageMaker, който включва различни версии на Lorem Ipsum.",
            //         //   Tags = "Arheologiq rumqna Силистра",
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
            //            Title = "Перперикон",
            //            Genre = genre,
            //            UploadedBy = User,
            //            Year = 2013,
            //            ZipFileLink = "\\UploadedFiles\\"+genreName+"\\"+authors[2].Name+"\\Works\\2013\\Перперикон\\Перперикон.rar",
            //            PictureLink = "\\UploadedFiles\\"+genreName+"\\"+authors[2].Name+"\\Works\\2013\\Перперикон\\Перперикон.jpg",  
            //            Description = "Lorem Ipsum е елементарен примерен текст, използван в печатарската и типографската индустрия. Lorem Ipsum е индустриален стандарт от около 1500 година, когато неизвестен печатар взема няколко печатарски букви и ги разбърква, за да напечата с тях книга с примерни шрифтове. Този начин не само е оцелял повече от 5 века, но е навлязъл и в публикуването на електронни издания като е запазен почти без промяна. Популяризиран е през 60те години на 20ти век със издаването на Letraset листи, съдържащи Lorem Ipsum пасажи, популярен е и в наши дни във софтуер за печатни издания като Aldus PageMaker, който включва различни версии на Lorem Ipsum.",
            //          //  Tags = "Перперикон Овчаров",
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
            //        Title = "ЗлатнаЛивада",
            //        Genre = genre,
            //        UploadedBy = User,
            //        Year = 2013,
            //        ZipFileLink = "\\UploadedFiles\\"+genreName+"\\" + authors[0].Name + "\\Works\\2013\\ЗлатнаЛивада\\ЗлатнаЛивада.rar",
            //        PictureLink = "\\UploadedFiles\\"+genreName+"\\" + authors[0].Name+ "\\Works\\2013\\ЗлатнаЛивада\\ЗлатнаЛивада.jpg",  
            //        Description = "Lorem Ipsum е елементарен примерен текст, използван в печатарската и типографската индустрия. Lorem Ipsum е индустриален стандарт от около 1500 година, когато неизвестен печатар взема няколко печатарски букви и ги разбърква, за да напечата с тях книга с примерни шрифтове. Този начин не само е оцелял повече от 5 века, но е навлязъл и в публикуването на електронни издания като е запазен почти без промяна. Популяризиран е през 60те години на 20ти век със издаването на Letraset листи, съдържащи Lorem Ipsum пасажи, популярен е и в наши дни във софтуер за печатни издания като Aldus PageMaker, който включва различни версии на Lorem Ipsum.",
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
            //            Title = "Силистра",
            //            Genre = genre,
            //            UploadedBy = User,
            //            Year = 2013,
            //            ZipFileLink = "\\UploadedFiles\\"+genreName+"\\"+authors[1].Name+"\\Works/2013\\Силистра\\Силистра.rar",
            //            PictureLink = "\\UploadedFiles\\"+genreName+"\\"+authors[1].Name+"\\Works\\2013\\Силистра\\Силистра.jpg",
            //            Description = "Lorem Ipsum е елементарен примерен текст, използван в печатарската и типографската индустрия. Lorem Ipsum е индустриален стандарт от около 1500 година, когато неизвестен печатар взема няколко печатарски букви и ги разбърква, за да напечата с тях книга с примерни шрифтове. Този начин не само е оцелял повече от 5 века, но е навлязъл и в публикуването на електронни издания като е запазен почти без промяна. Популяризиран е през 60те години на 20ти век със издаването на Letraset листи, съдържащи Lorem Ipsum пасажи, популярен е и в наши дни във софтуер за печатни издания като Aldus PageMaker, който включва различни версии на Lorem Ipsum.",
            //         //   Tags = "Arheologiq rumqna Силистра",
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
            //            Title = "Перперикон",
            //            Genre = genre,
            //            UploadedBy = User,
            //            Year = 2013,
            //            ZipFileLink = "\\UploadedFiles\\"+genreName+"\\"+authors[2].Name+"\\Works\\2013\\Перперикон\\Перперикон.rar",
            //            PictureLink = "\\UploadedFiles\\"+genreName+"\\"+authors[2].Name+"\\Works\\2013\\Перперикон\\Перперикон.jpg",  
            //            Description = "Lorem Ipsum е елементарен примерен текст, използван в печатарската и типографската индустрия. Lorem Ipsum е индустриален стандарт от около 1500 година, когато неизвестен печатар взема няколко печатарски букви и ги разбърква, за да напечата с тях книга с примерни шрифтове. Този начин не само е оцелял повече от 5 века, но е навлязъл и в публикуването на електронни издания като е запазен почти без промяна. Популяризиран е през 60те години на 20ти век със издаването на Letraset листи, съдържащи Lorem Ipsum пасажи, популярен е и в наши дни във софтуер за печатни издания като Aldus PageMaker, който включва различни версии на Lorem Ipsum.",
            //          //  Tags = "Перперикон Овчаров",
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
>>>>>>> parent of 18492b8... Added role manager and did some role logic
        }

    }
}
