USE [Supply]
GO

 
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Schema]') AND type in (N'U'))  Drop Table [Schema] 
CREATE TABLE [dbo].[Schema](
	[Id] [int] IDENTITY(1, 1) NOT NULL , 
	[Version] [bigint] NOT NULL,
	[UtcDate]  [datetime] DEFAULT (GETUTCDATE()),
	[BuildNumber] [nvarchar](100)  , 
	[Status] [nvarchar](50) NULL ,
	[CreatedAt] [datetime] not null default(getdate()) ,
	[UpdatedAt] [datetime]  not null default(getdate())  
) ;
INSERT [Schema] ([Version] ) Values(1 )
GO

 
IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertLog]') AND type IN ( N'P', N'PC' ) ) 	DROP PROCEDURE [dbo].[InsertLog]
GO 
IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertLog2]') AND type IN ( N'P', N'PC' ) ) DROP PROCEDURE [dbo].[InsertLog2] 
GO  
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Log]') AND type in (N'U'))  Drop Table [Log] 
GO
CREATE TABLE [dbo].[Log]
	(
	  [Id] [int] IDENTITY(1, 1) NOT NULL, 
	  [Description] [nvarchar](MAX) NULL,
	  [Summary] [nvarchar](100) NULL,
	  [Level] [nvarchar](16) NULL,
	  [Logger] [nvarchar](128) NULL,
	  [Status] [nvarchar](50) NULL,
	  [IpAddress] [nvarchar](100) NULL,
	  [Browser] [nvarchar](100) NULL,
	  [Server] [nvarchar](100) NULL,
	  [Session] [nvarchar](100) NULL,
	  [UserName] [nvarchar](100) NULL, 
	  [Application] [nvarchar](100) NULL,
	  [Type] [nvarchar](100) NULL,
	  [Email] [nvarchar](100),   
	  [Layout] [nvarchar](MAX) NULL,
	  [UpdatedAt] [datetime]  not null default(getdate())  
) ;  
GO


CREATE PROCEDURE InsertLog (@description [NVARCHAR](MAX), @summary [NVARCHAR](100), @level [NVARCHAR](16), @logger [NVARCHAR](128), @status [NVARCHAR](50), @ipAddress [NVARCHAR](100), @browser [NVARCHAR](100), @server [NVARCHAR](100), @session [NVARCHAR](100), @userName [NVARCHAR](100), @application [NVARCHAR](100), @type [NVARCHAR](100), @email [NVARCHAR](100), @layout [NVARCHAR](MAX)) 
AS  
	SET NOCOUNT ON 
	declare @errorMessage nvarchar(4000),@errorSeverity INT,@errorState INT 
	declare @maxRecords INT
	set @maxRecords = 1000
	BEGIN TRY 
		DECLARE @idPosition INT 

		IF ( (SELECT COUNT(*) FROM [Log]) > @maxRecords ) 
		BEGIN 
			--SELECT @idPosition = MAX(d.id) FROM (SELECT TOP @removeRecords id FROM [Log] ORDER BY [UpdatedAt]) d  
			--DELETE FROM [Log] WHERE id <= @idPosition  
			DELETE FROM [Log] WHERE ID in (SELECT TOP 100 ID FROM [Log] ORDER BY [UpdatedAt])
		END 

		INSERT INTO [Log] 	 ([Description], [Summary], [Level], [Logger], [Status], [IpAddress], [Browser], [Server], [Session], [UserName], [Application], [Type], [Email], [Layout], [UpdatedAt]) 
		VALUES ( @description, @summary, @level, @logger, @status, @ipAddress, @browser, @server, @session, @userName, @application, @type, @email, @layout, Sysutcdatetime()) 
	END TRY
	BEGIN CATCH 
		SELECT @ErrorMessage = ERROR_MESSAGE(),	@ErrorSeverity = ERROR_SEVERITY(),	@ErrorState = ERROR_STATE() 
		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState 	) 
	END CATCH 
GO









 
 
IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Config]')  AND type IN ( N'U' ) )  DROP TABLE [Config]
CREATE TABLE [dbo].[Config](
	[ID] [int] IDENTITY(1,1) NOT NULL  PRIMARY KEY  CLUSTERED (	[ID] ASC) ON [PRIMARY],
	[Name] [nvarchar](50) NULL,  
	[Value] [nvarchar](50) NULL,
	[CreatedAt] [datetime] not null default(getdate()) ,
	[UpdatedAt] [datetime]  not null default(getdate()) 
	) ON [PRIMARY]
