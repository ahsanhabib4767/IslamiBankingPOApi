USE [OBLILPO]
GO
/****** Object:  Table [dbo].[Parameter_Cridential]    Script Date: 02-10-2022 11:44:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parameter_Cridential](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Roles] [varchar](50) NULL,
 CONSTRAINT [PK_Parameter_Cridential] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[POData]    Script Date: 02-10-2022 11:44:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[POData](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PONumber] [varchar](50) NULL,
	[InFavorOf] [varchar](50) NULL,
	[onAccountOf] [varchar](50) NULL,
	[Amount] [varchar](50) NULL,
	[Rate] [varchar](50) NULL,
	[Duration] [varchar](50) NULL,
	[Date] [datetime] NULL,
	[MatureDate] [datetime] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[MonthorYear] [varchar](50) NULL,
 CONSTRAINT [PK_POData] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PODataMMIDS]    Script Date: 02-10-2022 11:44:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PODataMMIDS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PONumber] [varchar](50) NOT NULL,
	[InFavorOf] [varchar](50) NULL,
	[onAccountOf] [varchar](50) NULL,
	[Amount] [varchar](50) NULL,
	[MonthSt] [varchar](50) NULL,
	[Rate] [varchar](50) NULL,
	[Duration] [varchar](50) NULL,
	[Date] [datetime] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[MatureDate] [datetime] NULL,
 CONSTRAINT [PK_PODataMMIDS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PODataMSSM]    Script Date: 02-10-2022 11:44:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PODataMSSM](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PONumber] [varchar](50) NOT NULL,
	[InFavorOf] [varchar](50) NULL,
	[onAccountOf] [varchar](50) NULL,
	[Amount] [varchar](50) NULL,
	[MonthSt] [varchar](50) NULL,
	[Rate] [varchar](50) NULL,
	[Duration] [varchar](50) NULL,
	[Date] [datetime] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[MatureDate] [datetime] NULL,
 CONSTRAINT [PK_PODataMSSM] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PODataPaymentOdr]    Script Date: 02-10-2022 11:44:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PODataPaymentOdr](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PONumber] [varchar](50) NULL,
	[InFavorOf] [varchar](50) NULL,
	[onAccountOf] [varchar](50) NULL,
	[Amount] [varchar](50) NULL,
	[Date] [datetime] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_PODataPaymentOdr] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PODataPaymentOrderMTDR]    Script Date: 02-10-2022 11:44:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PODataPaymentOrderMTDR](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PONumber] [varchar](50) NULL,
	[InFavorOf] [varchar](50) NULL,
	[onAccountOf] [varchar](50) NULL,
	[Amount] [varchar](50) NULL,
	[Date] [datetime] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[Month_data] [varchar](50) NULL,
 CONSTRAINT [PK_PODataPaymentOrder] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[spPOElementsDataGet]    Script Date: 02-10-2022 11:44:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spPOElementsDataGet]



AS

BEGIN
	
select * from  POData
	
END
GO
/****** Object:  StoredProcedure [dbo].[spPOElementsDataGetMMIDS]    Script Date: 02-10-2022 11:44:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[spPOElementsDataGetMMIDS]



AS

BEGIN
	
select id,PONumber,Amount,InFavorOf,onAccountOf,Rate,Duration,MonthSt,Date,MatureDate,ModifiedOn,CreatedOn from  [dbo].[PODataMMIDS]
	
END

--exec [dbo].[spPOElementsDataGetMSSM]
GO
/****** Object:  StoredProcedure [dbo].[spPOElementsDataGetMSSM]    Script Date: 02-10-2022 11:44:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spPOElementsDataGetMSSM]



AS

BEGIN
	
select id,PONumber,Amount,InFavorOf,onAccountOf,Rate,Duration,MonthSt,Date,ModifiedOn,CreatedOn,MatureDate from  [dbo].[PODataMSSM]
	
END

--exec [dbo].[spPOElementsDataGetMSSM]
GO
/****** Object:  StoredProcedure [dbo].[spPOElementsDataGetPaymentOdr]    Script Date: 02-10-2022 11:44:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spPOElementsDataGetPaymentOdr]



AS

BEGIN
	
select * from  [dbo].[PODataPaymentOdr] order by CreatedOn desc
	
END
GO
/****** Object:  StoredProcedure [dbo].[spPOElementsDataINsert]    Script Date: 02-10-2022 11:44:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spPOElementsDataINsert]

@PONumber VARCHAR(50)=NULL, 
@InFavorOf  VARCHAR(50)=NULL,
@onAmmount VARCHAR(4)=NULL,  
@Amount VARCHAR(15)=NULL,  
@Rate VARCHAR(4)=NULL,  
@Duration VARCHAR(15)=NULL,  
@Date  datetime =NULL,
@MatureDate datetime =NULL,
@MonthorYear varchar(15) = null,
@Vmsg_code VARCHAR(5) OUTPUT,    
@VMSG VARCHAR(200) OUTPUT,
@ID int output

AS
 DECLARE @idd table([id] int)
BEGIN TRANSACTION 
BEGIN
	INSERT INTO POData(PONumber,InFavorOf,onAccountOf,Amount,Rate,Duration,Date,MatureDate,CreatedOn,ModifiedOn,MonthorYear)
	OUTPUT inserted.id into @idd
	Values(@PONumber,@InFavorOf,@onAmmount,@Amount,@Rate,@Duration,@Date,@MatureDate,GETDATE(),GETDATE(),@MonthorYear)
	
	IF (@@ERROR<>0) GOTO ErrorFound 
	select @Vmsg_code = 'OK', @VMSG = 'Data Inserted Successfully' ,@ID = (select id from @idd)

	SET NOCOUNT ON;

	if @Vmsg_code='ERR' 
		Begin
		GOTO ErrorFound
END
  COMMIT TRANSACTION    

  select @Vmsg_code = 'OK', @VMSG = 'Data Inserted Successfully.',@ID = (select id from @idd)
RETURN 

ErrorFound:      
 BEGIN      
  --set nocount off        
  ROLLBACK TRANSACTION     
  select @Vmsg_code = '0001', @VMSG = 'Data Insert Fail'     
  RETURN       
 END      

  
	
END
GO
/****** Object:  StoredProcedure [dbo].[spPOElementsDataINsertMMIDS]    Script Date: 02-10-2022 11:44:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spPOElementsDataINsertMMIDS]

@PONumber VARCHAR(50)=NULL, 
@InFavorOf  VARCHAR(50)=NULL,
@onAmmount VARCHAR(50)=NULL,  
@Amount VARCHAR(15)=NULL,  
@Rate VARCHAR(10)=NULL,  
@Duration VARCHAR(15)=NULL,
@MatureDate datetime = null,
@Date  datetime =NULL,
@Vmsg_code VARCHAR(5) OUTPUT,    
@VMSG VARCHAR(200) OUTPUT,
@ID int output

AS
 DECLARE @idd table([id] int)
BEGIN TRANSACTION 
BEGIN
	INSERT INTO PODataMMIDS(PONumber,InFavorOf,onAccountOf,Amount,Rate,Duration,Date,MatureDate,CreatedOn,ModifiedOn)
	OUTPUT inserted.id into @idd
	Values(@PONumber,@InFavorOf,@onAmmount,@Amount,@Rate,@Duration,@Date,@MatureDate,GETDATE(),GETDATE())
	
	IF (@@ERROR<>0) GOTO ErrorFound 
	select @Vmsg_code = 'OK', @VMSG = 'Data Inserted Successfully' ,@ID = (select id from @idd)

	SET NOCOUNT ON;

	if @Vmsg_code='ERR' 
		Begin
		GOTO ErrorFound
END
  COMMIT TRANSACTION    

  select @Vmsg_code = 'OK', @VMSG = 'Data Inserted Successfully.',@ID = (select id from @idd)
RETURN 

ErrorFound:      
 BEGIN      
  --set nocount off        
  ROLLBACK TRANSACTION     
  select @Vmsg_code = '0001', @VMSG = 'Data Insert Fail'     
  RETURN       
 END      

  
	
END
GO
/****** Object:  StoredProcedure [dbo].[spPOElementsDataINsertMSSM]    Script Date: 02-10-2022 11:44:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spPOElementsDataINsertMSSM]

@PONumber VARCHAR(50)=NULL, 
@InFavorOf  VARCHAR(50)=NULL,
@onAmmount VARCHAR(50)=NULL,  
@Amount VARCHAR(30)=NULL,  
@Rate VARCHAR(10)=NULL,  
@Duration VARCHAR(15)=NULL,
@MatureDate datetime = null,
@Date  datetime =NULL,
@Vmsg_code VARCHAR(5) OUTPUT,    
@VMSG VARCHAR(200) OUTPUT,
@ID int output

AS
 DECLARE @idd table([id] int)
 /*===================================*/
 IF(isNULL(@PONumber,'') <> '') 
