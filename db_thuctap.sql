create database db_thuctap
go
use db_thuctap
go
--------------------------------------------TẠO BẢNG----------------------------------------------------------
create table SinhVien 
(MaSV nvarchar(15) not null primary key,
HoTen nvarchar(50) not null,
GioiTinh nvarchar (5) not null,
NgaySinh datetime not null,
QueQuan nvarchar(250),
Email nvarchar(50),
SDT nvarchar(11),
DiemTB float,
Lop nvarchar(15),
Truong nvarchar(100),
MaDN nvarchar(15),
MaGV nvarchar(15))

create table GiangVien
(MaGV nvarchar(15) not null primary key,
HoTenGV nvarchar(50) not null,
GioiTinh nvarchar(5) not null,
NgaySinh datetime not null,
Email nvarchar(50) not null,
SDT nvarchar(15) not null,
ChucVu nvarchar(50) not null,
Khoa nvarchar(50) not null,
Truong nvarchar(200) not null)

create table DoanhNghiep
(MaDN nvarchar(15) not null primary key,
TenDN nvarchar(50) not null,
TenVietTat nvarchar(50),
DiaChi nvarchar(50) not null,
SDT nvarchar(50) not null,
NgayHD datetime,
LoaiHinhDN nvarchar(100)
)

create table DeTai
(MaDeTai nvarchar(15) not null primary key,
TenDeTai nvarchar(300) not null,
Ngaybatdau datetime not null,
Ngayketthuc datetime not null,
MaLoai nvarchar(15),
MaDN nvarchar(15))

create table QuaTrinh
(MaQT nvarchar(15) not null primary key,
MaSV nvarchar(15) not null ,
MaDeTai nvarchar(15) not null,
DanhGiaQT nvarchar(300) not null,
Diem float not null,
MaDN nvarchar(15) not null)

create table CT_QuaTrinh
(MaCTQT nvarchar(15) not null primary key,
Tuan nvarchar(15) not null ,
MaSV nvarchar(15) not null,
MaDeTai nvarchar(15) not null,
DanhGia nvarchar(300) not null,
Diem float null,
Ngaydanhgia datetime,
MaDN nvarchar(15) not null)


create table LoaiDT
(Maloai nvarchar(15) not null primary key,
Tenloai nvarchar(100) not null)

create table taikhoan(
ID nvarchar(15)  not null primary key,
username nvarchar(50) not null,
pass nvarchar(50) not null,
chucvu nvarchar(20) null)

create table thongbao(
ID nvarchar(15) null,
ThongBao nvarchar(1500) null,
dentu nvarchar(15) null)

