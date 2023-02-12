using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HovLibrary
{
    internal class Helper
    {
        public static employee checkLogin(string email, string password, HovLibraryDatabaseDataContext db)
        {
            return (
                from employee in db.employees 
                where employee.email == email 
                && employee.password == sha256_hash(password) 
                && employee.deleted_at == null
                select employee
                ).FirstOrDefault();
        }

        public static string sha256_hash(string password)
        {
            StringBuilder result = new StringBuilder();
            using(var hasher = SHA256.Create()) {
                foreach (var keyword in hasher.ComputeHash(Encoding.UTF8.GetBytes(password))) {
                    result.Append(keyword.ToString("X2"));
                }
            }
            return result.ToString();
        }

        public static Regex email_regex = new Regex(@"^[a-zA-Z0-9.]+@[a-zA-Z]+.[a-zA-Z]+$", RegexOptions.IgnoreCase);
        public static Regex letter_regex = new Regex(@"^[a-zA-Z][a-zA-Z ]+$", RegexOptions.IgnoreCase);
        public static Regex number_regex = new Regex(@"^[0-9]+$", RegexOptions.IgnoreCase);
        public static Regex ratings_regex = new Regex(@"^[0-9](.[0-9])*[0-9]*\(?[0-9]*\)?$", RegexOptions.IgnoreCase);
        public class books
        {
            public int id { get; set; }
            public string language { get; set; }
            public string title { get; set; }
            public string isbn { get; set; }
            public string isbn13 { get; set; }
            public string authors { get; set; }
            public string publisher { get; set; }
            public DateTime publish_date { get; set; }
            public int page_count { get; set; }
            public string ratings { get; set; }
        }
        public class borrow
        {
            public int id { get; set; }
            public string memberName { get; set; }
            public string bookTitle { get; set; }
            public string bookCode { get; set; }
            public DateTime? borrowDate { get; set; }
            public DateTime? returnDate { get; set; }
            public int fine { get; set; }
        }
    }
}