BEGIN
	
	BEGIN
		SELECT @Vmsg_code = '0', @VMSG = 'PO Number is Empty',@ID=0
		RETURN
	END
END
 /*===================================*/
BEGIN TRANSACTION 
BEGIN
	INSERT INTO PODataMSSM(PONumber,InFavorOf,onAccountOf,Amount,Rate,Duration,Date,CreatedOn,ModifiedOn,MatureDate)
	OUTPUT inserted.id into @idd
	Values(@PONumber,@InFavorOf,@onAmmount,@Amount,@Rate,@Duration,@Date,GETDATE(),GETDATE(),@MatureDate)
	
	IF (@@ERROR<>0) GOTO ErrorFound 
	select @Vmsg_code = 'OK', @VMSG = 'Data Inserted Successfully' ,@ID = (select id from @idd)

	SET NOCOUNT ON;

	if @Vmsg_code='ERR' 
		Begin
		GOTO ErrorFound
END
  COMMIT TRANSACTION    

  select @Vmsg_code = 'OK', @VMSG = 'Data Inserted Successfully.',@ID = (select id from @idd)
RETURN 

ErrorFound:      
 BEGIN      
  --set nocount off        
  ROLLBACK TRANSACTION     
  select @Vmsg_code = '0001', @VMSG = 'Data Insert Fail'     
  RETURN       
 END      

  
	
