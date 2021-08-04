﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ArtGalleryWebsite.Models.Queries;
using ArtGalleryWebsite.Utils;
using Newtonsoft.Json;

namespace ArtGalleryWebsite
{
    public class Icon
    {
        public string id;
        public string src;
        public string alt;
        public string href;
        public string creditRef;
        public string author;

        public Icon(string id, string src, string alt, string href, string creditRef, string author)
        {
            this.id = id;
            this.src = src;
            this.alt = alt;
            this.href = href;
            this.creditRef = creditRef;
            this.author = author;
        }
    }

    public class Save
    {
        public string id;
        public string title;
        public int pinNo;
        public int updatedAt;
        public string href;
        public SavedArt[] arts;

        public Save(string id, string title, int pinNo, int updatedAt, string href, SavedArt[] arts)
        {
            this.id = id;
            this.title = title;
            this.pinNo = pinNo;
            this.updatedAt = updatedAt;
            this.href = href;
            this.arts = arts;
        }
    }

    public class SavedArt
    {
        public string id;
        public string imageSrc;
        public string title;

        public SavedArt(string id, string imageSrc, string title)
        {
            this.id = id;
            this.imageSrc = imageSrc;
            this.title = title;
        }
    }

    public class Profile
    {
        public string name;
        public string username;
        public int following;
        public string avatarUrl;
        public string profileUrl;

        public Profile(string name, string username, int following, string avatarUrl, string profileUrl)
        {
            this.name = name;
            this.username = username;
            this.following = following;
            this.avatarUrl = avatarUrl;
            this.profileUrl = profileUrl;
        }
    }
    //Stub class
    public class AuthorTest
    {
        public string id;
        public string name;
        public string avatarUrl;

        public AuthorTest(string id, string name, string avatarUrl)
        {
            this.id = id;
            this.name = name;
            this.avatarUrl = avatarUrl;
        }
    }

    public class ArtTest
    {
        public string id;
        public string imageSrc;
        public double price;
        public string title;
        public AuthorTest author;

        public ArtTest(string id, string imageSrc, double price, string title, AuthorTest author)
        {
            this.id = id;
            this.imageSrc = imageSrc;
            this.price = price;
            this.title = title;
            this.author = author;
        }
    }

    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Profile profile = new Profile("Liana Ling", "lianaling", 4444, "https://avatars.githubusercontent.com/u/68136684?v=4", "/");

            Icon[] icons =
           {
                new Icon("icon_0001", "https://img.icons8.com/material/24/000000/pencil--v1.png", "Edit Icon", "/", "https://icons8.com/icon/5824/pencil", "Icons8"),
                new Icon("icon_0002", "https://img.icons8.com/material-rounded/24/000000/share.png", "Share Icon", "/", "https://icons8.com/icon/83213/share", "Icons8"),
                new Icon("icon_0003", "https://img.icons8.com/material-outlined/24/000000/settings--v1.png", "Settings Icon", "/", "https://icons8.com/icon/82535/settings", "Icons8"),
                new Icon("icon_0004", "https://img.icons8.com/material-rounded/24/000000/add.png", "Add Icon", "/", "https://icons8.com/icon/85096/add", "Icons8"),
            };

            //SavedArt[] savedArts1 =
            //{
            //    new SavedArt("svart_0001", "https://i.pinimg.com/originals/da/68/e7/da68e7f731bfd78e20dba0ead711ca99.jpg", "The Weasleys"),
            //    new SavedArt("svart_0002", "https://i.pinimg.com/564x/dc/c6/7e/dcc67ed0107da71b834615d48421efa4.jpg", "Still Life with Flowers in a Glass Vase"),
            //    new SavedArt("svart_0002", "https://i.pinimg.com/564x/2b/af/63/2baf63ece32d100cec72010f60eab476.jpg", "A Wheatfield, with Cypresses"),
            //};

