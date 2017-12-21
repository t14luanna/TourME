CREATE TRIGGER UPDATE_Place_SET_Popular ON Place
AFTER UPDATE
AS
	declare @thisPlaceId int;
	declare @thisPlaceKindId int;
	declare @ratingStar varchar(100);
	declare @NoOfSearch decimal(10,2);
	declare @Result int;
	declare @LastPlaceKindId int;
	SELECT TOP 1 @LastPlaceKindId =  pk.Id
	FROM PlaceKind pk
	ORDER BY pk.Id DESC

	select * FROM inserted
	select @thisPlaceId=i.Id from inserted i;	
	select @thisPlaceKindId=i.PlaceKindId from inserted i;	
	select @ratingStar=i.RatingStar from inserted i;	
	select @NoOfSearch=i.NofSearch from inserted i;	
	set @Result=(((@LastPlaceKindId - @thisPlaceKindId) * 100 + (@ratingStar*10)) + @NoOfSearch);

	UPDATE Place SET Poppular = @Result WHERE Id = @thisPlaceId

	PRINT @thisPlaceId
	PRINT @Result
	PRINT @LastPlaceKindId
	PRINT @thisPlaceKindId
	PRINT @ratingStar
	PRINT @NoOfSearch
GO

CREATE TRIGGER INSERT_Place_SET_Popular ON Place
AFTER INSERT
AS
BEGIN
	declare @thisPlaceId int;
	declare @thisPlaceKindId int;
	declare @ratingStar varchar(100);
	declare @NoOfSearch decimal(10,2);
	declare @Result int;
	declare @LastPlaceKindId int;
	SELECT TOP 1 @LastPlaceKindId =  pk.Id
	FROM PlaceKind pk
	ORDER BY pk.Id DESC

	select @thisPlaceId=i.Id from inserted i;	
	select @thisPlaceKindId=i.PlaceKindId from inserted i;	
	select @ratingStar=i.RatingStar from inserted i;	
	select @NoOfSearch=i.NofSearch from inserted i;	
	set @Result=(((@LastPlaceKindId + 1 - @thisPlaceKindId) * 100 + (@ratingStar*10)) + @NoOfSearch);

    UPDATE Place
    SET Poppular =  @Result
    WHERE Id = @thisPlaceId;

	PRINT @thisPlaceId
	PRINT @thisPlaceKindId
	PRINT @ratingStar
	PRINT @NoOfSearch
	PRINT @Result
	PRINT @LastPlaceKindId
END
GO

CREATE TRIGGER INSERT_PlaceKind_UPDATE_Place_Popular ON PlaceKind
AFTER INSERT
AS
BEGIN
	
	DECLARE @LoopCounter INT , @MaxPlaceId INT, @Name NVARCHAR(MAX)
	SELECT @LoopCounter = min(Id) , @MaxPlaceId = max(Id) 
	FROM Place
 
	WHILE(@LoopCounter IS NOT NULL
		  AND @LoopCounter <= @MaxPlaceId)
	BEGIN
	   SELECT @Name = Name
	   FROM Place WHERE Id = @LoopCounter
   
	   IF @Name != ''
		BEGIN
			PRINT @Name
			UPDATE Place SET Poppular = 3 WHERE Id = @LoopCounter
		END
	   SET @Name = ''
	   PRINT @LoopCounter  
	   SET @LoopCounter  = @LoopCounter  + 1        
	END
	SELECT * FROM PlaceKind
END
GO

CREATE TRIGGER PREVENT_DELETE_PlaceKind ON PlaceKind
INSTEAD OF DELETE 
AS
BEGIN
	PRINT 'Cannot Delete'
END
GO


INSERT INTO ImageKind (Description,Kind) VALUES (N'Không có hình', 'None')
INSERT INTO ImageKind (Description,Kind) VALUES (N'Ảnh đai diện', 'Avatar')
INSERT INTO ImageKind (Description,Kind) VALUES (N'Ảnh địa điểm', 'Place')
SELECT * FROM ImageKind
-------------
INSERT INTO Image (Url,Description,ImageKindId,OwnId) 
	VALUES ('https://picsum.photos/200/300','Admin Avatar', 1, 0)
