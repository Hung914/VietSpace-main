using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if(context.Businesses.Any()) return;

            List<Business> businesses = new()
            {
                new Business
                {
                    Name = "MCQ Supermarket",
                    Title = "Asian groceries and fresh fruit & vegetables",
                    Addresses = new List<Address>
                    {
                       new()
                       {
                           Street = "243-253 Walter Rd",
                           Suburb = "Morley",
                           PostCode = "6062",
                           State = "WA",
                       }
                    },
                    Phones = new List<Phone> {new() {Number = "0892485623", PhoneType = PhoneType.Landline}}
                },
 
                new Business
                {
                    Name = "Nam Electrical Pty Ltd",
                    Title = "Electrical & HVAC",
                    Addresses = new List<Address>
                    {
                        new()
                        {
                           Street = "243-253 Walter Rd",
                           Suburb = "Morley",
                           PostCode = "6062",
                           State = "WA",
                        }
                    },
                    Phones = new List<Phone> {new() {Number = "0412345678", PhoneType = PhoneType.Mobile}}
                },
                new Business
                {
                    Name = "CL Accountant",
                    Title = "Public Practice Services",
                    Addresses = new List<Address>
                    {
                        new()
                        {
                            Street = "Suite 4/2 west road",
                            Suburb = "Bassendean",
                            PostCode = "6054",
                            State = "WA",
                        }
                    },
                    Phones = new List<Phone> {new() {Number = "(08) 6153 0581", PhoneType = PhoneType.Landline, Description =  "Moi thac mac vui long lien he"}}
                },
                new Business
                {
                    Name = "NP Supermarket Carousel",
                    Title = "Asian groceries and fresh fruit & vegetables",
                    Addresses = new List<Address>
                    {
                        new()
                        {
                            Street = "45 Cecil Ave",
                            Suburb = "Cannington",
                            PostCode = "6107",
                            State = "WA",
                        }
                    },
                    Phones = new List<Phone> {new() {Number = "08 9358 3288", PhoneType = PhoneType.Landline}}
                },
                new Business
                {
                    Name = "Skill Handyman",
                    Title = "Nguyen Huu Hung",
                    Description = "Brick Paving, Tiling, Concrete, Soak Well",
                    Description2 = "Han hanh duoc phuc vu cho quy dong huong suot 28 nam qua.",
                    Description3 = "Lam viec tan tam, do dac va khao gia mien phi",
                    Phones = new List<Phone>
                    {
                        new() {Number = "08 927114329", PhoneType = PhoneType.Landline},
                        new() {Number = "0419 946 799", PhoneType = PhoneType.Mobile, Description = "Xin lien lac Nguyen Huu Hung"},
                        new() {Number = "0403567369", PhoneType = PhoneType.Mobile},
                    }
                },
                new Business
                {
                    Name = "LOI's CABINETS",
                    Description = "Loi's cabinet chuyen dong Nha bep, quay ruou, tu am, phong tam, phong giat",
                    Description2 = "GIA CA PHAI CHANG, RE & DEP DO & KHAO GIA MIEN PHI",
                    Addresses = new List<Address>
                    {
                        new()
                        {
                            Street = "Unit 5/13 Oxleigh Drive - Malaga WA 6090",
                            Suburb = "Malaga",
                            PostCode = "6090",
                            State = "WA",
                        }
                    },
                    Phones = new List<Phone> {new() {Number = "08 9248 4029", PhoneType = PhoneType.Landline}}
                },
                new Business
                {
                    Name = "Tiem Thuoc Bac Phuoc Loc Tho",
                    Description = "Chung toi chuyen tri: dau lung, nhuc chan, dau than kinh toa, dau khop, dau nhuc viem xuong",
                    Description2 = "Dac biet, chung toi co Sauna, xong hoi, massage da nong, cam cum ho dau dau kinh nien",
                    Addresses = new List<Address>
                    {
                        new()
                        {
                            Street = "Shop 6/26 Rudloc Road",
                            Suburb = "Morley",
                            PostCode = "6062",
                            State = "WA",
                        }
                    },
                    Phones = new List<Phone>
                    {
                        new() {Number = "08 6162 3295", PhoneType = PhoneType.Landline},
                        new() {Number = "0452 578 938", PhoneType = PhoneType.Landline},
                    }
                },
                new Business
                {
                    Name = "PHONG CHAM CUU & CHAN CHI DONG Y",
                    Title = "Bac si Nga Le",
                    Addresses = new List<Address>
                    {
                        new()
                        {
                            Street = "Shop 5A, 32 Balgonie Ave, Girrawheen WA 6064",
                            Suburb = "Girrawheen",
                            PostCode = "6064",
                            State = "WA",
                        }
                    },
                    Phones = new List<Phone> {new() {Number = "0402257599", PhoneType = PhoneType.Mobile}},
                    Emails = new List<Email> {new() {EmailAddress = "swanlehelathcare@gmail.com"}},
                    Website = "swanglecupunture.com"
                },
                new Business
                {
                    Name = "Four Seasons Curtains Manufacturing",
                    Title = "Curtains Pelmets Swags & Tails Blinds",
                    Addresses = new List<Address>
                    {
                        new()
                        {
                            Street = "Unit 2/41 Action Road, Malaga WA 6090",
                            Suburb = "Malaga",
                            PostCode = "6090",
                            State = "WA",
                        }
                    },
                    Phones = new List<Phone>
                    {
                        new() {Number = "08 9249 2897", PhoneType = PhoneType.Landline},
                        new() {Number = "0431 824 669", PhoneType = PhoneType.Mobile, Description = "Dao"},
                        new() {Number = "0422948470", PhoneType = PhoneType.Mobile, Description = "Phan"},
                    },
                    Abn = "94348619583"
                },
                new Business
                {
                    Name = "LT DENTAL",
                    Title = "PHONG MACH NHA KHOA",
                    Description2 = "Nha si LE Anh TUAN TONY",
                    Description3 = "Tot nghiep Dai Hoc Nha Khoa Tay Uc (UWA)",
                    Addresses = new List<Address>
                    {
                        new()
                        {
                            Street = "1st Floor, 445 William Street",
                            Suburb = "Perth",
                            PostCode = "6000",
                            State = "WA",
                        }
                    },
                    Phones = new List<Phone>
                    {
                        new() {Number = "9328 5027", PhoneType = PhoneType.Landline},
                    },
                    Website = "ltdental.com.au",
                    Emails = new List<Email> {new() {EmailAddress = "admin@ltdental.com.au"}}
                },
                new Business
                {
                    Name = "DANG DRIVING SCHOOL",
                    Title = "Manual And Automatic",
                    Addresses = new List<Address>
                    {
                        new()
                        {
                            Street = "",
                            Suburb = "Dianna",
                            PostCode = "6055",
                            State = "WA",
                        }
                    },
                    Phones = new List<Phone>
                    {
                        new() {Number = "0417 946 126", PhoneType = PhoneType.Mobile, Description = "Dang van duoc"},
                        new() {Number = "0424072611", PhoneType = PhoneType.Mobile, Description = "Anh Quyen"},
                    },
         
                },
                new Business
                {
                    Name = "DZUNG A SIGN",
                    Title = "Sign Making & DIGITAL PRINTING, LASER & CNC ROUTER",
                    Addresses = new List<Address>
                    {
                        new()
                        {
                            Street = "12 Lambourne RET, Mirrabooka 6061",
                            Suburb = "Mirrabooka",
                            PostCode = "6061",
                            State = "WA",
                        }
                    },
                    Phones = new List<Phone>
                    {
                        new() {Number = "0405038956", PhoneType = PhoneType.Mobile, Description = "Dung"},
                        new() {Number = "0416747356", PhoneType = PhoneType.Mobile, Description = "Mai"},
                    }
                }
            };

            await context.Businesses.AddRangeAsync(businesses);
            await context.SaveChangesAsync();
        }

        public static async Task SeedCategory(DataContext context)
        {
            if(context.Categories.Any()) return;

            List<Category> categories = new()
            {
                new Category()
                {
                    Name = "Accountants"
                },
                new Category()
                {
                    Name = "Asian Groceries & Wholesale"
                },
                new Category()
                {
                    Name = "Builders & Tradies"
                },
                new Category()
                {
                    Name = "Cars & Vehicles"
                },
                new Category()
                {
                    Name = "Childcare & Nanny"
                },
                new Category
                {
                    Name = "Lanscaping & Gardening"
                }
            };
            
            context.Categories.AddRange(categories);
            await context.SaveChangesAsync();
        }
    }
}