------------------------CHÈN THÔNG TIN---------------------------------------------------------
insert into SinhVien(MaSV,HoTen,GioiTinh,NgaySinh,QueQuan,Email,SDT,DiemTB,Lop,Truong,MaDN,MaGV)
values
('20103111791',N'Vũ Hồng Quân',N'Nam','2002/02/15',N'Tp Thanh Hóa-Thanh Hóa','hongquanhero@gmail.com','0399431525',3.2,'DHTI14A7HN',N'Trường đại học kinh tế kỹ thuật công nghiệp','DN1','GV1'),
('20103100241',N'Dương Danh Thái',N'Nam','2002/04/19',N'Tp Hải Dương-Hải Dương','thaihd@gmail.com','0399433335',2.9,'DHTI14A7HN',N'Trường đại học kinh tế kỹ thuật công nghiệp','DN3','GV1'),
('20103100752',N'Bùi Gia Khiêm',N'Nam','2002/04/06',N'Tp Thái Bình-Thái Bình','buigiakhiem@gmail.com','0598029011',2.8,'DHTI14A7HN',N'Trường đại học kinh tế kỹ thuật công nghiệp','DN2','GV2'),
('20103107791',N'Đỗ Đức Anh',N'Nam','2002/02/15',N'Hòa Lạc-Bình Yên-Thạch Thất-Hà Nội','ducanh@gmail.com','02888848435',2.8,'DHTI14A7HN',N'Trường đại học kinh tế kỹ thuật công nghiệp','DN1','GV2'),
('20103120241',N'Nguyễn Đức Dũng',N'Nam','2002/04/19',N'Thường Tín-Hà Nội','ducdung@gmail.com','0906699059',2.8,'DHTI14A7HN',N'Trường đại học kinh tế kỹ thuật công nghiệp','DN1','GV1'),
('20103100742',N'Bùi Chí Hiếu',N'Nam','2002/04/06',N'Phúc Thọ - Hà Nội','chihieucoo@gmail.com','0334481177',2.7,'DHTI14A7HN',N'Trường đại học kinh tế kỹ thuật công nghiệp','DN1','GV1'),
('20103101791',N'Nguyễn Thị Hằng',N'Nữ','2002/02/15',N'Tứ Kỳ-Hải Dương','hangbug@gmail.com','0399431525',3.6,'DHTI14A7HN',N'Trường đại học kinh tế kỹ thuật công nghiệp','DN1','GV1'),
('20103122241',N'Đặng Tiến Thành',N'Nam','2002/04/19',N'Hà Đông-Hà Nội','thanhnek@gmail.com','0399433335',2.3,'DHTI14A7HN',N'Trường đại học kinh tế kỹ thuật công nghiệp','DN1','GV1'),
('20103100753',N'Nguyễn Lương Bằng',N'Nam','2002/12/18',N'Thanh Xuân-Hà Nội','bangbeu@gmail.com','0399431525',3.4,'DHTI14A7HN',N'Trường đại học kinh tế kỹ thuật công nghiệp','DN1','GV1'),
('20103111795',N'Nguyễn Minh Văn',N'Nam','2002/02/15',N'Tp Thanh Hóa-Thanh Hóa','vanlun@gmail.com','0399431525',2.9,'DHTI14A7HN',N'Trường đại học kinh tế kỹ thuật công nghiệp','DN1','GV1'),
('20103133241',N'Nguyễn Đức Đạt',N'Nam','2002/04/19',N'Tp Hải Dương-Hải Dương','datocc@gmail.com','0399433335',2.1,'DHTI14A7HN',N'Trường đại học kinh tế kỹ thuật công nghiệp','DN1','GV1'),
('20103144752',N'Mai Thi Hà Trang',N'Nam','2002/04/06',N'Hoằng Trạch-Thanh Hóa','maihatrang@gmail.com','0399431525',3.4,'DHTI14A7HN',N'Trường đại học kinh tế kỹ thuật công nghiệp','DN1','GV1')

insert into GiangVien(MaGV,HoTenGV,GioiTinh,NgaySinh,Email,SDT,ChucVu,Khoa,Truong)
values
('GV1',N'Bùi Văn Công',N'Nam','1989/03/18',N'buivanconguneti@gmail.com','0369453770',N'Giảng Viên Hướng Dẫn','CNTT' , N'Trường đại học kinh tế - Kỹ thuật công nghiệp'),
('GV2',N'Nguyễn Thùy Dung',N'Nữ','1994/05/15',N'thuydunguneti@gmail.com','0369453440',N'Giảng Viên Hướng Dẫn','CNTT' , N'Trường đại học kinh tế - Kỹ thuật công nghiệp'),
('GV3',N'Nguyễn Quang Trí',N'Nam','1990/07/25',N'nguyenquangtriuneti@gmail.com','0369455780',N'Giảng Viên Hướng Dẫn','CNTT' , N'Trường đại học kinh tế - Kỹ thuật công nghiệp'),
('GV4',N'Nguyễn Quang Dũng',N'Nam','1990/03/18',N'nguyenquangdunguneti@gmail.com','0369453770',N'Giảng Viên Hướng Dẫn','CNTT' , N'Trường đại học kinh tế - Kỹ thuật công nghiệp'),
('GV5',N'Bùi Gia Minh',N'Nam','1989/05/15',N'giaminhuneti@gmail.com','0369453440',N'Giảng Viên Hướng Dẫn','CNTT' , N'Trường đại học kinh tế - Kỹ thuật công nghiệp'),
('GV6',N'Trần Công Huy',N'Nam','1986/07/25',N'tranconghuyuneti@gmail.com','0369455780',N'Giảng Viên Hướng Dẫn','CNTT' , N'Trường đại học kinh tế - Kỹ thuật công nghiệp'),
('GV7',N'Nguyễn Thị Mừng',N'Nữ','1987/03/18',N'thimunguneti@gmail.com','0369453770',N'Giảng Viên Hướng Dẫn','CNTT' , N'Trường đại học kinh tế - Kỹ thuật công nghiệp'),
('GV8',N'Bùi Văn Tân',N'Nam','1989/05/15',N'buivantanuneti@gmail.com','0369453440',N'Giảng Viên Quản Lý','CNTT' , N'Trường đại học kinh tế - Kỹ thuật công nghiệp'),
('GV9',N'Nguyễn Thị Oanh',N'Nam','1988/07/25',N'thioanhuneti@gmail.com','0369455780',N'Giảng Viên Hướng Dẫn','CNTT' , N'Trường đại học kinh tế - Kỹ thuật công nghiệp'),
('GV10',N'Trần Minh Đức',N'Nữ','1988/03/18',N'tranminhducuneti@gmail.com','0369453770',N'Giảng Viên Hướng Dẫn','CNTT' , N'Trường đại học kinh tế - Kỹ thuật công nghiệp'),
('GV11',N'Bùi Văn Trường',N'Nam','1980/05/15',N'buivantruonguneti@gmail.com','0369453440',N'Giảng Viên Hướng Dẫn','CNTT' , N'Trường đại học kinh tế - Kỹ thuật công nghiệp'),
('GV12',N'Nguyễn Thùy Dương',N'Nam','1983/07/25',N'thuyduonguneti@gmail.com','0369455780',N'Giảng Viên Hướng Dẫn','CNTT' , N'Trường đại học kinh tế - Kỹ thuật công nghiệp')