GO
INSERT INTO  [Config] ( [Name], [Value] ) VALUES  
('BrainTree-MerchantId', 'BrainTree-MerchantId'  )  ,
('BrainTree-PublicKey', 'BrainTree-PublicKey'  )  ,
('BrainTree-PrivateKey', 'BrainTree-PrivateKey'  ) 
GO

 


IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Movies]')  AND type IN ( N'U' ) )  DROP TABLE [Movies]
CREATE TABLE [dbo].[Movies](
	[ID] [int] IDENTITY(1,1) NOT NULL  PRIMARY KEY  CLUSTERED (	[ID] ASC) ON [PRIMARY],
	[Title] [nvarchar](50) NULL,  
	[Genre] [nvarchar](50) NULL, 
	[Price] [money] NULL, 
	[Rating] [nvarchar](5) NULL,  
	[CreatedAt] [datetime] not null default(getdate()) ,
	[UpdatedAt] [datetime]  not null default(getdate()) 
	) ON [PRIMARY]
GO
INSERT INTO  [Movies] ([Title], [Genre], [Price], [Rating]) VALUES  
('The Lost Boys', 'Action', 3.99, 'G'  )  ,
('When Harry Met Sally', 'Romantic Comedy', 3.99, 'G'  ) ,
('Raiders of the lost arc', 'Action', 3.99, 'G'  ) ,
('Ghostbusters', 'Comedy', 4.99, 'G'  )  ,
('Ghostbusters 2', 'Comedy', 2.99, 'G'  ) ,
('Spaceballs', 'Comedy', 7.99, 'G'  )  		
GO					    
 

  

IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Customers]')  AND type IN ( N'U' ) )  DROP TABLE [Customers] 
CREATE TABLE [dbo].[Customers](
	[ID] [int] IDENTITY(1,1) NOT NULL  PRIMARY KEY  CLUSTERED (	[ID] ASC) ON [PRIMARY],
	[FirstName] [nvarchar](55)  ,  
	[LastName] [nvarchar](55)  ,  
	[Email] [nvarchar](55)  ,  
	[Address] [nvarchar](55)  ,  
	[CreatedAt] [datetime] NULL default(getdate()),
	[UpdatedAt] [datetime] NULL default(getdate()) 
) ON [PRIMARY]
GO

INSERT INTO  [Customers] ([Email], [FirstName], [LastName] ) VALUES  
('cust1@test.com'	, 'Joe'		, 'Smith'	),
('Bart@test.com'	, 'Bart'	, 'Simpson'	),
('Homer@test.com'	, 'Homer'	, 'Simpson'	),
('Barney@test.com'	, 'Barney'	, 'Gumble'  ) 
GO
    
	
IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Product]')  AND type IN ( N'U' ) ) 	
	drop table Product
go



IF Not EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Product]')  AND type IN ( N'U' ) ) 
begin 
	CREATE TABLE [dbo].[Product](
		[Id] [int] IDENTITY(1,1) NOT NULL  PRIMARY KEY  CLUSTERED (	[Id] ASC) ON [PRIMARY],
		[Title] [nvarchar](50) NULL,  
		[Description] [nvarchar](500) NULL, 
		[ImageUrl] [nvarchar](200) NULL, 
		[PdfUrl] [nvarchar](200) NULL, 
		[Price] [money] NULL, 
		[MemberPrice] [money] NULL,  
		[CreatedAt] [datetime] not null default(getdate()) ,
		[UpdatedAt] [datetime]  not null default(getdate()) 
		) ON [PRIMARY] 
	INSERT INTO  [Product] ([Title], ImageUrl,  [Price], [MemberPrice]) VALUES  
	('Cable Retractor', 'Cable_Retractor.pdf' ,   13.99, 7.99   )  ,
	('Cell Filler',  'Cell_Filler.pdf' , 13.99, 7.99  ) ,
	('Forklift Attachment', 'Forklift_Attachment.pdf',  13.99, 7.99  ) ,
	('Hollow Post Drill',   'Hollow_Post_Drill.pdf',    14.99, 7.99  )  ,
	('Lifiting Beam',       'Lifiting_Beam.pdf',        12.99, 7.99  ) ,
	('PVC Syringe',         'PVC_Syringe.pdf',          17.99, 7.99  )  
end
		
GO					    
 

