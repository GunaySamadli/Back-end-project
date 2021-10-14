using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Model
{
    public class Setting
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 100)]
        public string HeaderLogo { get; set; }
        [StringLength(maximumLength: 100)]
        public string FooterLogo { get; set; }
        [StringLength(maximumLength: 100)]
        public string Fb { get; set; }
        [StringLength(maximumLength: 50)]
        public string Twitter { get; set; }
        [StringLength(maximumLength: 50)]
        public string Insta { get; set; }
        [StringLength(maximumLength: 50)]
        public string Dribble{ get; set; }
        [StringLength(maximumLength: 50)]
        public string Location { get; set; }
        [StringLength(maximumLength: 50)]
        public string PhoneIcon { get; set; }
        [StringLength(maximumLength: 50)]
        public string MailIcon { get; set; }
        [StringLength(maximumLength: 250)]
        public string FooterDesc { get; set; }
        [StringLength(maximumLength: 100)]
        public string Adress { get; set; }
        [StringLength(maximumLength: 50)]
        public string ContactMail { get; set; }
        [StringLength(maximumLength: 50)]
        public string SupportMail { get; set; }
        [StringLength(maximumLength: 150)]
        public string AboutImage { get; set; }
        [StringLength(maximumLength: 150)]
        public string ServiceImage { get; set; }
        [StringLength(maximumLength: 50)]
        public string AboutTitle { get; set; }
        [StringLength(maximumLength: 250)]
        public string AboutDesc { get; set; }
        [StringLength(maximumLength: 150)]
        public string AboutSubDesc { get; set; }
        [StringLength(maximumLength: 30)]
        public string AboutUrlText { get; set; }
        [StringLength(maximumLength: 100)]
        public string AboutUrl { get; set; }
        [StringLength(maximumLength: 150)]
        public string CopyRight { get; set; }
        [StringLength(maximumLength: 150)]
        public string FbUrl { get; set; }
        [StringLength(maximumLength: 150)]
        public string InstaUrl { get; set; }
        [StringLength(maximumLength: 150)]
        public string DribbleUrl { get; set; }
        [StringLength(maximumLength: 150)]
        public string TwitterUrl { get; set; }
        [StringLength(maximumLength: 150)]
        public string HomePageImg { get; set; }
        [StringLength(maximumLength: 30)]
        public string Phone { get; set; }

        [NotMapped]
        public IFormFile HeaderImgFile { get; set; }
        [NotMapped]
        public IFormFile FooterImgFile { get; set; }
        [NotMapped]
        public IFormFile AboutImgFile { get; set; }
        [NotMapped]
        public IFormFile ServiceImgFile { get; set; }
        [NotMapped]
        public IFormFile VideoFile { get; set; }
    }
}