INSERT INTO Image (Url,Description,ImageKindId,OwnId) 
	VALUES ('http://vietnamdailytour.vn/wp-content/uploads/2016/05/hochiminh-city-900x500.jpeg','Ho Chi Minh City image', 2, 0)
SELECT * FROM Image
-------------Role(0:User, 1: Staff, 2: manage, 3:admin)
INSERT INTO Users (Username, Password, ImageId, Email, isEnable, Role) 
	VALUES ('admin', 'admin123', 0, 'admin@gmail.com', 0, 3)
INSERT INTO Users (Username, Password, ImageId, Email, isEnable, Role) 
	VALUES ('user', 'user', 0, 'user@gmail.com', 1, 0)
SELECT * FROM Users
------------
INSERT INTO PlaceKind (Description, Kind, Priority) VALUES(N'Quốc gia', 'Country', 0)
INSERT INTO PlaceKind (Description, Kind, Priority) VALUES(N'Thành Phô', 'City', 1)
<<<<<<< HEAD
INSERT INTO PlaceKind (Description, Kind, Priority) VALUES(N'Địa chi', 'Address', 2)
=======
INSERT INTO PlaceKind (Description, Kind, Priority) VALUES(N'Địa \', 'Address', 2)
>>>>>>> 82084bf310635f8555a9f49c6b8a2319db8ab6f8
INSERT INTO PlaceKind (Description, Kind, Priority) VALUES(N'Café', 'Cafe', 3)
INSERT INTO PlaceKind (Description, Kind, Priority) VALUES(N'Khách sạn và chỗ ở', 'Hotel', 4)
INSERT INTO PlaceKind (Description, Kind, Priority) VALUES(N'Mua sắm', 'Market', 5)
INSERT INTO PlaceKind (Description, Kind, Priority) VALUES(N'Giáo dục', 'Education"', 6)
INSERT INTO PlaceKind (Description, Kind, Priority) VALUES(N'Du lịch', 'Point_of_interested', 7)
<<<<<<< HEAD
INSERT INTO PlaceKind (Description, Kind, Priority) VALUES(N'Sức khỏe', 'Health', 😎
=======
INSERT INTO PlaceKind (Description, Kind, Priority) VALUES(N'Sức khỏe', 'Health', 8)
>>>>>>> 82084bf310635f8555a9f49c6b8a2319db8ab6f8
INSERT INTO PlaceKind (Description, Kind, Priority) VALUES(N'Giải trí', 'Entertaiment', 9)
INSERT INTO PlaceKind (Description, Kind, Priority) VALUES(N'Cây xăng', 'Gas', 10)
INSERT INTO PlaceKind (Description, Kind, Priority) VALUES(N'Các cây ATM', 'ATM', 11)
INSERT INTO PlaceKind (Description, Kind, Priority) VALUES(N'Cuộc sống về đêm', 'NightLife', 12)
INSERT INTO PlaceKind (Description, Kind, Priority) VALUES(N'Dịch vụ', 'Service', 13)
SELECT * FROM PlaceKind


------------ServeStatus(0:notactive, 1:active, 2:pending, 3:fixing)
<<<<<<< HEAD
INSERT INTO Place (Name, Description, Longitude, Latitude, ZoomSize, Address, ServeStatus, PlaceKindId, TimeOpen, TimeClose, UserId, RootPlaceId, RatingStar, NofSearch, Definition, Popular)
VALUES (N'Việt Nam', N'Việt Nam có nhiều điểm du lịch đa dạng từ miền Bắc đến miền Nam, từ miền núi tới đồng bằng, bãi biển, đảo. Từ các thắng cảnh thiên nhiên tới các di tích văn hóa lịch sử... Các điểm du lịch miền núi nổi tiếng như Sapa, Bà Nà, Đà Lạt, Tam Đảo. Các điểm du lịch ở đồng bằng như Hà Nội, Huế, Đà Nẵng, TP.Hồ Chí Minh, Nam Định... Các điểm du lịch ở các bãi biển như Hạ Long, Nha Trang,Phan Thiết, Vũng Tàu, Thịnh Long, Sầm Sơn, Cửa Lò... và các đảo như Cát Bà, Cù lao Chàm, Côn Đảo, Phú Quốc,...',
101.4135155,15.7480907, 6, N'Đông Nam Á', 1, 0, 0, 0, 0, 0, 4, 100, 'Viet Nam Dong Nam A', 10150)
INSERT INTO Place (Name, Description, Longitude, Latitude, ZoomSize, Address, ServeStatus, PlaceKindId, TimeOpen, TimeClose, UserId, RootPlaceId, RatingStar, NofSearch, Definition, Popular)
VALUES (N'Singapore', N'Singapore (phiên âm Tiếng Việt: Xin-ga-po), tên chính thức là nước Cộng hòa Singapore, là một thành bang và đảo quốc tại Đông Nam Á. Đảo quốc nằm ngoài khơi mũi phía nam của bán đảo Mã Lai và cách xích đạo 137 km về phía bắc. Lãnh thổ Singapore gồm có một đảo chính hình thoi, và khoảng 60 đảo nhỏ hơn. Singapore tách biệt với Malaysia bán đảo qua eo biển Johor ở phía bắc, và tách biệt với quần đảo Riau của Indonesia qua eo biển Singapore ở phía nam. Singapore là quốc gia đô thị hóa cao độ, chỉ còn lại ít thảm thực vật nguyên sinh. Lãnh thổ của Singapore liên tục mở rộng thông qua hoạt động cải tạo đất.',
103.6839556, 1.3440852,  11, N'Đông Nam Á', 1, 0, 0, 0, 0, 1, 5, 100, 'Singapore Dong Nam A', 10150)
INSERT INTO Place (Name, Description, Longitude, Latitude, ZoomSize, Address, ServeStatus, PlaceKindId, TimeOpen, TimeClose, UserId, RootPlaceId, RatingStar, NofSearch, Definition, Popular)
VALUES (N'Thái Lan', N'Thái Lan (tiếng Thái: ประเทศไทย "Prathet Thai"), tên chính thức: Vương quốc Thái Lan (tiếng Thái: ราชอาณาจักรไทย Racha-anachak Thai), là một quốc gia nằm ở vùng Đông Nam Á, phía bắc giáp Lào và Myanma, phía đông giáp Lào và Campuchia, phía nam giáp vịnh Thái Lan và Malaysia, phía tây giáp Myanma và biển Andaman. Lãnh hải Thái Lan phía đông nam giáp với lãnh hải Việt Nam ở vịnh Thái Lan, phía tây nam giáp với lãnh hải Indonesia và Ấn Độ ở biển Andaman.',
100.9448084, 14.6967409,  8.5, N'Đông Nam Á', 1, 0, 0, 0, 0, 2, 4, 100, 'Thai Lan Dong Nam A', 10150)
INSERT INTO Place (Name, Description, Longitude, Latitude, ZoomSize, Address, ServeStatus, PlaceKindId, TimeOpen, TimeClose, UserId, RootPlaceId, RatingStar, NofSearch, Definition, Popular)
VALUES (N'Malaysia', N'Malaysia là một quốc gia quân chủ lập hiến liên bang tại Đông Nam Á. Quốc gia bao gồm 13 bang và ba lãnh thổ liên bang với tổng diện tích đất là 329.847 kilômét vuông (127.350 sq mi). Malaysia bị tách làm hai phần qua biển Đông: Malaysia bán đảo và Borneo thuộc Malaysia. Malaysia có biên giới trên bộ với Thái Lan, Indonesia, và Brunei, trong khi có biên giới trên biển với Singapore, Việt Nam, và Philippines. Thành phố thủ đô là Kuala Lumpur, song nơi đặt trụ sở của chính phủ liên bang là Putrajaya. Năm 2010, dân số Malaysia là 28,33 triệu, trong đó 22,6 triệu sinh sống tại phần Bán đảo. Malaysia có điểm cực nam của đại lục Á-Âu là Tanjung Piai. Malaysia là một quốc gia nhiệt đới, là một trong 17 quốc gia đa dạng sinh học siêu cấp trên Trái Đất, với nhiều loài đặc hữu.',
101.93714, 3.927894,  9, N'Đông Nam Á', 1, 0, 0, 0, 0, 3, 4, 100, 'Malaysia Dong Nam A', 10150)
INSERT INTO Place (Name, Description, Longitude, Latitude, ZoomSize, Address, ServeStatus, PlaceKindId, TimeOpen, TimeClose, UserId, RootPlaceId, RatingStar, NofSearch, Definition, Popular)
VALUES (N'Indonesia', N'Indonesia (tên chính thức: Cộng hòa Indonesia, tiếng Indonesia: Republik Indonesia) trước đó trong tài liệu tiếng Việt quốc gia này từng được gọi là Nam Dương, là một quốc gia nằm giữa Đông Nam Á và Châu Đại Dương. Indonesia được mệnh danh là "Xứ sở vạn đảo", lãnh thổ của nó bao gồm 13.487 hòn đảo và với dân số khoảng 255 triệu người (năm 2015), đứng thứ tư thế giới về dân số.',
121.8505945, -3.8151348,  10.5, N'Đông Nam Á', 1, 0, 0, 0, 0, 4, 4, 100, 'Indonesia Dong Nam A', 10150)
INSERT INTO Place (Name, Description, Longitude, Latitude, ZoomSize, Address, ServeStatus, PlaceKindId, TimeOpen, TimeClose, UserId, RootPlaceId, RatingStar, NofSearch, Definition, Popular)
VALUES (N'Philippines', N'Philippines (tiếng Tagalog: Republika ng Pilipinas; tiếng Anh: Republic of the Philippines), là một đảo quốc có chủ quyền tại Đông Nam Á. Philippines cách Đài Loan qua eo biển Luzon ở phía bắc; cách Việt Nam qua biển Đông ở phía tây, cách đảo Borneo qua biển Sulu ở phía tây nam, và các đảo khác của Indonesia qua biển Celebes ở phía nam; phía đông quốc gia là biển Philippines và đảo quốc Palau. Philippines nằm trên Vành đai lửa Thái Bình Dương và nằm gần xích đạo, do vậy quốc gia hay chịu ảnh hưởng từ các trận động đất và bão nhiệt đới, song lại có nguồn tài nguyên thiên nhiên phong phú và đa dạng sinh học ở mức độ cao. Philippines có diện tích 300.000 kilômét vuông (115.831 sq mi), là quốc gia rộng lớn thứ 71 trên thế giới.',
120.9478678, 14.518241, 10, N'Đông Nam Á', 1, 0, 0, 0, 0, 5, 4, 100, 'Philippines Dong Nam A', 10150)
INSERT INTO Place (Name, Description, Longitude, Latitude, ZoomSize, Address, ServeStatus, PlaceKindId, TimeOpen, TimeClose, UserId, RootPlaceId, RatingStar, NofSearch, Definition, Popular)
VALUES (N'Lào', N'Lào, tên chính thức là nước Cộng hoà Dân chủ Nhân dân Lào, (tiếng Lào: Sathalanalat Paxathipatai Paxaxon Lao) là một quốc gia nội lục tại Đông Nam Á, phía tây bắc giáp với Myanmar và Trung Quốc, phía đông giáp Việt Nam, phía tây nam giáp Campuchia, phía tây và tây nam giáp Thái Lan.',
102.1825933, 19.7282602, 9, N'Đông Nam Á', 1, 0, 0, 0, 0, 6, 4, 100, 'Lao Dong Nam A', 10150)
INSERT INTO Place (Name, Description, Longitude, Latitude, ZoomSize, Address, ServeStatus, PlaceKindId, TimeOpen, TimeClose, UserId, RootPlaceId, RatingStar, NofSearch, Definition, Popular)
=======
INSERT INTO Place (Name, Description, Longitude, Latitude, ZoomSize, Address, ServeStatus, PlaceKindId, TimeOpen, TimeClose, UserId, RootPlaceId, RatingStar, NofSearch, Definition)
VALUES (N'Việt Nam', N'Việt Nam có nhiều điểm du lịch đa dạng từ miền Bắc đến miền Nam, từ miền núi tới đồng bằng, bãi biển, đảo. Từ các thắng cảnh thiên nhiên tới các di tích văn hóa lịch sử... Các điểm du lịch miền núi nổi tiếng như Sapa, Bà Nà, Đà Lạt, Tam Đảo. Các điểm du lịch ở đồng bằng như Hà Nội, Huế, Đà Nẵng, TP.Hồ Chí Minh, Nam Định... Các điểm du lịch ở các bãi biển như Hạ Long, Nha Trang,Phan Thiết, Vũng Tàu, Thịnh Long, Sầm Sơn, Cửa Lò... và các đảo như Cát Bà, Cù lao Chàm, Côn Đảo, Phú Quốc,...',
15.7480907, 101.4135155, 6, N'Đông Nam Á', 1, 0, 0, 0, 0, 0, 4, 100, 'Viet Nam Dong Nam A')
INSERT INTO Place (Name, Description, Longitude, Latitude, ZoomSize, Address, ServeStatus, PlaceKindId, TimeOpen, TimeClose, UserId, RootPlaceId, RatingStar, NofSearch, Definition)
VALUES (N'Singapore', N'Singapore (phiên âm Tiếng Việt: Xin-ga-po), tên chính thức là nước Cộng hòa Singapore, là một thành bang và đảo quốc tại Đông Nam Á. Đảo quốc nằm ngoài khơi mũi phía nam của bán đảo Mã Lai và cách xích đạo 137 km về phía bắc. Lãnh thổ Singapore gồm có một đảo chính hình thoi, và khoảng 60 đảo nhỏ hơn. Singapore tách biệt với Malaysia bán đảo qua eo biển Johor ở phía bắc, và tách biệt với quần đảo Riau của Indonesia qua eo biển Singapore ở phía nam. Singapore là quốc gia đô thị hóa cao độ, chỉ còn lại ít thảm thực vật nguyên sinh. Lãnh thổ của Singapore liên tục mở rộng thông qua hoạt động cải tạo đất.',
1.3440852, 103.6839556, 11, N'Đông Nam Á', 1, 0, 0, 0, 0, 1, 5, 100, 'Singapore Dong Nam A')
INSERT INTO Place (Name, Description, Longitude, Latitude, ZoomSize, Address, ServeStatus, PlaceKindId, TimeOpen, TimeClose, UserId, RootPlaceId, RatingStar, NofSearch, Definition)
VALUES (N'Thái Lan', N'Thái Lan (tiếng Thái: ประเทศไทย "Prathet Thai"), tên chính thức: Vương quốc Thái Lan (tiếng Thái: ราชอาณาจักรไทย Racha-anachak Thai), là một quốc gia nằm ở vùng Đông Nam Á, phía bắc giáp Lào và Myanma, phía đông giáp Lào và Campuchia, phía nam giáp vịnh Thái Lan và Malaysia, phía tây giáp Myanma và biển Andaman. Lãnh hải Thái Lan phía đông nam giáp với lãnh hải Việt Nam ở vịnh Thái Lan, phía tây nam giáp với lãnh hải Indonesia và Ấn Độ ở biển Andaman.',
14.6967409, 100.9448084, 8.5, N'Đông Nam Á', 1, 0, 0, 0, 0, 2, 4, 100, 'Thai Lan Dong Nam A')
INSERT INTO Place (Name, Description, Longitude, Latitude, ZoomSize, Address, ServeStatus, PlaceKindId, TimeOpen, TimeClose, UserId, RootPlaceId, RatingStar, NofSearch, Definition)
VALUES (N'Malaysia', N'Malaysia là một quốc gia quân chủ lập hiến liên bang tại Đông Nam Á. Quốc gia bao gồm 13 bang và ba lãnh thổ liên bang với tổng diện tích đất là 329.847 kilômét vuông (127.350 sq mi). Malaysia bị tách làm hai phần qua biển Đông: Malaysia bán đảo và Borneo thuộc Malaysia. Malaysia có biên giới trên bộ với Thái Lan, Indonesia, và Brunei, trong khi có biên giới trên biển với Singapore, Việt Nam, và Philippines. Thành phố thủ đô là Kuala Lumpur, song nơi đặt trụ sở của chính phủ liên bang là Putrajaya. Năm 2010, dân số Malaysia là 28,33 triệu, trong đó 22,6 triệu sinh sống tại phần Bán đảo. Malaysia có điểm cực nam của đại lục Á-Âu là Tanjung Piai. Malaysia là một quốc gia nhiệt đới, là một trong 17 quốc gia đa dạng sinh học siêu cấp trên Trái Đất, với nhiều loài đặc hữu.',
3.927894, 101.93714, 9, N'Đông Nam Á', 1, 0, 0, 0, 0, 3, 4, 100, 'Malaysia Dong Nam A')
INSERT INTO Place (Name, Description, Longitude, Latitude, ZoomSize, Address, ServeStatus, PlaceKindId, TimeOpen, TimeClose, UserId, RootPlaceId, RatingStar, NofSearch, Definition)
VALUES (N'Indonesia', N'Indonesia (tên chính thức: Cộng hòa Indonesia, tiếng Indonesia: Republik Indonesia) trước đó trong tài liệu tiếng Việt quốc gia này từng được gọi là Nam Dương, là một quốc gia nằm giữa Đông Nam Á và Châu Đại Dương. Indonesia được mệnh danh là "Xứ sở vạn đảo", lãnh thổ của nó bao gồm 13.487 hòn đảo và với dân số khoảng 255 triệu người (năm 2015), đứng thứ tư thế giới về dân số.',
-3.8151348, 121.8505945, 10.5, N'Đông Nam Á', 1, 0, 0, 0, 0, 4, 4, 100, 'Indonesia Dong Nam A')
INSERT INTO Place (Name, Description, Longitude, Latitude, ZoomSize, Address, ServeStatus, PlaceKindId, TimeOpen, TimeClose, UserId, RootPlaceId, RatingStar, NofSearch, Definition)
VALUES (N'Philippines', N'Philippines (tiếng Tagalog: Republika ng Pilipinas; tiếng Anh: Republic of the Philippines), là một đảo quốc có chủ quyền tại Đông Nam Á. Philippines cách Đài Loan qua eo biển Luzon ở phía bắc; cách Việt Nam qua biển Đông ở phía tây, cách đảo Borneo qua biển Sulu ở phía tây nam, và các đảo khác của Indonesia qua biển Celebes ở phía nam; phía đông quốc gia là biển Philippines và đảo quốc Palau. Philippines nằm trên Vành đai lửa Thái Bình Dương và nằm gần xích đạo, do vậy quốc gia hay chịu ảnh hưởng từ các trận động đất và bão nhiệt đới, song lại có nguồn tài nguyên thiên nhiên phong phú và đa dạng sinh học ở mức độ cao. Philippines có diện tích 300.000 kilômét vuông (115.831 sq mi), là quốc gia rộng lớn thứ 71 trên thế giới.',
14.518241, 120.9478678, 10, N'Đông Nam Á', 1, 0, 0, 0, 0, 5, 4, 100, 'Philippines Dong Nam A')
INSERT INTO Place (Name, Description, Longitude, Latitude, ZoomSize, Address, ServeStatus, PlaceKindId, TimeOpen, TimeClose, UserId, RootPlaceId, RatingStar, NofSearch, Definition)
VALUES (N'Lào', N'Lào, tên chính thức là nước Cộng hoà Dân chủ Nhân dân Lào, (tiếng Lào: Sathalanalat Paxathipatai Paxaxon Lao) là một quốc gia nội lục tại Đông Nam Á, phía tây bắc giáp với Myanmar và Trung Quốc, phía đông giáp Việt Nam, phía tây nam giáp Campuchia, phía tây và tây nam giáp Thái Lan.',
19.7282602, 102.1825933, 9, N'Đông Nam Á', 1, 0, 0, 0, 0, 6, 4, 100, 'Lao Dong Nam A')
INSERT INTO Place (Name, Description, Longitude, Latitude, ZoomSize, Address, ServeStatus, PlaceKindId, TimeOpen, TimeClose, UserId, RootPlaceId, RatingStar, NofSearch, Definition)
>>>>>>> 82084bf310635f8555a9f49c6b8a2319db8ab6f8
VALUES (N'Campuchia', N'Campuchia (chữ Khmer: Kampuchea, IPA: [kɑmpuˈciə], tên chính thức: Vương quốc Campuchia, cũng còn gọi là Cam Bốt là một quốc gia nằm trên bán đảo Đông Dương ở vùng Đông Nam Á, giáp với vịnh Thái Lan ở phía Nam, Thái Lan ở phía Tây, Lào ở phía Bắc và Việt Nam ở phía Đông. Campuchia có ngôn ngữ chính thức là tiếng Khmer, thuộc nhóm Môn-Khmer trong hệ Nam Á. Người Việt trước thế kỷ XXI còn gọi nước này bằng những tên khác như Chân Lạp',
104.7584983, 11.6118507, 10, N'Đông Nam Á', 1, 0, 0, 0, 0, 7, 4, 100, 'Campuchia Dong Nam A', 10150)

<<<<<<< HEAD
INSERT INTO Place (Name, Description, Longitude, Latitude, ZoomSize, Address, ServeStatus, PlaceKindId, TimeOpen, TimeClose, UserId, RootPlaceId, RatingStar, NofSearch, Definition, Popular)
=======
INSERT INTO Place (Name, Description, Longitude, Latitude, ZoomSize, Address, ServeStatus, PlaceKindId, TimeOpen, TimeClose, UserId, RootPlaceId, RatingStar, NofSearch, Definition)
>>>>>>> 82084bf310635f8555a9f49c6b8a2319db8ab6f8
VALUES (N'Hồ Chí Minh', N'Thành phố Hồ Chí Minh (vẫn còn phổ biến với tên gọi cũ là Sài Gòn) là thành phố lớn nhất Việt Nam về dân số và kinh tế, đứng thứ hai về diện tích, đồng thời cũng là một trong những trung tâm kinh tế và văn hóa, giáo dục quan trọng nhất của nước này.' + 
N'Các địa điểm du lịch của thành phố tương đối đa dạng. Với hệ thống 11 viện bảo tàng, chủ yếu về đề tài lịch sử, Thành phố Hồ Chí Minh đứng đầu Việt Nam về số lượng bảo tàng. Bảo tàng lớ, 10150n nhất và cổ nhất thành phố là Bảo tàng Lịch sử Việt Nam với 30 nghìn hiện vật. Trong khi phần lớn khách thăm Bảo tàng Chứng tích chiến tranh là người nước ngoài[112] thì bảo tàng thu hút nhiều khách nội địa nhất là Bảo tàng Hồ Chí Minh.[113] Thành phố Hồ Chí Minh cũng là một đô thị đa dạng về tôn giáo. Trên địa phận thành phố hiện nay có hơn một nghìn ngôi chùa, đình, miếu được xây dựng qua nhiều thời kỳ. Còn các nhà thờ xuất hiện chủ yếu trong thế kỷ 19 theo các phong cách Roman, Gothic. Nhà thờ lớn và nổi tiếng nhất của thành phố là nhà thờ Đức Bà, nằm ở Quận 1, hoàn thành năm 1880. Thời kỳ thuộc địa đã để lại cho thành phố nhiều công trình kiến trúc quan trọng, như Trụ sở Ủy ban Nhân dân Thành phố, Nhà hát lớn, Bưu điện trung tâm, Bến Nhà Rồng... Dinh Độc Lập và Thư viện Khoa học Tổng hợp được xây dựng dưới thời Việt Nam Cộng hòa. Kiến trúc hiện đại ghi dấu ấn ở thành phố bằng các cao ốc, khách sạn, trung tâm thương mại như Diamond Plaza, Saigon Trade Centre... Khu vực ngoài trung tâm, Địa đạo Củ Chi, Rừng ngập mặn Cần Giờ, Vườn cò Thủ Đức cũng là những địa điểm du lịch quan trọng.
Thành phố Hồ Chí Minh còn là một trung tâm mua sắm và giải trí. Bên cạnh các phòng trà ca nhạc, quán bar, vũ trường, sân khấu, thành phố có khá nhiều khu vui chơi như Công viên Đầm Sen, Suối Tiên, Thảo Cầm Viên. Các khu mua sắm, như Chợ Bến Thành, Diamond Plaza... hệ thống các nhà hàng, quán ăn cũng là một thế mạnh của du lịch thành phố.',
<<<<<<< HEAD
106.415032, 10.7546664, 10, N'Đông Nam Bộ', 1, 1, 0, 0, 0, 0, 5, 100, 'Ho Chi Minh Viet Nam')
INSERT INTO Place (Name, Description, Longitude, Latitude, ZoomSize, Address, ServeStatus, PlaceKindId, RootPlaceId, TimeOpen, TimeClose, UserId, RatingStar, NofSearch, Definition, Popular)
=======
10.7546664, 106.415032, 10, N'Đông Nam Bộ', 1, 1, 0, 0, 0, 0, 5, 100, 'Ho Chi Minh Viet Nam')
INSERT INTO Place (Name, Description, Longitude, Latitude, ZoomSize, Address, ServeStatus, PlaceKindId, RootPlaceId, TimeOpen, TimeClose, UserId, RatingStar, NofSearch, Definition)
>>>>>>> 82084bf310635f8555a9f49c6b8a2319db8ab6f8
VALUES (N'Hàm Nghi', N'Bắt đầu từ vòng xoay công viên Quách Thị Trang cho đến đường Tôn Đức Thắng, là con đường sầm uất, nổi tiếng với các sự kiện diễn ra vào các dịp lễ hội. Các địa điểm gửi xe: Cụ thể, 10 bãi giữ xe tại quận 1 gồm: 
1. Lề đường Lê Thị Hồng Gấm vách Bảo tàng Mỹ thuật Thành phố, Phường Nguyễn Thái Bình;, 
2. Lề đường Nguyễn Thái Bình vách Bảo tàng Mỹ thuật Thành phố, phường Nguyễn Thái Bình; 
3. Lề đường Hồ Tùng Mậu vách tòa nhà SUNWAH, phường Bến Nghé; 
4. Lề đường trước số 75 Huỳnh Thúc Kháng vách Công ty VT Hành khách Đường sắt Sài Gòn, phường Bến Thành;
5. Lề đường Lê Lợi vách Bệnh viện Sài Gòn, phường Bến Thành; 
6. Lề đường Pasteur vách công trình Saigon Center đoạn từ Tôn Thất Thuyết đến Huỳnh Thúc Kháng, phường Bến Nghé; 
7. Lề đường Pasteur vách chùa Ấn Giáo, phường Bến Nghé; 
8. Lề đường Tôn Thất Thuyết vách chùa Ấn Giáo, phường Bến Nghé; 
9. Lề đường trước số 62Bis - 62B Huỳnh Thúc Kháng, phường Bến Nghé; 
10. Lề đường Huỳnh Thúc Kháng vách trường CĐ Kỹ thuật Cao Thắng đoạn từ Pasteur đến Nam Kỳ Khởi Nghĩa, phường Bến Nghé.
Đường dây nóng để người dân phản ánh các vấn đề liên quan đến việc thu phí giữ xe vượt quy định hoặc các vấn đề liên quan đến an ninh trật tự, an toàn giao thông và vệ sinh môi trường: (08) 39 816371. ',
106.7002217, 10.7710751, 17, N'Thành phố Hồ Chí Minh', 1, 2, 8, 0, 0, 0, 5, 100, 'Ham Nghi Ho Chi Minh',10150)
SELECT * FROM Place
-----------
INSERT INTO EventKind (Description, Kind) VALUES(N'Không có sự kiện', 'None')
SELECT * FROM EventKind
-----------
INSERT INTO Event (Title, Description, Url, EventKindId, PlaceId, Priority) VALUES('NA', 'No event', 'Null', 0, 0, 0)
SELECT * FROM Event