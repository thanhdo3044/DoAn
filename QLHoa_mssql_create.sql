CREATE DATABASE QLBANHANG

CREATE TABLE [Bog] (
    ID int IDENTITY(1,1),
    TieuDe nvarchar(200),
    NoiDung nvarchar(1000),
    MaNoiDung char(16),
    MaNguoiBan char(16) NOT NULL,
    CONSTRAINT [PK_BOG] PRIMARY KEY CLUSTERED
    (
        [MaNoiDung] ASC
    ) WITH (IGNORE_DUP_KEY = OFF)
)
GO

CREATE TABLE [NguoiDung] (
    ID int IDENTITY(1,1),
    TenDangNhap char(200),
    TenNguoiDung char(200),
    TenDem char(200),
    NgaySinh datetime,
    SoDienThoai char(200),
    Email char(100),
    MatKhau char(16),
    MaNguoiDung char(16),
    PhanQuyen char(16),
    CONSTRAINT [PK_NGUOIDUNG] PRIMARY KEY CLUSTERED
    (
        [MaNguoiDung] ASC
    ) WITH (IGNORE_DUP_KEY = OFF)
)
GO

CREATE TABLE [DipDacBiet] (
    ID int IDENTITY(1,1),
    Ngay datetime,
    MaNgay char(16) NOT NULL,
    ChuDe nvarchar(2000),
    CONSTRAINT [PK_DIPDACBIET] PRIMARY KEY CLUSTERED
    (
        [MaNgay] ASC
    ) WITH (IGNORE_DUP_KEY = OFF)
)
GO

CREATE TABLE [Hang] (
    ID int IDENTITY(1,1),
    MaHang char(16),
    MaHoa char(16) NOT NULL,
    SoLuong int,
    TenHang nvarchar(200),
    DonGiaNhap FLOAT,
    DonGiaBan FLOAT,
    Anh char(200),
    GhiChu nvarchar(200),
    MaNgay char(16),
    MaNguoiBan char(16) NOT NULL,
    NoiDungGiamGia NVARCHAR(2000),
    CONSTRAINT [PK_HANG] PRIMARY KEY CLUSTERED
    (
        [MaHang] ASC
    ) WITH (IGNORE_DUP_KEY = OFF)
)
GO

CREATE TABLE [LoaiHoa] (
    ID int IDENTITY(1,1),
    MaHoa char(16) NOT NULL,
    TenHoa nvarchar(200),
    TheLoaiHoa nvarchar(200),
    CONSTRAINT [PK_LOAIHOA] PRIMARY KEY CLUSTERED
    (
        [MaHoa] ASC
    ) WITH (IGNORE_DUP_KEY = OFF)
)
GO

CREATE TABLE [HDBanHang] (
    ID int IDENTITY(1,1),
    MaHDBan char(16),
    NgayBan datetime,
    MaNguoiDung char(16) NOT NULL,
    TongTien float,
    MaNguoiBan char(16),
    DiaChi nvarchar(200),
    DienThoai int,
    CONSTRAINT [PK_HDBANHANG] PRIMARY KEY CLUSTERED
    (
        [MaHDBan] ASC
    ) WITH (IGNORE_DUP_KEY = OFF)
)
GO
CREATE TABLE [ChiTietHDBan] (
ID int IDENTITY(1,1),
MaHDban char(16) NOT NULL,
MaHang char(16) NOT NULL,
SoLuong int,
DonGia float,
ThanhTien float,
CONSTRAINT [PK_CHITIETHDBAN] PRIMARY KEY CLUSTERED
(
[MaHDban] ASC
) WITH (IGNORE_DUP_KEY = OFF)
)

CREATE TABLE [NguoiBan] (
ID int IDENTITY(1,1),
MaNguoiBan char(16) NOT NULL,
TenNguoiBan nvarchar(200),
DienThoai int,
MatKhau nvarchar(200),
DiaChi nvarchar(200),
CONSTRAINT [PK_NGUOIBAN] PRIMARY KEY CLUSTERED
(
[MaNguoiBan] ASC
) WITH (IGNORE_DUP_KEY = OFF)
)