END
GO
/****** Object:  StoredProcedure [dbo].[spPOElementsDataINsertMTDR]    Script Date: 02-10-2022 11:44:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spPOElementsDataINsertMTDR]

@PONumber VARCHAR(50)=NULL, 
@InFavorOf  VARCHAR(50)=NULL,
@onAmmount VARCHAR(50)=NULL,  
@Amount VARCHAR(50)=NULL,
@Month VARCHAR(10)=NULL,  
@Date  datetime =NULL,
@Vmsg_code VARCHAR(5) OUTPUT,    
@VMSG VARCHAR(200) OUTPUT,
@ID int output

AS
 DECLARE @idd table([id] int)
BEGIN TRANSACTION 
BEGIN
	INSERT INTO PODataPaymentOrderMTDR(PONumber,InFavorOf,onAccountOf,Amount,Date,Month_data,CreatedOn,ModifiedOn)
	OUTPUT inserted.id into @idd
	Values(@PONumber,@InFavorOf,@onAmmount,@Amount,@Date,@Month,GETDATE(),GETDATE())
	
	IF (@@ERROR<>0) GOTO ErrorFound 
	select @Vmsg_code = 'OK', @VMSG = 'Data Inserted Successfully' ,@ID = (select id from @idd)

	SET NOCOUNT ON;

	if @Vmsg_code='ERR' 
		Begin
		GOTO ErrorFound
END
  COMMIT TRANSACTION    

  select @Vmsg_code = 'OK', @VMSG = 'Data Inserted Successfully.',@ID = (select id from @idd)
RETURN 

ErrorFound:      
 BEGIN      
  --set nocount off        
  ROLLBACK TRANSACTION     
  select @Vmsg_code = '0001', @VMSG = 'Data Insert Fail'     
  RETURN       
 END      

  
	
END
GO
/****** Object:  StoredProcedure [dbo].[spPOElementsDataINsertPayOdr]    Script Date: 02-10-2022 11:44:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spPOElementsDataINsertPayOdr]

@PONumber VARCHAR(50)=NULL, 
@InFavorOf  VARCHAR(200)=NULL,
@onAmmount VARCHAR(200)=NULL,  
@Amount VARCHAR(15)=NULL,
@Date  datetime =NULL,
@Vmsg_code VARCHAR(5) OUTPUT,    
@VMSG VARCHAR(200) OUTPUT,
@ID int output

AS
 DECLARE @idd table([id] int)
BEGIN TRANSACTION 
BEGIN
	INSERT INTO PODataPaymentOdr(PONumber,InFavorOf,onAccountOf,Amount,Date,CreatedOn,ModifiedOn)
	OUTPUT inserted.id into @idd
	Values(@PONumber,@InFavorOf,@onAmmount,@Amount,@Date,GETDATE(),GETDATE())
	
	IF (@@ERROR<>0) GOTO ErrorFound 
	select @Vmsg_code = 'OK', @VMSG = 'Data Inserted Successfully' ,@ID = (select id from @idd)

	SET NOCOUNT ON;

	if @Vmsg_code='ERR' 
		Begin
		GOTO ErrorFound
END
  COMMIT TRANSACTION    

  select @Vmsg_code = 'OK', @VMSG = 'Data Inserted Successfully.',@ID = (select id from @idd)
RETURN 

ErrorFound:      
 BEGIN      
  --set nocount off        
  ROLLBACK TRANSACTION     
  select @Vmsg_code = '0001', @VMSG = 'Data Insert Fail'     
  RETURN       
 END      

  
	
END
GO
/****** Object:  StoredProcedure [dbo].[spPOElementsDataUpdate]    Script Date: 02-10-2022 11:44:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[spPOElementsDataUpdate]

@PONumber VARCHAR(50)=NULL, 
@InFavorOf  VARCHAR(50)=NULL,
@onAccount VARCHAR(4)=NULL,  
@Amount VARCHAR(15)=NULL,    
@Date  datetime =NULL,
@id int ,
@Vmsg_code VARCHAR(5) OUTPUT,    
@VMSG VARCHAR(200) OUTPUT

AS

BEGIN TRANSACTION 
BEGIN
	Update POData set PONumber = @PONumber,InFavorOf=@InFavorOf,onAccountOf=@onAccount,Amount=@Amount,Date=@Date,ModifiedOn=GETDATE() 
	where id = @id
	
	IF (@@ERROR<>0) GOTO ErrorFound 
	select @Vmsg_code = 'OK', @VMSG = 'Data Inserted Successfully'

	SET NOCOUNT ON;

	if @Vmsg_code='ERR' 
		Begin
		GOTO ErrorFound
END
  COMMIT TRANSACTION    

  select @Vmsg_code = 'OK', @VMSG = 'Data Updated Successfully.'
RETURN 

ErrorFound:      
 BEGIN      
  --set nocount off        
  ROLLBACK TRANSACTION     
  select @Vmsg_code = '0001', @VMSG = 'Data Update Fail'     
  RETURN       
 END      

  
	
END
GO
/****** Object:  StoredProcedure [dbo].[spPOElementsDataUpdateMMIDS]    Script Date: 02-10-2022 11:44:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[spPOElementsDataUpdateMMIDS]

@PONumber VARCHAR(50)=NULL, 
@InFavorOf  VARCHAR(50)=NULL,
@onAmmount VARCHAR(50)=NULL,  
@Amount VARCHAR(15)=NULL,  
@Rate VARCHAR(10)=NULL,  
@Duration VARCHAR(15)=NULL,
@MatureDate datetime = null,
@Date  datetime =NULL,
@Vmsg_code VARCHAR(5) OUTPUT,    
@VMSG VARCHAR(200) OUTPUT,
@ID int

AS
 DECLARE @idd table([id] int)
BEGIN TRANSACTION 
BEGIN
	Update PODataMMIDS set

	PONumber = @PONumber,
	InFavorOf =@InFavorOf,
	onAccountOf = @onAmmount,
	Amount= @Amount,
	Rate = @Rate,
	Duration =@Duration,
	Date=@Date,
	MatureDate=@MatureDate,
	CreatedOn=GETDATE(),
	ModifiedOn = GETDATE()
	where id = @ID
	
	IF (@@ERROR<>0) GOTO ErrorFound 
	select @Vmsg_code = 'OK', @VMSG = 'Data Updated Successfully'

	SET NOCOUNT ON;

	if @Vmsg_code='ERR' 
		Begin
		GOTO ErrorFound
END
  COMMIT TRANSACTION    

  select @Vmsg_code = 'OK', @VMSG = 'Data Inserted Successfully.'
RETURN 

ErrorFound:      
 BEGIN      
  --set nocount off        
  ROLLBACK TRANSACTION     
  select @Vmsg_code = '0001', @VMSG = 'Data Insert Fail'     
  RETURN       
 END      

  
	
END
GO
