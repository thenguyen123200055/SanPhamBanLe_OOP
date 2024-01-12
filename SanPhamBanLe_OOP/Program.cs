using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuahangbanle
{
    class SanPham
    {
        private string _ten;
        private double _giaMua;

        public SanPham() { }
        public SanPham(string _ten, double _giaMua)
        {
            this._ten = _ten;
            this._giaMua = _giaMua;
        }
        public string Ten
        {
            get { return _ten; }
            set { _ten = value; }
        }
        public double GiaMua
        {
            get { return _giaMua; }
            set
            {
                if (value >= 0)
                    _giaMua = value;
            }

        }
        public virtual double TinhGiaBan()
        {
            return 0;
        }
        public virtual string InChiTiet()
        {
            return _ten;
        }
        public virtual void Nhap()
        {
            Console.WriteLine("Cho biet ten san pham");
            _ten = Console.ReadLine();
            Console.WriteLine("Cho biet gia mua");
            _giaMua = double.Parse(Console.ReadLine());
        }


        class Socola : SanPham
        {
            private double _loinhuan;
            public Socola() : base() { }
            public Socola(string ten, double giamua) : base(ten, giamua)
            {
                _loinhuan = giamua * 0.2;
            }
            public override double TinhGiaBan()
            {
                return GiaMua + _loinhuan;
            }
            public override string InChiTiet()
            {
                return string.Format("Ten: {0}- Gia Ban:{1:#,##0}", Ten, TinhGiaBan());
            }


            public override void Nhap()
            {
                base.Nhap();
                _loinhuan = GiaMua * 0.2;
            }
            class NuocUong : SanPham
            {
                private double _loinhuan;
                private double _ChiPhiGiuLanh;




                public NuocUong() : base() { }
                public NuocUong(string ten, double giamua) : base(ten, giamua)
                {
                    _loinhuan = GiaMua * 0.15;
                    _ChiPhiGiuLanh = GiaMua * 0.1;
                }
                public override double TinhGiaBan()
                {
                    return GiaMua + _loinhuan + _ChiPhiGiuLanh;
                }
                public override string InChiTiet()
                {
                    return string.Format("Ten: {0}- Gia Ban:{1:#,##0}", Ten, TinhGiaBan());
                }
                public override void Nhap()
                {
                    base.Nhap();
                    _loinhuan = GiaMua * 0.2;
                }
                class QuanLySanPham
                {
                    private string _ten;
                    private SanPham[] dssp;
                    private int n;


                    public QuanLySanPham()
                    {
                        _ten = "Cua Hang ban le";
                        dssp = new SanPham[100];
                        n = 0;
                    }
                    public QuanLySanPham(int size)
                    {
                        _ten = "Cua Hang ban le";
                        dssp = new SanPham[size];
                        n = 0;
                    }
                    public void Nhap()
                    {
                        int chon;
                        SanPham sp;
                        while (true)
                        {
                            Console.WriteLine("ban muon them san pham loai nao: (1.Sicula - 2.Nuoc uong):");
                            chon = int.Parse(Console.ReadLine());
                            switch (chon)
                            {
                                case 1:
                                    sp = new Socola();
                                    sp.Nhap();
                                    dssp[n++] = sp;
                                    break;
                                case 2:
                                    sp = new NuocUong();
                                    sp.Nhap();
                                    dssp[n++] = sp;
                                    break;
                            }
                            Console.WriteLine("Ban co tiep tuc? ( 0.Thoat):");
                            chon = int.Parse(Console.ReadLine());
                            if (chon == 0)
                                break;
                        }
                    }
                    public void InChiTiet()
                    {
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine(dssp[i].InChiTiet());
                        }
                    }

                    class Program
                    {


                        static void Main(string[] args)
                        {
                            QuanLySanPham ql = new QuanLySanPham();
                            ql.Nhap();
                            ql.InChiTiet();
                            Console.ReadLine();
                        }
                    }

                }
            }
        }
    }
}
