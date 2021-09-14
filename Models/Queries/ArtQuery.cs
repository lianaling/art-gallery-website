﻿using System;
using System.Data.SqlClient;
using ArtGalleryWebsite.Utils;

namespace ArtGalleryWebsite.Models.Queries
{
    public class ArtQuery : ISqlParser
    {
        public static string SqlQuery = @"
            SELECT [Art].id, [Art].style, [Art].description, [Art].price, [Art].stock, [Art].likes, [Art].url,
                   [Author].id, [Author].description, [Author].verified, [User].Username, [User].Name, [User].Ic, [User].Dob, [User].PhoneNumber, [User].Email, [User].AvatarUrl
            FROM [Art], [Author], [User]
            WHERE [Art].author_id = [Author].id
            AND [Author].id = [User].AuthorId
            ORDER BY [Art].likes DESC;
        ";

        public int id { get; set; }
        public string style { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public int stock { get; set; }
        public int likes { get; set; }
        public string url { get; set; }
        public Author author { get; set; }

        public class Author
        {
            public int id { get; set; }
            public string description { get; set; }
            public bool verified { get; set; }
            public string username { get; set; }
            public string name { get; set; }
            public string ic { get; set; }
            public Nullable<DateTime> dob { get; set; }
            public string contactNo { get; set; }
            public string email { get; set; }
            public string avatarUrl { get; set; }

            public Author() { }

            public Author(int id, string description, bool verified)
            {                
                this.id = id;
                this.description = description;
                this.verified = verified;
            }


            public Author(int id, string description, bool verified, string username, string name, string ic, DateTime? dob, string contactNo, string email, string avatarUrl)
            {
                this.id = id;
                this.description = description;
                this.verified = verified;
                this.username = username;
                this.name = name;
                this.ic = ic;
                this.dob = dob;
                this.contactNo = contactNo;
                this.email = email;
                this.avatarUrl = avatarUrl;
            }
        }

        public ArtQuery() {}

        public ArtQuery(int id, string style, string description, decimal price, int stock, int likes, string url, Author author)
        {
            this.id = id;
            this.style = style;
            this.description = description;
            this.price = price;
            this.stock = stock;
            this.likes = likes;
            this.url = url;
            this.author = author;
        }
        
        public static void FetchAllArt()
        {
            SqlQuery = @"
            SELECT [Art].id, [Art].style, [Art].description, [Art].price, [Art].stock, [Art].likes, [Art].url,
                   [Author].id, [Author].description, [Author].verified, [User].Username, [User].Name, [User].Ic, [User].Dob, [User].PhoneNumber, [User].Email, [User].AvatarUrl
            FROM [Art], [Author], [User]
            WHERE [Art].author_id = [Author].id
            AND [Author].id = [User].AuthorId
            ORDER BY [Art].likes DESC;
        ";
        }

        public static void FetchCurrentArtDetail(int id)
        {
            SqlQuery = $@"
            SELECT [Art].id, [Art].style, [Art].description, [Art].price, [Art].stock, [Art].likes, [Art].url,
                   [Author].id, [Author].description, [Author].verified, [User].Username, [User].Name, [User].Ic, [User].Dob, [User].PhoneNumber, [User].Email, [User].AvatarUrl
            FROM [Art], [Author], [User]
            WHERE [Art].author_id = [Author].id
            AND [Author].id = [User].AuthorId
            AND [Art].id = {id};";
        }

        public ISqlParser ParseFromSqlReader(SqlDataReader reader)
        {
            return new ArtQuery(
                reader.GetInt32(0),
                reader.GetStringOrNull(1),
                reader.GetStringOrNull(2),
                reader.GetDecimal(3),
                reader.GetInt32(4),
                reader.GetInt32(5),
                reader.GetStringOrNull(6),
                new Author(
                    reader.GetInt32(7),
                    reader.GetStringOrNull(8),
                    reader.GetBoolean(9),
                    reader.GetStringOrNull(10),
                    reader.GetStringOrNull(11),
                    reader.GetStringOrNull(12),
                    reader.GetDateTimeOrNull(13),
                    reader.GetStringOrNull(14),
                    reader.GetStringOrNull(15),
                    reader.GetStringOrNull(16)
                )
            );
        }
    }
}