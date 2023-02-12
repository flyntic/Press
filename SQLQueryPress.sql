--create database Press;
use Press;
--create table publication
--( [id] int primary key identity(1,1),
--  [name] nvarchar (50),
--  [description] text
--);
--insert publication values
--('������','�������� ������������� �������, ��������� �� ���� ������ ���� � �����'),
--('������','�������� ������������� �������, ��������� �� ���� ������ ���� � �����'),
--('���������','�������� ������������� �������, ��������� ���� ��� � ���'),
--('���������','�������� �������, ��������� ���� ��� � ���'),
--('���������','�������� �������, ����������� � ����� �������������� ������� ������ �����');

--create table publishing_company
--(
--[id] int primary key identity(1,1),
--[name] nvarchar(50),
--[city] nvarchar(50),
--[legal_address] text,
--[description] text,
--[director] text
--);

--insert publishing_company values
--('��������', '������','������, ������, ��. ����� ����������, 39','','����� ������� ����������'),
--('�����������', '������','������, ������, ��. ������� ����������, 93','','������� ������� ����������'),
--('�����', '������','������, ������, ��. ������� ����������, 99','','����� ������� ����������'),
--('�������', '�������','������, �������, ��. ������� ��������, 33','','������ ������� ����������'),
--('�����������', '������ ��������','������, ������ ��������, ��. ������� �������, 9','','����� ������� ����������');

--create table Frequency
--( [id] int primary key identity(1,1),
--[description] nvarchar (50)
--);

--insert Frequency values
--('���������'),
--('���� ��� � ������ �� ��������'),
--('��� ���� � �����, � ������ � ������ �������'),
--('���� ��� � ������� '),
--('�� ������'),
--('���� ��� � �����'),
--('���� ��� � ���, � �������');

--create table Edition 
--( [id] int primary key identity(1,1),
--  [count] int 
--)

--insert Edition values
-- ( 1000),
-- ( 10000),
-- ( 100000),
-- ( 200000),
-- ( 250000); 

--create table Distribution_region
--( [id] int primary key identity(1,1),
--  [region] text
--);

--insert Distribution_region values
--('������'),
--('����������� �������'),
--('������������� �������'),
--('�� ���������');


--create table themes
--(id int primary key identity(1,1),
-- [name] nvarchar(50)
-- );

--create table All_Publications
--( [id] int primary key identity(1,1),
--  [articul] nvarchar (50),
--  [name] nvarchar(50),
--  [id_publication_fk] int,
--  foreign key ([id_publication_fk]) references publication (id),
--  [id_theme_fk] int,
--  foreign key (id_theme_fk) references themes(id), 
--  [id_publishing_company_fk] int, 
--  foreign key ([id_publishing_company_fk]) references publishing_company(id),
--  [id_frequency_fk] int,
--  foreign key ([id_frequency_fk]) references frequency(id),
--  [id_region_fk] int,
--  foreign key ([id_region_fk]) references distribution_region(id),
--  [id_edition_fk] int,
--  foreign key ([id_edition_fk]) references edition(id) 
--);

--insert themes values
--('��������'),
--('��� �����'),
--('��� � ������');

--insert All_Publications values
--('A101','������� ����',1,1,1,1,1,1),
--('B110','���������� �������',1,1,2,3,1,1),
--('C001','����� ����',3,3,1,5,1,5),
--('D010','�',3,1,5,5,1,1),
--('N011','�����',5,3,4,4,1,1),
--('J100','���������!',2,2,2,1,1,1);

--create table All_Prices
--( [id] int primary key identity(1,1),
--  [id_all_publication_fk] int,
--  foreign key ([id_all_publication_fk] ) references all_publications(id),
--  [price_one] real,
--  [date_begin] date,
--  [date_end] date
--);
--
--select * from All_Prices;
--select *from All_publications;

--insert All_Prices values
--(6,13.75,'1.1.2000',null),
--(6, 3.00,'1.1.2000','31.12.2009'),
--(6, 5.00,'1.1.2010','31.12.2009'),
--(6, 7.00,'1.1.2010',null),
--(7,100.05,'1.1.2000','31.12.2019'),
--(7,130.75,'1.1.2020',null),
--(8,100,'1.1.2020',null),
--(9,110,'1.1.2020', null);
--

--create table All_Releases
--([id] int primary key identity (1,1),
-- [id_all_publications_fk] int,
-- foreign key (id_all_publications_fk) references all_publications(id),
-- [id_release] int,
-- [date_release] date,
-- [edition] int,
-- [price_release] real
--);


--insert all_releases values
--(6,1,'11.1.2000',1000,13.75),
--(6,2,'11.2.2000',1000,13.75),
--(6,3,'11.3.2000',1000,13.75),
--(6,4,'11.4.2000',1000,13.75),
--(6,5,'11.5.2000',1000,13.75),
--(6,6,'11.6.2000',1000,13.75),
--(6,7,'11.7.2000',1000,13.75);
