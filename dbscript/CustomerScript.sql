USE [Customer]
GO
/****** Object:  Table [dbo].[Customerdetails]    Script Date: 01-03-2022 15:04:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customerdetails](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fullname] [varchar](45) NOT NULL,
	[phone1] [varchar](45) NULL,
	[email] [varchar](45) NULL,
	[dob] [date] NULL,
	[details] [varchar](45) NULL,
	[address] [varchar](45) NULL,
	[addedon] [datetime] NULL,
	[updatedon] [datetime] NULL,
	[addedby] [varchar](45) NULL,
	[updatedby] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[fullname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usermaster]    Script Date: 01-03-2022 15:04:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usermaster](
	[idusermaster] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](45) NOT NULL,
	[Name] [varchar](100) NULL,
	[password] [varchar](45) NULL,
	[mode] [varchar](4) NULL,
	[isactive] [bit] NULL,
	[role] [varchar](45) NULL,
	[reason] [varchar](250) NULL,
	[addedon] [datetime] NULL,
	[adddby] [varchar](45) NULL,
	[updatedon] [datetime] NULL,
	[updatedby] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[idusermaster] ASC,
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[usermaster] ON 
GO
INSERT [dbo].[usermaster] ([idusermaster], [username], [Name], [password], [mode], [isactive], [role], [reason], [addedon], [adddby], [updatedon], [updatedby]) VALUES (1, N'mamta', N'MAMTA', N'123', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[usermaster] OFF
GO
ALTER TABLE [dbo].[usermaster] ADD  DEFAULT (NULL) FOR [Name]
GO
ALTER TABLE [dbo].[usermaster] ADD  DEFAULT (NULL) FOR [password]
GO
ALTER TABLE [dbo].[usermaster] ADD  DEFAULT (NULL) FOR [mode]
GO
ALTER TABLE [dbo].[usermaster] ADD  DEFAULT (NULL) FOR [isactive]
GO
ALTER TABLE [dbo].[usermaster] ADD  DEFAULT (NULL) FOR [role]
GO
ALTER TABLE [dbo].[usermaster] ADD  DEFAULT (NULL) FOR [reason]
GO
ALTER TABLE [dbo].[usermaster] ADD  DEFAULT (NULL) FOR [addedon]
GO
ALTER TABLE [dbo].[usermaster] ADD  DEFAULT (NULL) FOR [adddby]
GO
ALTER TABLE [dbo].[usermaster] ADD  DEFAULT (NULL) FOR [updatedon]
GO
ALTER TABLE [dbo].[usermaster] ADD  DEFAULT (NULL) FOR [updatedby]
GO
/****** Object:  StoredProcedure [dbo].[p_CheckCredential]    Script Date: 01-03-2022 15:04:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[p_CheckCredential](@p_pid int, @p_email varchar(45),@p_pawd varchar(45))
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
IF @p_pid = 0 
       SELECT  idusermaster , username , password ,mode , isactive , role , reason , Name 
FROM  usermaster  where  username  =@p_email and  password =@p_pawd;
else if
  @p_pid = 1 
       SELECT   idusermaster ,username ,password , mode , isactive , role , reason , Name 
FROM   usermaster  ;
    

END
GO
/****** Object:  StoredProcedure [dbo].[p_customerdetails]    Script Date: 01-03-2022 15:04:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE  [dbo].[p_customerdetails] (@p_pid int, 
@p_id int ,
  @p_fullname varchar(45),
  @p_phone1 varchar(15) ,
  @p_email varchar(45) ,
  @p_dob varchar(45),
  @p_details varchar(45),
  @p_address varchar(45)
)
AS
BEGIN
 IF @p_pid = 0
 
 select id from Customerdetails where fullname=@p_fullname;
   
else if
  @p_pid = 1 
   INSERT INTO   Customerdetails
( fullname , phone1 ,email ,dob , details , address , addedon , addedby )
VALUES
( @p_fullname,@p_phone1 , @p_email ,@p_dob  ,@p_details  ,@p_address  ,
 GETDATE()  ,'MAMTA'  );
 
     else if   @p_pid = 2 
     UPDATE   Customerdetails 
SET   phone1 =@p_phone1,  email =@p_email,dob=@p_dob,details=@p_details, address =@p_address,
 updatedon  =GETDATE(), updatedby  ='MAMTA'
WHERE  id  = @p_id;
 
  else if   @p_pid =3  
    
 SELECT  id ,  fullname , phone1 ,dob, details , email , address 
 FROM   Customerdetails  where  id = @p_id;

  else if   @p_pid =4  
    
  SELECT  id ,  fullname , phone1  , email , dob,details , address 
  FROM   Customerdetails 
 

 
    
END

GO