insert into DoanhNghiep(MaDN,TenDN,TenVietTat,DiaChi,SDT,NgayHD,LoaiHinhDN)
values
(N'DN1', N'Financing and Promoting Technology', N'FPT', N'Hà Nội', N'099877733', N'2002/01/01', N'Công nghệ'),
(N'DN10', N'APPLE', N'APPLE', N'Mỹ', N'099899933', N'1998/01/15', N'Hệ Thống Mạng'),
(N'DN11', N'GOOGLE', N'GOOGLE', N'CANADA', N'099899933',N'1998/01/15' , N'Hệ Thống Mạng'),
(N'DN12', N'AMAZON', N'AMAZON', N'Hà Nội', N'099899933', N'1998/01/15', N'Hệ Thống Mạng'),
(N'DN13', N'VIETTEL', N'VIETTEL', N'Hà Nội', N'099899933', N'1998/01/15', N'Hệ Thống Mạng'),
(N'DN2', N'Vietnam Posts and Telecommunications Group', N'VNPT', N'Hà Nội', N'099888833',N'1998/02/15', N'Công nghệ'),
(N'DN3', N'HUAWAI', N'HUAWAI', N'Hà Nam', N'099899933', N'1998/01/15', N'Hệ Thống Mạng'),
(N'DN4', N'TCSOFT', N'TCSOFT', N'Định Công', N'19008098',N'1998/01/15', N'Công Nghệ'),
(N'DN6', N'MoBiFone', N'MBF', N'Hà Nội', N'18008098', N'2002/01/01', N'công Nghệ'),
(N'DN7', N'Hồng Hải', N'FoxCom', N'Bắc Giang', N'123456789', N'2002/01/01', N'Công Nghiệp'),
(N'DN8', N'VIETTEL', N'VIETTEL', N'Hà Nội', N'099899933', N'1998/01/15', N'Hệ Thống Mạng'),
(N'DN9', N'VIETTEL', N'VIETTEL', N'Hà Nội', N'099899933', N'1998/01/15', N'Hệ Thống Mạng')


