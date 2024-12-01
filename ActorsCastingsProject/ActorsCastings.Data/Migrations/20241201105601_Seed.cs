using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ActorsCastings.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Plays",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                comment: "Description of the play",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true,
                oldComment: "Description of the play");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movies",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                comment: "Description of the movie",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true,
                oldComment: "Description of the movie");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("00437133-5332-45a7-952e-dc8b6b740b76"), 0, "b82b7a04-c41d-49bd-a7f3-0fff5cde8fc1", "ivanivanov1@abv.bg", false, true, null, "IVANIVANOV1@ABV.BG", "IVANIVANOV1@ABV.BG", "AQAAAAIAAYagAAAAEAOtSYzyefjnucipwjU6wGBNuqLQ7T7jPXllslVQ8WciOwQvIMt7dvnKf7TuO4U5DA==", null, false, null, false, null },
                    { new Guid("0487d986-ece3-4f68-9e3a-2d064f15a14a"), 0, "36ccc4a7-8862-4e10-8ee3-9b94d1f97da4", "ivanivanov8@abv.bg", false, true, null, "IVANIVANOV8@ABV.BG", "IVANIVANOV8@ABV.BG", "AQAAAAIAAYagAAAAEBPEt9pRGTnzWnI47b+MAK0e1165vFMUch5YlietWYLQuIisIsY0kseNNkSTK0I2ww==", null, false, null, false, null },
                    { new Guid("0719936f-703e-4836-ade1-1d00e7225256"), 0, "4d7bbf4d-10ab-4f87-9b8d-c723b0b3f0a4", "ivanivanov3@abv.bg", false, true, null, "IVANIVANOV3@ABV.BG", "IVANIVANOV3@ABV.BG", "AQAAAAIAAYagAAAAEMXPQeB1DN9pT3dJtXR/uMToNQTMYQEq0DbQyMNVRFZvI8JHJLWkyG/dPeG+orghtw==", null, false, null, false, null },
                    { new Guid("386f0ce1-1884-4c63-beb0-746bb8e73634"), 0, "519a02bc-57e4-4e00-9299-6138ebae9dce", "ivanivanov6@abv.bg", false, true, null, "IVANIVANOV6@ABV.BG", "IVANIVANOV6@ABV.BG", "AQAAAAIAAYagAAAAENALEvbPwRfPyah0NJnVHzje+HjnpKc7IaAhZPaeoE6Z93Uq0Yzx+5WradW/+xtllw==", null, false, null, false, null },
                    { new Guid("a5faafe7-4729-4102-a2de-adf525f9d042"), 0, "7d40e4cd-e0f3-4485-8eb3-0be4cdde9ca5", "ivanivanov10@abv.bg", false, true, null, "IVANIVANOV10@ABV.BG", "IVANIVANOV10@ABV.BG", "AQAAAAIAAYagAAAAEC4rgEtSOxiEiQJRG8H2NJEQtR91U0RV3iGYOq7sy5jZ96V/g7mtCpoHyAbGrczWng==", null, false, null, false, null },
                    { new Guid("be1c5570-a3dd-444a-9d43-bc0fef22a105"), 0, "e3ac478a-36e2-447d-8426-b1f8f9ae041f", "ivanivanov4@abv.bg", false, true, null, "IVANIVANOV4@ABV.BG", "IVANIVANOV4@ABV.BG", "AQAAAAIAAYagAAAAEO7TKl6GSGnG3tGL60pT7XimFJt5vO6V5Lmq0Xdi9IOhA3oyu0Tjp9hGiVe7wKjTaQ==", null, false, null, false, null },
                    { new Guid("c36656b1-d6c7-4682-92fd-2b5f5c982241"), 0, "1ec680d0-df38-47a3-9a4b-a50ab74a3679", "ivanivanov5@abv.bg", false, true, null, "IVANIVANOV5@ABV.BG", "IVANIVANOV5@ABV.BG", "AQAAAAIAAYagAAAAEKzj1HifRZmFgLGHN1363ZLjHPjI+XqKQCH2lA/ibeE9IrE9XhJgFixXhE9ZRMh+7Q==", null, false, null, false, null },
                    { new Guid("e5aeebb4-3d1b-4c8b-b19e-1ea073938b16"), 0, "f0b1c98b-3757-4213-a132-3a2284444998", "ivanivanov7@abv.bg", false, true, null, "IVANIVANOV7@ABV.BG", "IVANIVANOV7@ABV.BG", "AQAAAAIAAYagAAAAEMLhKp4yTsKDysEafY4kajZ0BTmIF3eEffR8/ngmqJyGob5ucfx/bJNVq7EzeUTJBg==", null, false, null, false, null },
                    { new Guid("e9e3fa9c-ff55-4788-9085-cd00806062ec"), 0, "2511739e-682b-4257-8fb5-1cb51d653399", "ivanivanov9@abv.bg", false, true, null, "IVANIVANOV9@ABV.BG", "IVANIVANOV9@ABV.BG", "AQAAAAIAAYagAAAAEM0rcUZfu+OVRfSemy3AJB5NwkylNjAhKYv6NPyHN8lL4wL+snTRsfQMQquKD3M8lQ==", null, false, null, false, null },
                    { new Guid("efc80aaa-7890-4f3f-80c0-5a86b0afe157"), 0, "a3c77169-0318-499c-aee0-3d5cac0a7696", "ivanivanov2@abv.bg", false, true, null, "IVANIVANOV2@ABV.BG", "IVANIVANOV2@ABV.BG", "AQAAAAIAAYagAAAAEDTDV3otRZFlRHS/mnflLeb3c14s+HScsyV0OVtiIlCWPAXeF0On4/j24SvBAn4A4g==", null, false, null, false, null }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Genre", "ImageUrl", "IsApproved", "IsDeleted", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { new Guid("0276d235-774d-441f-ac77-9badafc4d814"), "10th century, the most powerful state in Europe rests on a terrible secret that may threaten the very foundations of Christianity. Captured between political intrigues and warrior battles the young prince Bayan is searching for an ancient alphabet that could save his doomed love or his kingdom. A medieval mystery drama about the birth of the Cyrillic alphabet.", "Zoran Petrovski, Viktor Chuchkov", "History Drama", "https://m.media-amazon.com/images/M/MV5BZDljYzNlNmMtNTViYi00N2Y1LWFiOTItYzhkMzBiMzY0ZDM3XkEyXkFqcGc@._V1_.jpg", true, false, 2022, "War of Letters" },
                    { new Guid("688dec9c-6a78-4769-80cc-b2281c4c7d2a"), "Trained young policeman goes undercover in the gang of the most dangerous mafia boss in Bulgaria.", "Victor Bojinov", "Action", "https://www.vivacom.bg/web/files/arena/630/image/thumb_388x564_%D0%9F%D0%BE%D0%B4%20%D0%BF%D1%80%D0%B8%D0%BA%D1%80%D0%B8%D1%82%D0%B8%D0%B5.jpg", true, false, 2011, "Undercover" },
                    { new Guid("7f3c4a10-2f6f-4434-840b-73f135c83aca"), "Follows the parallel stories of a number of characters who are trying to change their lives via the Internet or are simply having fun online.", "Ilian Djevelekov", "Drama", "https://www.cinefish.bg/data/movies_images/138/p_138649.jpg", true, false, 2011, "Love.net" },
                    { new Guid("cbe7da20-087d-4f57-bd21-9b9af1690bc1"), "A middle aged man named Nikola is struggling with his life in his home country Bulgaria. He decides to move to Germany and is desperately trying to restore relationships with all his beloved people, just a day before he leaves. This is director's first feature film.", "Pavel G. Vesnakov", "Drama", "https://www.bta.bg/upload/4349066/Vergov_Fyre.jpg?l=1000&original=41849178c4da42705e2edc8c815ef18546c6d52e", true, false, 2020, "German Lessons" },
                    { new Guid("d5aa5fca-551e-4721-a332-b56a5821dd73"), "Kalin (35) is a talented advertising specialist, weary of life. Bilyana (35) is a free spirit, still uncertain of what she wants. They grew up in Socialist Bulgaria, where they were part of a mad group of friends, for whom every day was a different adventure. Childlike, they had a pact to get married. The two of them meet 25 years later.", "Stanislav Todorov Rogi", "Drama", "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/d/y/dyvka-za-baloncheta-dvd.jpg", true, false, 2017, "Bubblegum" }
                });

            migrationBuilder.InsertData(
                table: "Plays",
                columns: new[] { "Id", "Description", "Director", "ImageUrl", "IsApproved", "IsDeleted", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { new Guid("099134cb-ae73-4199-927c-9f84e1064710"), "The Father by the French playwright Florian Zeller is an absolute hit on the theater stages of New York, Paris, Berlin and London. The virtuoso plot immerses the main character Andre in a world of branching identities.", "Diana Dobreva", "https://nationaltheatre.bg/storage/shows/6635392173eb94e9023a68ea3568f7e031.jpg", true, false, 2018, "The Father" },
                    { new Guid("253a0612-1359-4c37-a6b2-75593ea3320e"), "Alexey Salnikov's novel Petrovi in ​​and around the flu caused a sensation in Russia in 2016, and a year later won the NOS and National Bestseller critics' awards. The probability that the stage version and the spectacle of the director Boyan Kracholov will cause a sensation is equally great.", "Boyan Kracholov", "https://nationaltheatre.bg/storage/shows/21896537f742a18038a69548af7cd69b356.jpg", true, false, 2023, "Petrov's Flu" },
                    { new Guid("9abd46e4-9f75-41a9-8cc3-d142997c04cf"), "What can we say? When? In what way? Under what circumstances? Although we take free speech for granted, there are things that can no longer be said. Especially in the relationship between man and woman. However, they tell each other everything. Two characters with hellish personalities. He is unscrupulous, provocative and does not keep silent. She is unfiltered, sassy and arrogant. They love each other, but spend most of their time arguing and arguing.", "Yavor Gardev", "https://artvent.bg/images/news/163fc676768c8c.jpg", true, false, 2023, "Don't say that!" },
                    { new Guid("cef3172a-d9ae-41c7-834f-cd934a506b95"), "The play Moby Dick, based on Herman Melville's novel, tells the story of Captain Ahab, chasing a majestic white whale around the globe. In the biblical journey he is accompanied by a crew ready to go with him to the end. Far from them remain their wives, whose dreams determine the direction of the ship.", "Diana Dobreva", "https://nationaltheatre.bg/storage/shows/232d06b4cc9e283a6ca63f0ac051c7fbeed.png", true, false, 2024, "Moby Dick" },
                    { new Guid("d49574dd-ab22-4b5c-9de6-892c09e786f3"), "Medea's name easily conjures up the image of a screaming monster-killer from Antiquity. But the truth is that Euripides brings Medea's experience uncomfortably close to each of us. His Medea is a very real woman who faces an overwhelming ordeal.", "Declan Donnellan", "https://nationaltheatre.bg/storage/shows/257bd0afd723a7d282d77ab2815962c295a.jpg", true, false, 2024, "Medea" }
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Age", "Biography", "FirstName", "IsDeleted", "LastName", "ProfilePictureUrl", "UserId" },
                values: new object[,]
                {
                    { new Guid("01bd7e28-6449-4efc-9f1f-f70a29caaac3"), 47, "Born on December 14, 1977. in Sofia. As a child, in the 1980s, he participated in television films for the Bulgarian Television. He received his secondary education at NGDEK. In the year 2000 graduated from NATFIZ with a major in acting for dramatic theater in the class of professor Snezhina Tankovska and associate professor Andrey Batashov.", "Teodora", false, "Duhovnikova", "https://nationaltheatre.bg/storage/profiles/61272290fa286b2621edbb2f92ee5cfd8c.JPG", new Guid("efc80aaa-7890-4f3f-80c0-5a86b0afe157") },
                    { new Guid("072212c8-bfb2-4179-802c-3cc46648bbdc"), 66, "He was born in Sofia, Bulgaria. His father is Nikola Penev, a journalist from the Zemedelsko zname newspaper. He completed his secondary education at Vasil Levski 8th Secondary School. Since 1982 is a master of acting for dramatic theater in the class of prof. Nikolay Lyutskanov with assistant Margarita Mladenova, VITIZ Krastyo Sarafov.", "Vladimir", false, "Penev", "https://nationaltheatre.bg/storage/profiles/517ce32090fd407133468811fd50563a9.jpg", new Guid("c36656b1-d6c7-4682-92fd-2b5f5c982241") },
                    { new Guid("0f6d3a0c-b710-4e8d-ae81-460396b39a91"), 44, "Zahari Baharov was born on August 12, 1980 in Sofia. He started acting by accident in high school, and in 1998 was admitted to NATFIZ in the class of prof. Nadezhda Seikova and graduated in 2002.", "Zahari", false, "Baharov", "https://nationaltheatre.bg/storage/profiles/28079f3b7c33cc2e5a34a62aa023631f86d.jpg", new Guid("00437133-5332-45a7-952e-dc8b6b740b76") },
                    { new Guid("44c54c7a-b031-404c-afd6-830dd00e7b83"), 31, "He graduated from NATFIZ Krastyo Sarafov in 2017. in the class of prof. Ivaylo Hristov.", "Nencho", false, "Kostov", "https://alternativavestnik.home.blog/wp-content/uploads/2023/02/received_1184727408853038.jpeg?w=683", new Guid("0719936f-703e-4836-ade1-1d00e7225256") },
                    { new Guid("8141b06f-e8e8-4988-b317-c43665f74e8a"), 54, "Graduated acting at Luben Groys Theater College in the class of Professor Tsvetana Maneva in 2001. He made his debut on the stage of the Ivan Vazov National Theater in Romeo and Juliet by William Shakespeare, staged by Lilia Abadzhieva.", "Julian", false, "Vergov", "https://interview.to/wp-content/uploads/2015/09/img_1755.jpg", new Guid("be1c5570-a3dd-444a-9d43-bc0fef22a105") }
                });

            migrationBuilder.InsertData(
                table: "CastingAgents",
                columns: new[] { "Id", "CastingAgency", "IsDeleted", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("8b299bb7-7857-49be-b953-47d0961d6de7"), "New Actors Studio", false, "Martin Georgiev", new Guid("0487d986-ece3-4f68-9e3a-2d064f15a14a") },
                    { new Guid("8d91e4cf-b8d7-4cbd-938f-e377fb6913e2"), "Artist Studio", false, "Maria Ivanova", new Guid("e5aeebb4-3d1b-4c8b-b19e-1ea073938b16") },
                    { new Guid("b3ddcdfc-21fb-4b60-8e99-8386cea3155a"), "CastingCrew", false, "Dimitar Dimitrov", new Guid("a5faafe7-4729-4102-a2de-adf525f9d042") },
                    { new Guid("dc9a62c2-46f0-41b6-8fc2-0975dfba24bb"), "Cast.bg", false, "Anna Petkova", new Guid("e9e3fa9c-ff55-4788-9085-cd00806062ec") },
                    { new Guid("f5208d8b-a974-43ed-b8b0-54826c061a6e"), "SmartCast", false, "Petar Ivanov", new Guid("386f0ce1-1884-4c63-beb0-746bb8e73634") }
                });

            migrationBuilder.InsertData(
                table: "ActorsMovies",
                columns: new[] { "ActorId", "MovieId", "Role" },
                values: new object[,]
                {
                    { new Guid("01bd7e28-6449-4efc-9f1f-f70a29caaac3"), new Guid("0276d235-774d-441f-ac77-9badafc4d814"), "Mariam" },
                    { new Guid("01bd7e28-6449-4efc-9f1f-f70a29caaac3"), new Guid("688dec9c-6a78-4769-80cc-b2281c4c7d2a"), "Elica Vladeva" },
                    { new Guid("01bd7e28-6449-4efc-9f1f-f70a29caaac3"), new Guid("d5aa5fca-551e-4721-a332-b56a5821dd73"), "Bilyana" },
                    { new Guid("072212c8-bfb2-4179-802c-3cc46648bbdc"), new Guid("688dec9c-6a78-4769-80cc-b2281c4c7d2a"), "Emil Popov" },
                    { new Guid("072212c8-bfb2-4179-802c-3cc46648bbdc"), new Guid("7f3c4a10-2f6f-4434-840b-73f135c83aca"), "The chief" },
                    { new Guid("0f6d3a0c-b710-4e8d-ae81-460396b39a91"), new Guid("0276d235-774d-441f-ac77-9badafc4d814"), "Sursuvul" },
                    { new Guid("0f6d3a0c-b710-4e8d-ae81-460396b39a91"), new Guid("688dec9c-6a78-4769-80cc-b2281c4c7d2a"), "Ivo Andonov" },
                    { new Guid("0f6d3a0c-b710-4e8d-ae81-460396b39a91"), new Guid("7f3c4a10-2f6f-4434-840b-73f135c83aca"), "Andrey Bogatev" },
                    { new Guid("44c54c7a-b031-404c-afd6-830dd00e7b83"), new Guid("0276d235-774d-441f-ac77-9badafc4d814"), "Petar" },
                    { new Guid("8141b06f-e8e8-4988-b317-c43665f74e8a"), new Guid("cbe7da20-087d-4f57-bd21-9b9af1690bc1"), "Nikola" }
                });

            migrationBuilder.InsertData(
                table: "ActorsPlays",
                columns: new[] { "ActorId", "PlayId", "Role" },
                values: new object[,]
                {
                    { new Guid("01bd7e28-6449-4efc-9f1f-f70a29caaac3"), new Guid("099134cb-ae73-4199-927c-9f84e1064710"), null },
                    { new Guid("01bd7e28-6449-4efc-9f1f-f70a29caaac3"), new Guid("9abd46e4-9f75-41a9-8cc3-d142997c04cf"), "She" },
                    { new Guid("072212c8-bfb2-4179-802c-3cc46648bbdc"), new Guid("099134cb-ae73-4199-927c-9f84e1064710"), "Andre" },
                    { new Guid("072212c8-bfb2-4179-802c-3cc46648bbdc"), new Guid("cef3172a-d9ae-41c7-834f-cd934a506b95"), "Ishmael" },
                    { new Guid("0f6d3a0c-b710-4e8d-ae81-460396b39a91"), new Guid("9abd46e4-9f75-41a9-8cc3-d142997c04cf"), "He" },
                    { new Guid("44c54c7a-b031-404c-afd6-830dd00e7b83"), new Guid("253a0612-1359-4c37-a6b2-75593ea3320e"), "Sergei" },
                    { new Guid("44c54c7a-b031-404c-afd6-830dd00e7b83"), new Guid("cef3172a-d9ae-41c7-834f-cd934a506b95"), "Stubb" },
                    { new Guid("8141b06f-e8e8-4988-b317-c43665f74e8a"), new Guid("099134cb-ae73-4199-927c-9f84e1064710"), null }
                });

            migrationBuilder.InsertData(
                table: "Castings",
                columns: new[] { "Id", "CastingAgentId", "CastingEnd", "CreatedOn", "Description", "IsApproved", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { new Guid("1c801301-f82a-4c69-aedf-8aef41afb68b"), new Guid("dc9a62c2-46f0-41b6-8fc2-0975dfba24bb"), new DateTime(2024, 12, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 21, 1, 42, 40, 0, DateTimeKind.Unspecified), "We're looking for a woman at an age from 30 to 40 and a boy aged 6 to 9 for a Coca Cola ad.", true, false, "Coca Cola Casting for a mother and a little boy" },
                    { new Guid("3f857443-4eec-42b0-9ed0-101973987ad7"), new Guid("f5208d8b-a974-43ed-b8b0-54826c061a6e"), new DateTime(2024, 12, 21, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 25, 1, 42, 40, 0, DateTimeKind.Unspecified), "We're looking for a woman at an age from 25 to 35 for a secondary role in new movie", true, false, "Movie Casting Woman" },
                    { new Guid("5656965a-e13f-43d3-9754-639f3398191c"), new Guid("8d91e4cf-b8d7-4cbd-938f-e377fb6913e2"), new DateTime(2024, 12, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 24, 1, 42, 40, 0, DateTimeKind.Unspecified), "We're looking for a man at an age from 55 to 65 for a main role in new TV series. The actor should have a beard and white hair.", true, false, "TV Series Casting for a man" },
                    { new Guid("7ff7f307-2277-48f8-9533-b47345f43c00"), new Guid("8b299bb7-7857-49be-b953-47d0961d6de7"), new DateTime(2024, 12, 24, 18, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 22, 1, 42, 40, 0, DateTimeKind.Unspecified), "We're looking for a man at an age from 25 to 35 for a main role in new action movie. The actor should have athletic skills.", true, false, "Casting a man for new action movie" },
                    { new Guid("cfac6138-1a01-4a9b-a3c6-e52d32640124"), new Guid("f5208d8b-a974-43ed-b8b0-54826c061a6e"), new DateTime(2024, 12, 23, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 23, 1, 42, 40, 0, DateTimeKind.Unspecified), "We're looking for a woman at an age from 18 to 26 for a role in a sports ad. The actress should know how to swim.", true, false, "Sports ad Casting for a young woman" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("01bd7e28-6449-4efc-9f1f-f70a29caaac3"), new Guid("0276d235-774d-441f-ac77-9badafc4d814") });

            migrationBuilder.DeleteData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("01bd7e28-6449-4efc-9f1f-f70a29caaac3"), new Guid("688dec9c-6a78-4769-80cc-b2281c4c7d2a") });

            migrationBuilder.DeleteData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("01bd7e28-6449-4efc-9f1f-f70a29caaac3"), new Guid("d5aa5fca-551e-4721-a332-b56a5821dd73") });

            migrationBuilder.DeleteData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("072212c8-bfb2-4179-802c-3cc46648bbdc"), new Guid("688dec9c-6a78-4769-80cc-b2281c4c7d2a") });

            migrationBuilder.DeleteData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("072212c8-bfb2-4179-802c-3cc46648bbdc"), new Guid("7f3c4a10-2f6f-4434-840b-73f135c83aca") });

            migrationBuilder.DeleteData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("0f6d3a0c-b710-4e8d-ae81-460396b39a91"), new Guid("0276d235-774d-441f-ac77-9badafc4d814") });

            migrationBuilder.DeleteData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("0f6d3a0c-b710-4e8d-ae81-460396b39a91"), new Guid("688dec9c-6a78-4769-80cc-b2281c4c7d2a") });

            migrationBuilder.DeleteData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("0f6d3a0c-b710-4e8d-ae81-460396b39a91"), new Guid("7f3c4a10-2f6f-4434-840b-73f135c83aca") });

            migrationBuilder.DeleteData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("44c54c7a-b031-404c-afd6-830dd00e7b83"), new Guid("0276d235-774d-441f-ac77-9badafc4d814") });

            migrationBuilder.DeleteData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("8141b06f-e8e8-4988-b317-c43665f74e8a"), new Guid("cbe7da20-087d-4f57-bd21-9b9af1690bc1") });

            migrationBuilder.DeleteData(
                table: "ActorsPlays",
                keyColumns: new[] { "ActorId", "PlayId" },
                keyValues: new object[] { new Guid("01bd7e28-6449-4efc-9f1f-f70a29caaac3"), new Guid("099134cb-ae73-4199-927c-9f84e1064710") });

            migrationBuilder.DeleteData(
                table: "ActorsPlays",
                keyColumns: new[] { "ActorId", "PlayId" },
                keyValues: new object[] { new Guid("01bd7e28-6449-4efc-9f1f-f70a29caaac3"), new Guid("9abd46e4-9f75-41a9-8cc3-d142997c04cf") });

            migrationBuilder.DeleteData(
                table: "ActorsPlays",
                keyColumns: new[] { "ActorId", "PlayId" },
                keyValues: new object[] { new Guid("072212c8-bfb2-4179-802c-3cc46648bbdc"), new Guid("099134cb-ae73-4199-927c-9f84e1064710") });

            migrationBuilder.DeleteData(
                table: "ActorsPlays",
                keyColumns: new[] { "ActorId", "PlayId" },
                keyValues: new object[] { new Guid("072212c8-bfb2-4179-802c-3cc46648bbdc"), new Guid("cef3172a-d9ae-41c7-834f-cd934a506b95") });

            migrationBuilder.DeleteData(
                table: "ActorsPlays",
                keyColumns: new[] { "ActorId", "PlayId" },
                keyValues: new object[] { new Guid("0f6d3a0c-b710-4e8d-ae81-460396b39a91"), new Guid("9abd46e4-9f75-41a9-8cc3-d142997c04cf") });

            migrationBuilder.DeleteData(
                table: "ActorsPlays",
                keyColumns: new[] { "ActorId", "PlayId" },
                keyValues: new object[] { new Guid("44c54c7a-b031-404c-afd6-830dd00e7b83"), new Guid("253a0612-1359-4c37-a6b2-75593ea3320e") });

            migrationBuilder.DeleteData(
                table: "ActorsPlays",
                keyColumns: new[] { "ActorId", "PlayId" },
                keyValues: new object[] { new Guid("44c54c7a-b031-404c-afd6-830dd00e7b83"), new Guid("cef3172a-d9ae-41c7-834f-cd934a506b95") });

            migrationBuilder.DeleteData(
                table: "ActorsPlays",
                keyColumns: new[] { "ActorId", "PlayId" },
                keyValues: new object[] { new Guid("8141b06f-e8e8-4988-b317-c43665f74e8a"), new Guid("099134cb-ae73-4199-927c-9f84e1064710") });

            migrationBuilder.DeleteData(
                table: "CastingAgents",
                keyColumn: "Id",
                keyValue: new Guid("b3ddcdfc-21fb-4b60-8e99-8386cea3155a"));

            migrationBuilder.DeleteData(
                table: "Castings",
                keyColumn: "Id",
                keyValue: new Guid("1c801301-f82a-4c69-aedf-8aef41afb68b"));

            migrationBuilder.DeleteData(
                table: "Castings",
                keyColumn: "Id",
                keyValue: new Guid("3f857443-4eec-42b0-9ed0-101973987ad7"));

            migrationBuilder.DeleteData(
                table: "Castings",
                keyColumn: "Id",
                keyValue: new Guid("5656965a-e13f-43d3-9754-639f3398191c"));

            migrationBuilder.DeleteData(
                table: "Castings",
                keyColumn: "Id",
                keyValue: new Guid("7ff7f307-2277-48f8-9533-b47345f43c00"));

            migrationBuilder.DeleteData(
                table: "Castings",
                keyColumn: "Id",
                keyValue: new Guid("cfac6138-1a01-4a9b-a3c6-e52d32640124"));

            migrationBuilder.DeleteData(
                table: "Plays",
                keyColumn: "Id",
                keyValue: new Guid("d49574dd-ab22-4b5c-9de6-892c09e786f3"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("01bd7e28-6449-4efc-9f1f-f70a29caaac3"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("072212c8-bfb2-4179-802c-3cc46648bbdc"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("0f6d3a0c-b710-4e8d-ae81-460396b39a91"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("44c54c7a-b031-404c-afd6-830dd00e7b83"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("8141b06f-e8e8-4988-b317-c43665f74e8a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a5faafe7-4729-4102-a2de-adf525f9d042"));

            migrationBuilder.DeleteData(
                table: "CastingAgents",
                keyColumn: "Id",
                keyValue: new Guid("8b299bb7-7857-49be-b953-47d0961d6de7"));

            migrationBuilder.DeleteData(
                table: "CastingAgents",
                keyColumn: "Id",
                keyValue: new Guid("8d91e4cf-b8d7-4cbd-938f-e377fb6913e2"));

            migrationBuilder.DeleteData(
                table: "CastingAgents",
                keyColumn: "Id",
                keyValue: new Guid("dc9a62c2-46f0-41b6-8fc2-0975dfba24bb"));

            migrationBuilder.DeleteData(
                table: "CastingAgents",
                keyColumn: "Id",
                keyValue: new Guid("f5208d8b-a974-43ed-b8b0-54826c061a6e"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("0276d235-774d-441f-ac77-9badafc4d814"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("688dec9c-6a78-4769-80cc-b2281c4c7d2a"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("7f3c4a10-2f6f-4434-840b-73f135c83aca"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("cbe7da20-087d-4f57-bd21-9b9af1690bc1"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("d5aa5fca-551e-4721-a332-b56a5821dd73"));

            migrationBuilder.DeleteData(
                table: "Plays",
                keyColumn: "Id",
                keyValue: new Guid("099134cb-ae73-4199-927c-9f84e1064710"));

            migrationBuilder.DeleteData(
                table: "Plays",
                keyColumn: "Id",
                keyValue: new Guid("253a0612-1359-4c37-a6b2-75593ea3320e"));

            migrationBuilder.DeleteData(
                table: "Plays",
                keyColumn: "Id",
                keyValue: new Guid("9abd46e4-9f75-41a9-8cc3-d142997c04cf"));

            migrationBuilder.DeleteData(
                table: "Plays",
                keyColumn: "Id",
                keyValue: new Guid("cef3172a-d9ae-41c7-834f-cd934a506b95"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00437133-5332-45a7-952e-dc8b6b740b76"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0487d986-ece3-4f68-9e3a-2d064f15a14a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0719936f-703e-4836-ade1-1d00e7225256"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("386f0ce1-1884-4c63-beb0-746bb8e73634"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("be1c5570-a3dd-444a-9d43-bc0fef22a105"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c36656b1-d6c7-4682-92fd-2b5f5c982241"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e5aeebb4-3d1b-4c8b-b19e-1ea073938b16"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9e3fa9c-ff55-4788-9085-cd00806062ec"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("efc80aaa-7890-4f3f-80c0-5a86b0afe157"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Plays",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                comment: "Description of the play",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true,
                oldComment: "Description of the play");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movies",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                comment: "Description of the movie",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true,
                oldComment: "Description of the movie");
        }
    }
}
