using System;

namespace GiaiPhuongTrinhBacHai
{
    // Lớp giải phương trình bậc hai
    class PhuongTrinhBacHai
    {
        // Thuộc tính: hệ số của phương trình
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        // Constructor để khởi tạo hệ số
        public PhuongTrinhBacHai(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        // Phương thức giải phương trình và trả về nghiệm
        public double[] Giai()
        {
            double delta = B * B - 4 * A * C; // Tính discriminant (delta)

            if (A == 0)
            {
                // Xử lý phương trình bậc nhất hoặc không hợp lệ
                if (B != 0)
                {
                    return new double[] { -C / B }; // Phương trình bậc nhất
                }
                else
                {
                    return new double[] { }; // Không có nghiệm
                }
            }

            if (delta > 0)
            {
                // Hai nghiệm phân biệt
                double nghiem1 = (-B + Math.Sqrt(delta)) / (2 * A);
                double nghiem2 = (-B - Math.Sqrt(delta)) / (2 * A);
                return new double[] { nghiem1, nghiem2 };
            }
            else if (delta == 0)
            {
                // Nghiệm kép
                double nghiemKep = -B / (2 * A);
                return new double[] { nghiemKep };
            }
            else
            {
                // Không có nghiệm thực
                return new double[] { };
            }
        }
    }

    // Lớp hiển thị kết quả
    class HienThiKetQua
    {
        // Phương thức hiển thị kết quả
        public void XuatKetQua(PhuongTrinhBacHai pt)
        {
            double[] nghiem = pt.Giai();

            Console.WriteLine($"Phương trình: {pt.A}x^2 + {pt.B}x + {pt.C} = 0");

            if (nghiem.Length == 0)
            {
                Console.WriteLine("Không có nghiệm thực.");
            }
            else if (nghiem.Length == 1)
            {
                Console.WriteLine($"Phương trình có một nghiệm: x = {nghiem[0]}");
            }
            else
            {
                Console.WriteLine($"Phương trình có hai nghiệm: x1 = {nghiem[0]}, x2 = {nghiem[1]}");
            }
        }
    }

    // Lớp chương trình chính
    class ChuongTrinh
    {
        static void Main(string[] args)
        {
            // Nhập hệ số từ người dùng
            Console.WriteLine("Nhập các hệ số cho phương trình bậc hai (Ax^2 + Bx + C = 0):");
            Console.Write("A: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("B: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("C: ");
            double c = Convert.ToDouble(Console.ReadLine());

            // Tạo đối tượng PhuongTrinhBacHai
            PhuongTrinhBacHai pt = new PhuongTrinhBacHai(a, b, c);

            // Tạo đối tượng HienThiKetQua
            HienThiKetQua hienThi = new HienThiKetQua();

            // Hiển thị kết quả
            hienThi.XuatKetQua(pt);
        }
    }
}
