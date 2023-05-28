using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        public static string UserNotFound { get; set; } = "Kullanıcı Bulunamadı.";
        public static string PasswordError { get; set; } = "Parola Hatalı.";
        public static string SuccessfulLogin { get; set; } = "Kullanıcı girişi başarılı.";
        public static string UserAlreadyExists { get; set; } = "Kullanıcı zaten mevcut.";
        public static string AccessTokenCreated { get; set; } = "Access token oluşturuldu.";
        public static string InvalidRefreshToken { get; set; } = "Refresh token geçersiz.";
        public static string TokenExpired { get; set; } = "Token süresi dolmuş.";
    }
}