            //SavedArt[] savedArts2 =
            //{
            //    // new SavedArt("svart_0001", "https://i.pinimg.com/originals/da/68/e7/da68e7f731bfd78e20dba0ead711ca99.jpg", "The Weasleys"),
            //};

            //Save[] saves =
            //{
            //    new Save("save_0001", "My saves", savedArts1.Length, 9, "/", savedArts1),
            //    new Save("save_0002", "Harry Potter", savedArts2.Length, 0, "/", savedArts2),
            //};

            //AuthorTest Liana = new AuthorTest("aut_0001", "Liana Ling", "https://avatars.githubusercontent.com/u/68136684?s=64&v=4");
            //AuthorTest Marcus = new AuthorTest("aut_0002", "Marcus Lee", "https://avatars.githubusercontent.com/u/59773847?s=64&v=4");

            //ArtTest[] arts =
            //{
            //    new ArtTest("art_0001", "https://i.pinimg.com/564x/2b/af/63/2baf63ece32d100cec72010f60eab476.jpg", 19000.00, "Still Life with Flowers in a Glass Vase", author: Liana),
            //    new ArtTest("art_0002", "https://i.pinimg.com/564x/dc/c6/7e/dcc67ed0107da71b834615d48421efa4.jpg", 11234.45, "A Wheatfield, with Cypresses A Wheatfield, with Cypresses", author: Marcus),
            //    new ArtTest("art_0003", "https://i.pinimg.com/564x/07/c2/8d/07c28d60e58e30929ac337e25f4ce789.jpg", 11111.55, "A Wheatfield, with Cypresses", author: Liana),
            //    new ArtTest("art_0004", "https://i.pinimg.com/564x/96/cf/e4/96cfe4e8603f47121e6adf9282b3f7c8.jpg", 11111.11, "A Wheatfield, with Cypresses", author: Marcus),
            //    new ArtTest("art_0005", "https://i.pinimg.com/564x/bb/37/b1/bb37b1b877e56726b137a387444ba33d.jpg", 55555.55, "A Wheatfield, with Cypresses A Wheatfield, with Cypresses A Wheatfield, with Cypresses", author: Liana),
            //    new ArtTest("art_0006", "https://i.pinimg.com/564x/61/a9/8d/61a98d0f1c64a093a6707b82395afa58.jpg", 88888.88, "A Wheatfield, with Cypresses", author: Marcus),
            //    new ArtTest("art_0007", "https://i.pinimg.com/564x/1a/86/56/1a865603d9cb21e1f8f8b947c1df4e80.jpg", 90099.99, "A Wheatfield, with Cypresses", author: Liana),
            //    new ArtTest("art_0008", "https://i.pinimg.com/564x/3d/dd/3f/3ddd3fa8fe1ae75133c877406abe280f.jpg", 22222.22, "A Wheatfield, with Cypresses", author: Marcus),
            //    new ArtTest("art_0009", "https://i.pinimg.com/564x/b9/92/49/b99249c860d9b507251991d063a245b4.jpg", 33333.33, "A Wheatfield, with Cypresses", author: Liana),
            //};

            FavQuery.FetchCurrentUser(1);
            UserQuery.FetchCurrentUser(1);
            List<FavQuery> data = Database.Select<FavQuery>(FavQuery.SqlQuery);
            List<UserQuery> user = Database.Select<UserQuery>(UserQuery.SqlQuery);

            //Page.ClientScript.RegisterHiddenField("profileState", JsonConvert.SerializeObject(profile));
            //Page.ClientScript.RegisterHiddenField("savesState", JsonConvert.SerializeObject(saves));
            //Page.ClientScript.RegisterHiddenField("artsState", JsonConvert.SerializeObject(arts));

            Page.ClientScript.RegisterHiddenField("iconsState", JsonConvert.SerializeObject(icons));
            Page.ClientScript.RegisterHiddenField("state", JsonConvert.SerializeObject(data));
            Page.ClientScript.RegisterHiddenField("userState", JsonConvert.SerializeObject(user));
        }

    }

}