insert into DeTai(MaDeTai,TenDeTai,NgayBatDau,NgayKetThuc,MaLoai,MaDN)
values
('DT1', N'Thiết kê ứng dụng quản lý sinh viên đi thực tập tại doanh nghiệp','2023/08/15', '2024/02/14','L3','DN1'),
('DT2', N'Thiết kê ứng dụng quản lý thư viện','2023/08/15', '2024/02/14','L3','DN4'),
('DT3', N'Thiết kê website bán đồ ăn vặt','2023/08/15', '2024/02/14','L1','DN2'),
('DT4', N'Thiết kê website quảng bá khu du lịch Sầm Sơn','2023/08/15', '2024/02/14','L1','DN2'),
('DT5', N'Thiết kê ứng dụng quản lý phòng máy tại trường đại học kinh tế kỹ thuật công nghiệp','2023/08/15', '2024/02/14','L1','DN2'),
('DT6', N'Thiết kê ứng dụng quản lý căng tin trường đại học','2023/08/15', '2024/02/14','L1','DN3'),
('DT7', N'Thiết kê website bán thú cưng','2023/08/15', '2024/02/14','L1','DN3'),
('DT8', N'Thiết kê ứng dụng quản lý chi tiêu trong gia đình','2023/08/15', '2024/02/14','L1','DN3'),
('DT9', N'Thiết kê ứng dụng quản lý cho một của hàng tạp hóa','2023/08/15', '2024/02/14','L1','DN3'),
('DT10', N'Thiết kê ứng dụng quản lý cho một hệ thống cho mượn sách của thư viện','2023/08/15', '2024/02/14','L1','DN4')
insert into QuaTrinh(MaQT,MaSV,MaDeTai,DanhGiaQT,Diem,MaDN)
values
('QT1','20103111791', 'DT1',N'Thực hiện đề tài tốt , tiến độ hoàn thành đúng thời hạn', 9.5,'DN1'),
('QT2','20103100241', 'DT2',N'Thực hiện đề tài tốt , tiến độ hoàn thành đúng thời hạn', 8,'DN1'),
('QT3','20103100752', 'DT5',N'Thực hiện đề tài tốt , tiến độ hoàn thành đúng thời hạn', 7.5,'DN2'),
('QT4','20103120241', 'DT4',N'Thực hiện đề tài tốt , tiến độ hoàn thành đúng thời hạn', 8.5,'DN2'),
('QT5','20103101791', 'DT7',N'Thực hiện đề tài tốt , tiến độ hoàn thành đúng thời hạn', 6.5,'DN3'),
('QT6','20103100753', 'DT9',N'Thực hiện đề tài tốt , tiến độ hoàn thành đúng thời hạn', 8.5,'DN3'),
('QT7','20103144752', 'DT2',N'Thực hiện đề tài tốt , tiến độ hoàn thành đúng thời hạn', 7.5,'DN4')


insert into LoaiDT(Maloai,Tenloai)
values
('L1', N'Trí Tuệ Nhân Tạo'),
('L2', N'An Toàn Thông Tin'),
('L3', N'Lập trình ứng dụng'),
('L4', N'Lập trình website')

insert into thongbao(ID,ThongBao,dentu)
values
('1','Doanh nghiệp FPT lấy số lượng sinh viên đên thực tập là 200 sinh viên' , 'doanhnghiep'),
('2','Doanh nghiệp VNPT lấy số lượng sinh viên đên thực tập là 200 sinh viên' , 'doanhnghiep'),
('3','Doanh nghiệp Viettel lấy số lượng sinh viên đên thực tập là 200 sinh viên' , 'doanhnghiep')
insert into taikhoan(ID,username,pass,chucvu)
values
('1','vuhongquan1502','quan15022002','admin'),
('2','buigiakhiem111','khiem123','giangvien'),
('3','thaihd123','thai123','doanhnghiep'),
('4','buivancong123','123','giangvienquanly')


-------------------------HIỂN THỊ BẢNG---------------------------------------------------------
select * from SinhVien
select * from GiangVien
select * from DoanhNghiep
select * from DeTai
select * from QuaTrinh
select * from LoaiDT

alter table SinhVien add foreign key(MaDN) references DoanhNghiep(MaDN)
alter table SinhVien add foreign key(MaGV) references GiangVien(MaGV)
alter table DeTai add foreign key(MaDN) references DoanhNghiep(MaDN)
alter table QuaTrinh add foreign key(MaDN) references DoanhNghiep(MaDN)
alter table DeTai add foreign key(Maloai) references LoaiDT(Maloai)
alter table QuaTrinh add foreign key(MaSV) references SinhVien(MaSV)
alter table QuaTrinh add foreign key(MaDeTai) references DeTai(MaDeTai)
alter table CT_QuaTrinh add foreign key(MaDN) references DoanhNghiep(MaDN)
alter table CT_QuaTrinh add foreign key(MaSV) references SinhVien(MaSV)
alter table CT_QuaTrinh add foreign key(MaDeTai) references DeTai(MaDeTai)

--select DeTai.* from DeTai inner join LoaiDT on DeTai.MaLoai = LoaiDT.MaLoai where LoaiDT.Tenloai = N'Trí Tuệ Nhân Tạo'
--select * from DeTai where MaLoai = 'L1'

--select ThongBao from thongbao

--INSERT [dbo].[DeTai] ([MaDeTai], [TenDeTai], [Ngaybatdau], [Ngayketthuc], [MaLoai], [MaDN]) VALUES (N'DT10', N'Thiết kê ứng dụng quản lý sinh viên đi thực tập tại doanh nghiệp', CAST(N'2023-08-15' AS Date), CAST(N'2024-02-14' AS Date), N'L4', N'DN1')