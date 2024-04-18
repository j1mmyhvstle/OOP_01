using Do_an_nhom;
using System.Collections;
using System.Diagnostics.Contracts;
using System.Text.Json;
using System.Xml.Serialization;
internal class Program
{   //
    //
    //
    //
    //
    //
    //
    //
    public static string filePath_BoPhan = @"D:\C#\BoPhan.txt";
    public static string filePath_NhanSu_GD = @"D:\C#\NhanSu_GD.txt";
    public static string filePath_NhanSu_TP = @"D:\C#\NhanSu_TP.txt";
    public static string filePath_NhanSu_PGD = @"D:\C#\NhanSu_PGD.txt";
    public static string filePath_NhanSu_NVF = @"D:\C#\NhanSu_NVF.txt";
    public static string filePath_NhanSu_NVP = @"D:\C#\NhanSu_NVP.txt";
    public static string filePath_NhanSu_TT = @"D:\C#\NhanSu_TT.txt";
    public static string filePath_ChuaDuyetCheckIn = @"D:\C#\ChuaDuyetCheckIn.json";
    public static string filePath_Login = @"D:\C#\Login.txt";
    public static string filePath_Noti = @"D:\C#\LichSuThongBao.txt";
    //
    //
    //
    //
    private static void Main(string[] args)
    {
        
        
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        BoPhan_List boPhan_List = new BoPhan_List();
        boPhan_List.Add(new BoPhan() { MaBP = 1, TenBP = "Kế toán", HeSoLuong = 2 });
        boPhan_List.Add(new BoPhan() { MaBP = 2, TenBP = "Nhân sự", HeSoLuong = 2 });
        boPhan_List.Add(new BoPhan() { MaBP = 3, TenBP = "Kỹ thuật", HeSoLuong = 3 });
        boPhan_List.Add(new BoPhan() { MaBP = 4, TenBP = "Tuyển Dụng", HeSoLuong = 2 });
        boPhan_List.Add(new BoPhan() { MaBP = 5, TenBP = "Dịch vụ", HeSoLuong = 2 });
        //
        //
        //
        SerializationHelper.Serialize(boPhan_List.BoPhans, filePath_BoPhan);
        SerializationHelper.Deserialize(boPhan_List.BoPhans, filePath_BoPhan);
        //
        //
        //
        NhanSu_List<GiamDoc> giamDocList = new NhanSu_List<GiamDoc>();
        giamDocList.Add(new GiamDoc()
        {
            MaNV = 1,
            HoLot = "Nguyen",
            Ten = "Van A",
            CMND = "123456789",
            GioiTinh = true,
            NgaySinh = new DateTime(1980, 5, 15),
            DiaChi = "123 Đường ABC, Quận XYZ, Thành phố HCM",
            DienThoai = "0123456789",
            MaBP = 1, // Giả sử GiamDoc thuộc bộ phận có mã là 1
            HeSoLuong = 2.5, // Giả sử hệ số lương của GiamDoc là 2.5})
            LoaiNhanVien = 5,
            LuongCoBan = 170
        });
        NhanSu_List<PhoGiamDoc> pgdList = new NhanSu_List<PhoGiamDoc>();
        pgdList.Add(new PhoGiamDoc()
        {
            MaNV = 2,
            HoLot = "Nguyen",
            Ten = "Van D",
            CMND = "0909999999",
            GioiTinh = false,
            NgaySinh = new DateTime(1999, 12, 10),
            DiaChi = "456 Đường ABC, Quận XYZ, Thành phố HCM",
            DienThoai = "0934746717",
            MaBP = 1, // Giả sử PhoGiamDoc thuộc bộ phận có mã là 1
            HeSoLuong = 2.0, // Giả sử hệ số lương của PhoGiamDoc là 2.5})
            LoaiNhanVien = 4,
            LuongCoBan = 150
        });
        NhanSu_List<TruongPhong> truongPhongList = new NhanSu_List<TruongPhong>();
        truongPhongList.Add(new TruongPhong()
        {
            MaNV = 3,
            HoLot = "Nguyen",
            Ten = "Van B",
            CMND = "012345678",
            GioiTinh = true,
            NgaySinh = new DateTime(1988, 12, 26),
            DiaChi = "456 Đường ABC, Quận XYZ, Thành phố HCM",
            DienThoai = "0787700820", // tạo khéo léo để không bị trùng, thêm hàm kiểm tra sau.
            MaBP = 1, // Giả sử TruongPhong thuộc bộ phận có mã là 1
            HeSoLuong = 1.5, // Giả sử hệ số lương của TruongPhong là 1.5})
            LoaiNhanVien = 3,
            LuongCoBan = 100
        });
        NhanSu_List<NhanVienFullTime> nvfList = new NhanSu_List<NhanVienFullTime>();
        nvfList.Add(new NhanVienFullTime()
        {
            MaNV = 4,
            HoLot = "Nguyen",
            Ten = "Van E",
            CMND = "888888888",
            GioiTinh = true,
            NgaySinh = new DateTime(1988, 12, 26),
            DiaChi = "456 Đường ABC, Quận ABC, Thành phố HCM",
            DienThoai = "01111111", // tạo khéo léo để không bị trùng, thêm hàm kiểm tra sau.
            MaBP = 1, // Giả sử NV thuộc bộ phận có mã là 1
            HeSoLuong = 1.2, // Giả sử hệ số lương của NV là 1.2})
            LoaiNhanVien = 2,
            LuongCoBan = 80
        });
        NhanSu_List<NhanVienPartTime> nvpList = new NhanSu_List<NhanVienPartTime>();
        nvpList.Add(new NhanVienPartTime()
        {
            MaNV = 5,
            HoLot = "Nguyen",
            Ten = "Van F",
            CMND = "888888828",
            GioiTinh = true,
            NgaySinh = new DateTime(1988, 12, 26),
            DiaChi = "456 Đường ABC, Quận XYZ, Thành phố HCM",
            DienThoai = "0987654321", // tạo khéo léo để không bị trùng, thêm hàm kiểm tra sau.
            MaBP = 1, // Giả sử TruongPhong thuộc bộ phận có mã là 1
            HeSoLuong = 1.0, // Giả sử hệ số lương của TruongPhong là 1.0})
            LoaiNhanVien = 1,
            LuongCoBan = 100
        });
        NhanSu_List<ThucTapSinh> ttList = new NhanSu_List<ThucTapSinh>();
        ttList.Add(new ThucTapSinh()
        {
            MaNV = 6,
            HoLot = "Nguyen",
            Ten = "Van G",
            CMND = "012345678",
            GioiTinh = true,
            NgaySinh = new DateTime(1988, 12, 26),
            DiaChi = "456 Đường ABC, Quận XYZ, Thành phố HCM",
            DienThoai = "00000000", // tạo khéo léo để không bị trùng, thêm hàm kiểm tra sau.
            MaBP = 1, // Giả sử TTS thuộc bộ phận có mã là 1
            HeSoLuong = 1.0, // Giả sử hệ số lương của TTS là 1.0})
            LoaiNhanVien = 0,
            LuongCoBan = 50
        });
        //
        //
        //
        SerializationHelper.Serialize(giamDocList.NhanSus, filePath_NhanSu_GD);
        SerializationHelper.Deserialize(giamDocList.NhanSus, filePath_NhanSu_GD);
        SerializationHelper.Serialize(truongPhongList.NhanSus, filePath_NhanSu_TP);
        SerializationHelper.Deserialize(truongPhongList.NhanSus, filePath_NhanSu_TP);
        SerializationHelper.Serialize(pgdList.NhanSus, filePath_NhanSu_PGD);
        SerializationHelper.Deserialize(pgdList.NhanSus, filePath_NhanSu_PGD);
        SerializationHelper.Serialize(nvfList.NhanSus, filePath_NhanSu_NVF);
        SerializationHelper.Deserialize(nvfList.NhanSus, filePath_NhanSu_NVF);
        SerializationHelper.Serialize(nvpList.NhanSus, filePath_NhanSu_NVP);
        SerializationHelper.Deserialize(nvpList.NhanSus, filePath_NhanSu_NVP);
        SerializationHelper.Serialize(ttList.NhanSus, filePath_NhanSu_TT);
        SerializationHelper.Deserialize(ttList.NhanSus, filePath_NhanSu_TT);
        //
        //
        //
        Login_List login_List = new Login_List();
        login_List.Add(new Login() { Username = "Admin", Password = "1234" });
        login_List.Add(new Login() { Username = "Employee", Password = "123" });
        SerializationHelper.Serialize(login_List.logins, filePath_Login);
        //
        //
        //
         void Remove<T>(List<T> list, string filepath, T RemoveItem)
        {
            SerializationHelper.Deserialize(list, filepath);
            File.Delete(filepath);
            bool exists = list.Contains(RemoveItem);
            if (exists)
            {
                list.Remove(RemoveItem);
            }
            else
            {
                Console.WriteLine("Không tìm thấy thông tin cần xóa.");
            }
            SerializationHelper.Serialize(list, filepath);
        }
        //
        //
        //

        string Username;
        string Password;
        while (true)
        {
            Console.WriteLine("--- CHƯƠNG TRÌNH CHẤM CÔNG --- ");
            Console.WriteLine("\n      --- ĐĂNG NHẬP --- ");
            Console.Write("Username: ");
            Username = Console.ReadLine();
            Console.Write("Password: ");
            Password = Console.ReadLine();
            SerializationHelper.Deserialize(login_List.logins, filePath_Login);
            bool isLoggedIn = false;
            foreach (Login login in login_List.logins)
            {
                if (login.Username == Username && login.Password == Password)
                {
                    isLoggedIn = true;
                    break;
                }
            }
            if (isLoggedIn)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Đăng nhập thành công!");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            }
            else
            {
                Console.WriteLine("Tên người dùng hoặc mật khẩu không chính xác. Đăng nhập thất bại.");
            }
        }
        while (true)
        {
            Console.WriteLine(@"--- CHƯƠNG TRÌNH CHẤM CÔNG --- " +
                                "\n1. Check-In" +
                                "\n2. Check-Out" +
                                "\n3. Duyệt nhân sự" +
                                "\n4. Tính lương nhân sự" +
                                "\n5. Xóa nhân sự" +
                                "\n6. Thông báo" +
                                "\n7. Thoát");
            string choice = Console.ReadLine();
            switch(choice)
            {
                case "1":
                {
                    Console.Write("Nhập số điện thoại: ");
                    string phoneNumber = Console.ReadLine();
                    Console.Write("Nhập loại nhân viên (5: GiamDoc, 4: PhoGiamDoc, 3: TruongPhong, 2: NhanVienFullTime, 1: NhanVienParttime, 0: Thuc Tap Sinh): ");
                    int loaiNV = int.Parse(Console.ReadLine());
                    DateTime checkIn = DateTime.Now;
                        if (loaiNV == giamDocList.NhanSus[0].LoaiNhanVien)
                        {
                            giamDocList.CheckIn(phoneNumber, loaiNV, checkIn);
                        }
                        else if (loaiNV == truongPhongList.NhanSus[0].LoaiNhanVien)
                        {
                            truongPhongList.CheckIn(phoneNumber, loaiNV, checkIn);
                        } // thêm nhiều loại nhân viên khác
                        else if (loaiNV == pgdList.NhanSus[0].LoaiNhanVien)
                        {
                            pgdList.CheckIn(phoneNumber, loaiNV, checkIn);
                        }
                        else if (loaiNV == nvfList.NhanSus[0].LoaiNhanVien)
                        {
                            nvfList.CheckIn(phoneNumber, loaiNV, checkIn);
                        }
                        else if (loaiNV == nvpList.NhanSus[0].LoaiNhanVien)
                        {
                            nvpList.CheckIn(phoneNumber, loaiNV, checkIn);
                        }
                        else if (loaiNV == ttList.NhanSus[0].LoaiNhanVien)
                        {
                            ttList.CheckIn(phoneNumber, loaiNV, checkIn);
                        }
                    break;
                }
                case "2":
                {
                    Console.Write("Nhập số điện thoại: ");
                    string phoneNumber = Console.ReadLine();
                    Console.Write("Nhập loại nhân viên (5: GiamDoc, 4: PhoGiamDoc, 3: TruongPhong, 2: NhanVienFullTime, 1: NhanVienParttime, 0: Thuc Tap Sinh): ");
                    int loaiNV = int.Parse(Console.ReadLine());
                    DateTime checkOut = DateTime.Now;
                        if (loaiNV == giamDocList.NhanSus[0].LoaiNhanVien)
                        {
                            giamDocList.CheckOut(phoneNumber, checkOut);
                        }
                        else if (loaiNV == truongPhongList.NhanSus[0].LoaiNhanVien)
                        {
                            truongPhongList.CheckOut(phoneNumber, checkOut);
                        } // thêm nhiều loại nhân viên khác
                        else if (loaiNV == pgdList.NhanSus[0].LoaiNhanVien)
                        {
                            pgdList.CheckOut(phoneNumber, checkOut);
                        }
                        else if (loaiNV == nvfList.NhanSus[0].LoaiNhanVien)
                        {
                            nvfList.CheckOut(phoneNumber, checkOut);
                        }
                        else if (loaiNV == nvpList.NhanSus[0].LoaiNhanVien)
                        {
                            nvpList.CheckOut(phoneNumber, checkOut);
                        }
                        else if (loaiNV == ttList.NhanSus[0].LoaiNhanVien)
                        {
                            ttList.CheckOut(phoneNumber, checkOut);
                        }
                        break;
                }
                case "4":
                {
                    Console.Write("Nhập số điện thoại: ");
                    string phoneNumber = Console.ReadLine();
                    Console.Write("Nhập loại nhân viên (5: GiamDoc, 4: PhoGiamDoc, 3: TruongPhong, 2: NhanVienFullTime, 1: NhanVienParttime, 0: Thuc Tap Sinh): ");
                    int loaiNV = int.Parse(Console.ReadLine());
                        if (loaiNV == giamDocList.NhanSus[0].LoaiNhanVien)
                        {
                            giamDocList.TinhLuong(phoneNumber, loaiNV);
                        }
                        else if (loaiNV == truongPhongList.NhanSus[0].LoaiNhanVien)
                        {
                            truongPhongList.TinhLuong(phoneNumber, loaiNV);
                        } // thêm nhiều loại nhân viên khác
                        else if (loaiNV == pgdList.NhanSus[0].LoaiNhanVien)
                        {
                            pgdList.TinhLuong(phoneNumber, loaiNV);
                        }
                        else if (loaiNV == nvfList.NhanSus[0].LoaiNhanVien)
                        {
                            nvfList.TinhLuong(phoneNumber, loaiNV);
                        }
                        else if (loaiNV == nvpList.NhanSus[0].LoaiNhanVien)
                        {
                            nvpList.TinhLuong(phoneNumber, loaiNV);
                        }
                        else if (loaiNV == ttList.NhanSus[0].LoaiNhanVien)
                        {
                            ttList.TinhLuong(phoneNumber, loaiNV);
                        }
                        break;
                    }
                case "3":
                    if (Username == "Admin")
                    {
                        string filePathInput = $"D:\\C#\\ChuaDuyetChamCong_{DateTime.Now:yyyyMMdd}.json";

                        try
                        {
                            // Kiểm tra xem tệp tin có tồn tại không
                            if (File.Exists(filePathInput))
                            {
                                // Đọc toàn bộ nội dung từ tệp tin
                                string fileContent = File.ReadAllText(filePathInput);

                                // Deserializing thành một dictionary
                                Dictionary<string, Dictionary<string, string>> chamCongList = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(fileContent);

                                // In ra danh sách nhân viên chưa duyệt
                                Console.WriteLine("Danh sách nhân viên chưa duyệt chấm công:");
                                foreach (KeyValuePair<string, Dictionary<string, string>> entry in chamCongList)
                                {
                                    Console.WriteLine($"Số điện thoại: {entry.Key}");
                                    foreach (KeyValuePair<string, string> kvp in entry.Value)
                                    {
                                        Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                                    }
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Tệp tin không tồn tại.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
                        }

                        {
                            Console.Write("Nhập số điện thoại của nhân viên cần duyệt:");
                            string phoneNumber = Console.ReadLine();
                            Console.Write("Nhập loại nhân viên (5: GiamDoc, 4: PhoGiamDoc, 3: TruongPhong, 2: NhanVienFullTime, 1: NhanVienParttime, 0: Thuc Tap Sinh): ");
                            int loaiNV = int.Parse(Console.ReadLine());
                            DateTime checkIn = DateTime.Now;
                            if (loaiNV == giamDocList.NhanSus[0].LoaiNhanVien)
                            {
                                giamDocList.DuyetCheckIn(phoneNumber, loaiNV, checkIn);
                            }
                            else if (loaiNV == truongPhongList.NhanSus[0].LoaiNhanVien)
                            {
                                truongPhongList.DuyetCheckIn(phoneNumber, loaiNV, checkIn);
                            }
                            else if (loaiNV == pgdList.NhanSus[0].LoaiNhanVien)
                            {
                                pgdList.DuyetCheckIn(phoneNumber, loaiNV, checkIn);
                            }
                            else if (loaiNV == nvfList.NhanSus[0].LoaiNhanVien)
                            {
                                nvfList.DuyetCheckIn(phoneNumber, loaiNV, checkIn);
                            }
                            else if (loaiNV == nvpList.NhanSus[0].LoaiNhanVien)
                            {
                                nvpList.DuyetCheckIn(phoneNumber, loaiNV, checkIn);
                            }
                            else if (loaiNV == ttList.NhanSus[0].LoaiNhanVien)
                            {
                                ttList.DuyetCheckIn(phoneNumber, loaiNV, checkIn);
                            }
                           
                        }
                    }
                    else { Console.WriteLine("Bạn không có quyền xử lý chấm công");}
                    break;

                case "5":
                    {
                        if (Username == "Admin")
                        {
                            Console.WriteLine("Nhập loại nhân viên (5: GiamDoc, 4: PhoGiamDoc, 3: TruongPhong, 2: NhanVienFullTime, 1: NhanVienParttime, 0: Thuc Tap Sinh): ");
                            string type = Console.ReadLine();
                            switch (type)
                            {
                                case "0":
                                    {
                                        try
                                        {
                                            Console.WriteLine("Nhập mã nhân viên cần xóa ");
                                            ThucTapSinh Manv = new ThucTapSinh { MaNV = Convert.ToInt32(Console.ReadLine()) };
                                            Remove(ttList.NhanSus, filePath_NhanSu_TT, Manv);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine($"{ex.Message}");
                                        }
                                        break;
                                    }
                                case "1":
                                    {
                                        try
                                        {
                                            Console.WriteLine("Nhập mã nhân viên cần xóa");
                                            NhanVienPartTime Manv = new NhanVienPartTime { MaNV = Convert.ToInt32(Console.ReadLine()) };
                                            Remove(nvpList.NhanSus, filePath_NhanSu_NVP, Manv);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine($"{ex.Message}");
                                        }
                                        break;
                                    }
                                case "2":
                                    {
                                        try
                                        {
                                            Console.WriteLine("Nhập mã nhân viên cần xóa");
                                            NhanVienFullTime Manv = new NhanVienFullTime { MaNV = Convert.ToInt32(Console.ReadLine()) };
                                            Remove(nvfList.NhanSus, filePath_NhanSu_NVF, Manv);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine($"{ex.Message}");
                                        }
                                        break;
                                    }
                                case "3":
                                    {
                                        try
                                        {
                                            Console.WriteLine("Nhập mã nhân viên cần xóa");
                                            TruongPhong Manv = new TruongPhong { MaNV = Convert.ToInt32(Console.ReadLine()) };
                                            Remove(truongPhongList.NhanSus, filePath_NhanSu_TP, Manv);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine($"{ex.Message}");
                                        }
                                        break;
                                    }
                                case "4":
                                    {
                                        try
                                        {
                                            Console.WriteLine("Nhập mã nhân viên cần xóa");
                                            PhoGiamDoc Manv = new PhoGiamDoc { MaNV = Convert.ToInt32(Console.ReadLine()) };
                                            Remove(pgdList.NhanSus, filePath_NhanSu_PGD, Manv);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine($"{ex.Message}");
                                        }
                                        break;
                                    }
                                case "5":
                                    {
                                        try
                                        {
                                            Console.WriteLine("Nhập mã nhân viên cần xóa");
                                            GiamDoc Manv = new GiamDoc { MaNV = Convert.ToInt32(Console.ReadLine()) };
                                            Remove(giamDocList.NhanSus, filePath_NhanSu_GD, Manv);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine($"{ex.Message}");
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Bạn không được cấp quyền để tiến hành hành động này.");
                        }
                        break;
                    }
                case "6":
                    {
                        if (Username == "Admin") // quản lý
                        {
                            Console.WriteLine("1. Xem thông báo");
                            Console.WriteLine("2. Thêm thông báo");
                            string notificationChoice = Console.ReadLine();
                            switch (notificationChoice)
                            {
                                case "1":
                                {
                                    List<Notification> notifications = new List<Notification>();
                                    SerializationHelper.Deserialize(notifications, filePath_Noti);
                                    foreach (Notification notification in notifications)
                                    {
                                        notification.ShowNotification();
                                    }
                                    break;
                                }
                                case "2":
                                {
                                    // Thêm thông báo
                                    Console.Write("Nhập thông báo: ");
                                    string message = Console.ReadLine();
                                    Notification newNotification = new Notification(message, DateTime.Now);
                                    newNotification.SaveNotification(newNotification, filePath_Noti);
                                    Console.WriteLine("Thông báo đã được thêm.");
                                    break;
                                }
                                default:
                                {
                                    Console.WriteLine("Lựa chọn không hợp lệ.");
                                    break;
                                }
                            }
                        }
                        else
                        {
                            // Nhân viên
                            List<Notification> notifications = new List<Notification>();
                            SerializationHelper.Deserialize(notifications, filePath_Noti);
                            foreach (Notification notification in notifications)
                            {
                                Console.WriteLine($"Thông báo: {notification.Message} vào lúc {notification.Time}");
                            }
                        }
                        break;
                    }
                case "7":
                {
                    return;
                }
                default:
                {
                    Console.WriteLine("Đây không phải là một lựa chọn !");
                    break;
                }
            }
        }
    }
}