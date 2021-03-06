USE [master]
GO
/****** Object:  Database [CITITO]    Script Date: 6/11/2018 3:59:16 PM ******/
CREATE DATABASE [CITITO]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CITITO', FILENAME = N'X:\MSSQL\DATA\CITITO.mdf' , SIZE = 368640KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CITITO_log', FILENAME = N'Y:\MSSQL\LOG\CITITO_log.ldf' , SIZE = 16080768KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CITITO] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CITITO].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CITITO] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CITITO] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CITITO] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CITITO] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CITITO] SET ARITHABORT OFF 
GO
ALTER DATABASE [CITITO] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CITITO] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CITITO] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CITITO] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CITITO] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CITITO] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CITITO] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CITITO] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CITITO] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CITITO] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CITITO] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CITITO] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CITITO] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CITITO] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CITITO] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CITITO] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CITITO] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CITITO] SET RECOVERY FULL 
GO
ALTER DATABASE [CITITO] SET  MULTI_USER 
GO
ALTER DATABASE [CITITO] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CITITO] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CITITO] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CITITO] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CITITO] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CITITO', N'ON'
GO
USE [CITITO]
GO
/****** Object:  User [COLOMBO\JZ7]    Script Date: 6/11/2018 3:59:16 PM ******/
CREATE USER [COLOMBO\JZ7] FOR LOGIN [COLOMBO\JZ7] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [COLOMBO\7AO]    Script Date: 6/11/2018 3:59:16 PM ******/
CREATE USER [COLOMBO\7AO] FOR LOGIN [COLOMBO\7AO] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [CITITO_SUSER]    Script Date: 6/11/2018 3:59:16 PM ******/
CREATE USER [CITITO_SUSER] FOR LOGIN [CITITO_SUSER] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [CITITO_LUSER]    Script Date: 6/11/2018 3:59:16 PM ******/
CREATE USER [CITITO_LUSER] FOR LOGIN [CITITO_LUSER] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [COLOMBO\JZ7]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [COLOMBO\JZ7]
GO
ALTER ROLE [db_datareader] ADD MEMBER [COLOMBO\JZ7]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [COLOMBO\JZ7]
GO
ALTER ROLE [db_owner] ADD MEMBER [COLOMBO\7AO]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [COLOMBO\7AO]
GO
ALTER ROLE [db_datareader] ADD MEMBER [COLOMBO\7AO]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [COLOMBO\7AO]
GO
ALTER ROLE [db_owner] ADD MEMBER [CITITO_SUSER]
GO
/****** Object:  Table [dbo].[P_RES_Import]    Script Date: 6/11/2018 3:59:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[P_RES_Import](
	[UID] [varchar](50) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[P_RES] [varchar](50) NOT NULL,
 CONSTRAINT [PK_P_RES_Import] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_CITITOVersion]    Script Date: 6/11/2018 3:59:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_CITITOVersion](
	[Version] [varchar](1000) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[Developer] [varchar](1000) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_IDLEDetail]    Script Date: 6/11/2018 3:59:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_IDLEDetail](
	[IDLE_Index] [bigint] IDENTITY(1,1) NOT NULL,
	[IDLE_ID] [varchar](50) NOT NULL,
	[IDLE_InDate] [datetime] NOT NULL,
	[IDLE_OutDate] [datetime] NULL,
	[IDLE_Reason] [varchar](800) NOT NULL,
	[IDLE_UID] [varchar](50) NOT NULL,
	[IDLE_MID] [varchar](50) NOT NULL,
	[IDLE_PIC] [varchar](50) NOT NULL,
	[IDLE_Apporval] [int] NOT NULL,
	[IDLE_ApprovalTime] [datetime] NULL,
	[IDLE_Hours] [float] NULL,
	[IDLE_LogCreateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_IDLEHeader]    Script Date: 6/11/2018 3:59:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_IDLEHeader](
	[IDLE_Index] [bigint] IDENTITY(1,1) NOT NULL,
	[IDLE_ID] [varchar](50) NOT NULL,
	[IDLE_Project] [varchar](50) NOT NULL,
	[IDLE_UID] [varchar](50) NOT NULL,
	[IDLE_MID] [varchar](50) NOT NULL,
	[IDLE_PIC] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_IDLEHeader] PRIMARY KEY CLUSTERED 
(
	[IDLE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_IDLEReason]    Script Date: 6/11/2018 3:59:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_IDLEReason](
	[IDLE_ID] [int] IDENTITY(1,1) NOT NULL,
	[IDLE_Reason] [varchar](800) NOT NULL,
 CONSTRAINT [PK_tbl_IDLEReason] PRIMARY KEY CLUSTERED 
(
	[IDLE_Reason] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_ManagerDetail]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ManagerDetail](
	[M_Index] [bigint] IDENTITY(1,1) NOT NULL,
	[M_UID] [varchar](50) NOT NULL,
	[M_Project] [varchar](50) NOT NULL,
	[M_Project_Availability] [varchar](50) NOT NULL,
	[M_Activate_Date] [datetime] NOT NULL,
	[M_Inactivate_Date] [datetime] NULL,
	[PIC_UID] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_ManagerDetail_1] PRIMARY KEY CLUSTERED 
(
	[M_UID] ASC,
	[M_Project] ASC,
	[M_Project_Availability] ASC,
	[M_Activate_Date] ASC,
	[PIC_UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_ManagerHeader]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ManagerHeader](
	[M_Index] [bigint] IDENTITY(1,1) NOT NULL,
	[M_UID] [varchar](50) NOT NULL,
	[M_Name] [varchar](200) NOT NULL,
	[M_Password] [varchar](1000) NOT NULL,
	[M_AccessLevel] [varchar](50) NOT NULL,
	[M_Availability] [int] NOT NULL,
	[M_Activate_Date] [datetime] NULL,
	[M_Inactivate_Date] [datetime] NULL,
 CONSTRAINT [PK_tbl_ManagerHeader] PRIMARY KEY CLUSTERED 
(
	[M_UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_PCPDetail]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_PCPDetail](
	[PCPD_Index] [bigint] IDENTITY(1,1) NOT NULL,
	[PCP_ID] [varchar](50) NOT NULL,
	[PCP_File] [varchar](500) NOT NULL,
	[PCP_FileSize] [bigint] NOT NULL,
	[PCP_Status] [int] NOT NULL,
	[PCP_Project] [varchar](50) NOT NULL,
	[Task_UOM] [varchar](100) NOT NULL,
	[Task_Quota] [bigint] NOT NULL,
	[PCP_StartDate] [datetime] NOT NULL,
	[PCP_EndDate] [datetime] NULL,
	[PCP_CreatorUID] [varchar](50) NOT NULL,
	[PC_ProcessCode] [varchar](100) NOT NULL,
	[Task_ID] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_PCPHeader]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_PCPHeader](
	[PCP_Index] [bigint] IDENTITY(1,1) NOT NULL,
	[PCP_ID] [varchar](50) NOT NULL,
	[PC_ProcessCode] [varchar](100) NOT NULL,
	[PCP_Shipment] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_tbl_PCPHeader_1] PRIMARY KEY CLUSTERED 
(
	[PCP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_PICDetail]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_PICDetail](
	[PIC_Index] [bigint] IDENTITY(1,1) NOT NULL,
	[PIC_UID] [varchar](50) NOT NULL,
	[PIC_Name] [varchar](200) NOT NULL,
	[PIC_Password] [varchar](1000) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_PICHeader]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_PICHeader](
	[PIC_Index] [bigint] IDENTITY(1,1) NOT NULL,
	[PIC_UID] [varchar](50) NOT NULL,
	[PIC_AccessLevel] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_PICHeader] PRIMARY KEY CLUSTERED 
(
	[PIC_UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_ProcessCodeHeader]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ProcessCodeHeader](
	[PIC_Project] [varchar](50) NOT NULL,
	[PC_ProcessCode] [varchar](100) NOT NULL,
	[PIC_UID] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_ProcessCodeHeader] PRIMARY KEY CLUSTERED 
(
	[PC_ProcessCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_ProjectDetail]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ProjectDetail](
	[Project_Index] [bigint] IDENTITY(1,1) NOT NULL,
	[ProjectName] [varchar](50) NOT NULL,
	[PIC_UID] [varchar](50) NOT NULL,
	[SkipOutputValidation] [int] NULL,
 CONSTRAINT [PK_tbl_ProjectDetail] PRIMARY KEY CLUSTERED 
(
	[ProjectName] ASC,
	[PIC_UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_PTR_QA_StdRates]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_PTR_QA_StdRates](
	[PTR_Index] [bigint] IDENTITY(1,1) NOT NULL,
	[PTR_Resources] [varchar](50) NOT NULL,
	[PTR_Location] [varchar](50) NOT NULL,
	[PTR_DC] [varchar](50) NOT NULL,
	[PTR_DepartmentName] [varchar](1000) NOT NULL,
	[PTR_Min] [float] NOT NULL,
	[PTR_Max] [float] NOT NULL,
	[PTR_HC] [float] NOT NULL,
	[PTR_RT01] [float] NULL,
	[PTR_OT01] [float] NULL,
	[PTR_SP01] [float] NULL,
 CONSTRAINT [PK_tbl_PTR_QA_StdRates] PRIMARY KEY CLUSTERED 
(
	[PTR_Resources] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_QueryLog]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_QueryLog](
	[Index] [bigint] IDENTITY(1,1) NOT NULL,
	[WorkDate] [datetime] NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[ExecutedTime] [varchar](50) NULL,
	[QueryOwner] [varchar](150) NULL,
	[Workstation] [varchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Report_TempDailyX3Project]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Report_TempDailyX3Project](
	[WORKDATE] [date] NULL,
	[PCP_Project] [varchar](50) NULL,
	[TR_UID] [varchar](50) NULL,
	[TR_MID] [varchar](50) NULL,
	[TR_PIC] [varchar](50) NULL,
	[WORKED_HOURS] [float] NULL,
	[ACTUAL_WORKED_HOURS] [float] NULL,
	[USER_OUTPUT] [float] NULL,
	[ACTUAL_OUTPUT] [float] NULL,
	[APPROVED_IDLE] [float] NULL,
	[SUM_OF_X1] [float] NULL,
	[Y] [float] NULL,
	[X3] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Report_TempDailyX3Task]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Report_TempDailyX3Task](
	[WORKDATE] [date] NULL,
	[PCP_Project] [varchar](50) NULL,
	[PC_ProcessCode] [varchar](100) NULL,
	[Task_ID] [varchar](50) NULL,
	[Task_Description] [varchar](500) NULL,
	[TR_UID] [varchar](50) NULL,
	[TR_MID] [varchar](50) NULL,
	[TR_PIC] [varchar](50) NULL,
	[WORKED_HOURS] [float] NULL,
	[ACTUAL_WORKED_HOURS] [float] NULL,
	[USER_OUTPUT] [float] NULL,
	[ACTUAL_OUTPUT] [float] NULL,
	[APPROVED_IDLE] [float] NULL,
	[SUM_OF_X1] [float] NULL,
	[Y] [float] NULL,
	[X3] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Report_TempDailyX3Users]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Report_TempDailyX3Users](
	[WORKDATE] [date] NULL,
	[TR_UID] [varchar](50) NULL,
	[TR_MID] [varchar](50) NULL,
	[TR_PIC] [varchar](50) NULL,
	[WORKED_HOURS] [float] NULL,
	[ACTUAL_WORKED_HOURS] [float] NULL,
	[USER_OUTPUT] [float] NULL,
	[ACTUAL_OUTPUT] [float] NULL,
	[APPROVED_IDLE] [float] NULL,
	[SUM_OF_X1] [float] NULL,
	[Y] [float] NULL,
	[X3] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Report_TempIDLEAndWastage]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Report_TempIDLEAndWastage](
	[UID] [nvarchar](50) NULL,
	[MID] [nvarchar](50) NULL,
	[PIC] [nvarchar](50) NULL,
	[WORKDATE] [datetime] NULL,
	[FIRST_LOGIN] [datetime] NULL,
	[LAST_LOGOUT] [datetime] NULL,
	[AMSDIFF] [float] NULL,
	[FIRST_TASKED-IN] [datetime] NULL,
	[LAST_TASKED-OUT] [datetime] NULL,
	[TASKDIFF] [float] NULL,
	[APPROVED_IDLE] [float] NULL,
	[WASTE] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Report_TempidleDetails]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Report_TempidleDetails](
	[IDLE_Index] [bigint] NULL,
	[WORKDATE] [date] NULL,
	[IDLE_ID] [varchar](100) NULL,
	[IDLE_UID] [varchar](50) NULL,
	[IDLE_InDate] [datetime] NULL,
	[IDLE_OutDate] [datetime] NULL,
	[IDLE_TIME] [float] NULL,
	[IDLE_Reason] [varchar](200) NULL,
	[IDLE_MID] [varchar](50) NULL,
	[IDLE_PIC] [varchar](50) NULL,
	[IDLE_Project] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Report_TempModifiedTaskDetails]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Report_TempModifiedTaskDetails](
	[TRM_ID] [varchar](100) NULL,
	[MODIFIED_OUTPUT] [float] NULL,
	[TRM_UID] [varchar](50) NULL,
	[TRM_MID] [varchar](50) NULL,
	[TRM_PIC] [varchar](50) NULL,
	[MODIFIED_HOURS] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Report_TempsumofidleDetails]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Report_TempsumofidleDetails](
	[WORKDATE] [date] NULL,
	[IDLE_UID] [varchar](50) NULL,
	[APPROVED_IDLE] [float] NULL,
	[PCP_Project] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Report_TemptaskDetails]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Report_TemptaskDetails](
	[RowNumber] [bigint] NULL,
	[TR_Index] [bigint] NULL,
	[WORKDATE] [date] NULL,
	[TR_ID] [varchar](100) NULL,
	[TR_UID] [varchar](50) NULL,
	[TR_InDate] [datetime] NULL,
	[TR_ActualTaskIn] [datetime] NULL,
	[TR_OutDate] [datetime] NULL,
	[WORKED_HOURS] [float] NULL,
	[LOGIN] [datetime] NULL,
	[LOGOUT] [datetime] NULL,
	[ACTUAL_WORKED_HOURS] [float] NULL,
	[TR_Status] [int] NULL,
	[TR_Apporval] [int] NULL,
	[TR_MID] [varchar](50) NULL,
	[TR_PIC] [varchar](50) NULL,
	[TR_Shipment] [varchar](1000) NULL,
	[TR_File] [varchar](500) NULL,
	[USER_OUTPUT] [float] NULL,
	[ACTUAL_OUTPUT] [float] NULL,
	[QUOTA] [float] NULL,
	[TR_UOM] [varchar](50) NULL,
	[PCP_ID] [varchar](50) NULL,
	[Task_ID] [varchar](50) NULL,
	[PC_ProcessCode] [varchar](50) NULL,
	[PCP_Project] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Report_TemptaskDetailsQUOTA_Updated]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Report_TemptaskDetailsQUOTA_Updated](
	[RowNumber] [bigint] NULL,
	[TR_Index] [bigint] NULL,
	[WORKDATE] [date] NULL,
	[TR_ID] [varchar](100) NULL,
	[TR_UID] [varchar](50) NULL,
	[TR_InDate] [datetime] NULL,
	[TR_ActualTaskIn] [datetime] NULL,
	[TR_OutDate] [datetime] NULL,
	[WORKED_HOURS] [float] NULL,
	[LOGIN] [datetime] NULL,
	[LOGOUT] [datetime] NULL,
	[ACTUAL_WORKED_HOURS] [float] NULL,
	[TR_Status] [int] NULL,
	[TR_Apporval] [int] NULL,
	[TR_MID] [varchar](50) NULL,
	[TR_PIC] [varchar](50) NULL,
	[TR_Shipment] [varchar](1000) NULL,
	[TR_File] [varchar](500) NULL,
	[USER_OUTPUT] [float] NULL,
	[ACTUAL_OUTPUT] [float] NULL,
	[QUOTA] [float] NULL,
	[TR_UOM] [varchar](50) NULL,
	[PCP_ID] [varchar](50) NULL,
	[Task_ID] [varchar](50) NULL,
	[PC_ProcessCode] [varchar](50) NULL,
	[PCP_Project] [varchar](50) NULL,
	[X1] [float] NULL,
	[Y] [float] NULL,
	[X3] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Report_TemptblDifference]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Report_TemptblDifference](
	[RowNumber] [bigint] NULL,
	[TR_Index] [bigint] NULL,
	[WORKDATE] [date] NULL,
	[TR_ID] [varchar](100) NULL,
	[TR_UID] [varchar](50) NULL,
	[TR_InDate] [datetime] NULL,
	[TR_ActualTaskIn] [datetime] NULL,
	[TR_OutDate] [datetime] NULL,
	[TR_Status] [int] NULL,
	[TR_Apporval] [int] NULL,
	[TR_MID] [varchar](50) NULL,
	[TR_PIC] [varchar](50) NULL,
	[TR_Shipment] [varchar](1000) NULL,
	[TR_File] [varchar](500) NULL,
	[ACTUAL_OUTPUT] [float] NULL,
	[WORKED_HOURS] [float] NULL,
	[LOGIN] [datetime] NULL,
	[LOGOUT] [datetime] NULL,
	[AMS_DIFF] [float] NULL,
	[IDLE_InDate] [datetime] NULL,
	[IDLE_OutDate] [datetime] NULL,
	[IDLE_TIME] [float] NULL,
	[QUOTA] [float] NULL,
	[TR_UOM] [varchar](50) NULL,
	[PCP_ID] [varchar](50) NULL,
	[Task_ID] [varchar](50) NULL,
	[PC_ProcessCode] [varchar](50) NULL,
	[PCP_Project] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Report_TempX1AndY]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Report_TempX1AndY](
	[RowNumber] [bigint] NULL,
	[TR_Index] [bigint] NULL,
	[WORKDATE] [date] NULL,
	[TR_ID] [varchar](100) NULL,
	[TR_UID] [varchar](50) NULL,
	[WORKED_HOURS] [float] NULL,
	[LOGIN] [datetime] NULL,
	[LOGOUT] [datetime] NULL,
	[SUM_OF_AMS_HOURS] [float] NULL,
	[IDLE_HOURS] [float] NULL,
	[TR_Status] [int] NULL,
	[TR_Apporval] [int] NULL,
	[TR_MID] [varchar](50) NULL,
	[TR_PIC] [varchar](50) NULL,
	[TR_Shipment] [varchar](1000) NULL,
	[TR_File] [varchar](500) NULL,
	[USER_OUTPUT] [float] NULL,
	[ACTUAL_OUTPUT] [float] NULL,
	[QUOTA] [float] NULL,
	[ACTUAL_QUOTA] [float] NULL,
	[TR_UOM] [varchar](50) NULL,
	[PCP_ID] [varchar](50) NULL,
	[Task_ID] [varchar](50) NULL,
	[PC_ProcessCode] [varchar](50) NULL,
	[PCP_Project] [varchar](50) NULL,
	[X1] [float] NULL,
	[Y] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Report_TempX1AndY_DAY]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Report_TempX1AndY_DAY](
	[WORKDATE] [date] NULL,
	[TR_UID] [varchar](50) NULL,
	[WORKED_HOURS] [float] NULL,
	[SUM_OF_AMS_HOURS] [float] NULL,
	[IDLE_HOURS] [float] NULL,
	[USER_OUTPUT] [float] NULL,
	[ACTUAL_OUTPUT] [float] NULL,
	[QUOTA] [float] NULL,
	[ACTUAL_QUOTA] [float] NULL,
	[X1] [float] NULL,
	[Y] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_SysAccessLevel]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_SysAccessLevel](
	[SysAccessLevel] [varchar](50) NOT NULL,
	[SysAccessDescription] [varchar](500) NULL,
 CONSTRAINT [PK_tbl_SysAccessLevel] PRIMARY KEY CLUSTERED 
(
	[SysAccessLevel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_TaskDetail]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TaskDetail](
	[TR_Index] [bigint] IDENTITY(1,1) NOT NULL,
	[Task_ID] [varchar](50) NOT NULL,
	[Task_Description] [varchar](500) NULL,
	[Task_UOM] [varchar](100) NULL,
	[Task_Quota] [bigint] NOT NULL,
	[PC_ProcessCode] [varchar](100) NOT NULL,
	[PIC_Project] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_TaskHeader]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TaskHeader](
	[TR_Index] [bigint] IDENTITY(1,1) NOT NULL,
	[Task_ID] [varchar](50) NOT NULL,
	[PC_ProcessCode] [varchar](100) NOT NULL,
	[PIC_Project] [varchar](50) NOT NULL,
	[SkipOutputValidation] [int] NULL,
 CONSTRAINT [PK_tbl_TaskHeader_1] PRIMARY KEY CLUSTERED 
(
	[Task_ID] ASC,
	[PC_ProcessCode] ASC,
	[PIC_Project] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_TaskRecordDetail]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TaskRecordDetail](
	[TR_Index] [bigint] IDENTITY(1,1) NOT NULL,
	[TR_ID] [varchar](50) NOT NULL,
	[PCP_ID] [varchar](50) NOT NULL,
	[TR_Status] [int] NULL,
	[TR_InDate] [datetime] NOT NULL,
	[TR_OutDate] [datetime] NULL,
	[TR_TaskStatus] [int] NOT NULL,
	[TR_Shipment] [varchar](1000) NOT NULL,
	[TR_File] [varchar](500) NOT NULL,
	[TR_FileSize] [bigint] NULL,
	[TR_UOM] [varchar](100) NOT NULL,
	[TR_Quota] [bigint] NOT NULL,
	[TR_UID] [varchar](50) NOT NULL,
	[TR_MID] [varchar](50) NOT NULL,
	[TR_PIC] [varchar](50) NOT NULL,
	[TR_Apporval] [int] NOT NULL,
	[TR_ApprovalTime] [datetime] NULL,
	[TR_Hours] [float] NULL,
	[TR_Productivity] [float] NULL,
	[Task_ID] [varchar](50) NOT NULL,
	[TR_ActualTaskIn] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_TaskRecordDetail_BackUp]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TaskRecordDetail_BackUp](
	[TR_Index] [bigint] NOT NULL,
	[TR_ID] [varchar](50) NOT NULL,
	[PCP_ID] [varchar](50) NOT NULL,
	[TR_Status] [int] NULL,
	[TR_InDate] [datetime] NOT NULL,
	[TR_OutDate] [datetime] NULL,
	[TR_TaskStatus] [int] NOT NULL,
	[TR_Shipment] [varchar](1000) NOT NULL,
	[TR_File] [varchar](500) NOT NULL,
	[TR_FileSize] [bigint] NULL,
	[TR_UOM] [varchar](100) NOT NULL,
	[TR_Quota] [bigint] NOT NULL,
	[TR_UID] [varchar](50) NOT NULL,
	[TR_MID] [varchar](50) NOT NULL,
	[TR_PIC] [varchar](50) NOT NULL,
	[TR_Apporval] [int] NOT NULL,
	[TR_ApprovalTime] [datetime] NULL,
	[TR_Hours] [float] NULL,
	[TR_Productivity] [float] NULL,
	[Task_ID] [varchar](50) NOT NULL,
	[TR_ActualTaskIn] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_TaskRecordDetailModify]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TaskRecordDetailModify](
	[TRM_Index] [bigint] IDENTITY(1,1) NOT NULL,
	[TRM_ID] [varchar](50) NOT NULL,
	[TR_FileSize] [bigint] NULL,
	[TR_File] [varchar](500) NOT NULL,
	[TRM_ModifiedlTime] [datetime] NOT NULL,
	[TRM_ApprovalTime] [datetime] NULL,
	[TRM_Apporval] [int] NOT NULL,
	[TR_UID] [varchar](50) NOT NULL,
	[TRM_PIC] [varchar](50) NOT NULL,
	[TRM_MID] [varchar](50) NOT NULL,
	[TRM_Hours] [float] NULL,
	[TRM_Productivity] [float] NULL,
	[TRM_OutDate] [datetime] NULL,
	[TRM_InDate] [datetime] NOT NULL,
	[TR_Status] [int] NULL,
	[TR_UOM] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_TaskRecordHeader]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TaskRecordHeader](
	[TR_Index] [bigint] IDENTITY(1,1) NOT NULL,
	[TR_ID] [varchar](50) NOT NULL,
	[PCP_ID] [varchar](50) NOT NULL,
	[TR_UID] [varchar](50) NOT NULL,
	[TR_MID] [varchar](50) NOT NULL,
	[TR_PIC] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_TaskRecordHeader] PRIMARY KEY CLUSTERED 
(
	[TR_ID] ASC,
	[PCP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_TaskRecordHeaderModify]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TaskRecordHeaderModify](
	[TRMH_Index] [bigint] IDENTITY(1,1) NOT NULL,
	[TR_ID] [varchar](50) NOT NULL,
	[PCP_ID] [varchar](50) NOT NULL,
	[TRM_ID] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_TaskRecordHeaderModify] PRIMARY KEY CLUSTERED 
(
	[TRM_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_UOMList]    Script Date: 6/11/2018 3:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_UOMList](
	[UOM_Index] [int] IDENTITY(1,1) NOT NULL,
	[UOM_Unit] [varchar](100) NOT NULL,
 CONSTRAINT [PK_tbl_UOMList] PRIMARY KEY CLUSTERED 
(
	[UOM_Unit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_UserLILO]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_UserLILO](
	[ID] [decimal](18, 0) NOT NULL,
	[UID] [varchar](10) NOT NULL,
	[DATE] [smalldatetime] NOT NULL,
	[FIRSTLOGIN] [datetime] NOT NULL,
	[LASTLOGOUT] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_UserManagementDetail]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_UserManagementDetail](
	[P_Index] [bigint] IDENTITY(1,1) NOT NULL,
	[P_UID] [varchar](50) NOT NULL,
	[P_Project] [varchar](50) NOT NULL,
	[P_Project_Availability] [varchar](50) NOT NULL,
	[P_Activate_Date] [datetime] NOT NULL,
	[P_Inactivate_Date] [datetime] NULL,
	[M_UID] [varchar](50) NOT NULL,
	[PIC_UID] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_UserManagementDetail] PRIMARY KEY CLUSTERED 
(
	[P_UID] ASC,
	[P_Project] ASC,
	[P_Project_Availability] ASC,
	[P_Activate_Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_UserManagementHeader]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_UserManagementHeader](
	[P_Index] [bigint] IDENTITY(1,1) NOT NULL,
	[P_UID] [varchar](50) NOT NULL,
	[P_Name] [varchar](200) NOT NULL,
	[P_Password] [varchar](1000) NOT NULL,
	[P_AccessLevel] [varchar](50) NOT NULL,
	[P_Availability] [int] NOT NULL,
	[P_Activate_Date] [datetime] NOT NULL,
	[P_Inactivate_Date] [datetime] NULL,
	[P_Shift] [varchar](100) NULL,
	[PTR_Resources] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_UserManagementHeader] PRIMARY KEY CLUSTERED 
(
	[P_UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_UserManagementHeader_Copy]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_UserManagementHeader_Copy](
	[P_Index] [bigint] NOT NULL,
	[P_UID] [varchar](50) NOT NULL,
	[P_Name] [varchar](200) NOT NULL,
	[P_Password] [varchar](1000) NOT NULL,
	[P_AccessLevel] [varchar](50) NOT NULL,
	[P_Availability] [int] NOT NULL,
	[P_Activate_Date] [datetime] NOT NULL,
	[P_Inactivate_Date] [datetime] NULL,
	[P_Shift] [varchar](100) NULL,
	[PTR_Resources] [varchar](50) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_ProjectDetail] ADD  CONSTRAINT [DF_tbl_ProjectDetail_SkipOutputValidation]  DEFAULT ((0)) FOR [SkipOutputValidation]
GO
ALTER TABLE [dbo].[tbl_IDLEDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_IDLEDetail_tbl_IDLEHeader] FOREIGN KEY([IDLE_ID])
REFERENCES [dbo].[tbl_IDLEHeader] ([IDLE_ID])
GO
ALTER TABLE [dbo].[tbl_IDLEDetail] CHECK CONSTRAINT [FK_tbl_IDLEDetail_tbl_IDLEHeader]
GO
ALTER TABLE [dbo].[tbl_IDLEDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_IDLEDetail_tbl_IDLEReason] FOREIGN KEY([IDLE_Reason])
REFERENCES [dbo].[tbl_IDLEReason] ([IDLE_Reason])
GO
ALTER TABLE [dbo].[tbl_IDLEDetail] CHECK CONSTRAINT [FK_tbl_IDLEDetail_tbl_IDLEReason]
GO
ALTER TABLE [dbo].[tbl_IDLEHeader]  WITH CHECK ADD  CONSTRAINT [FK_tbl_IDLEHeader_tbl_ProjectDetail] FOREIGN KEY([IDLE_Project], [IDLE_PIC])
REFERENCES [dbo].[tbl_ProjectDetail] ([ProjectName], [PIC_UID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_IDLEHeader] CHECK CONSTRAINT [FK_tbl_IDLEHeader_tbl_ProjectDetail]
GO
ALTER TABLE [dbo].[tbl_ManagerDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ManagerDetail_tbl_ManagerHeader1] FOREIGN KEY([M_UID])
REFERENCES [dbo].[tbl_ManagerHeader] ([M_UID])
GO
ALTER TABLE [dbo].[tbl_ManagerDetail] CHECK CONSTRAINT [FK_tbl_ManagerDetail_tbl_ManagerHeader1]
GO
ALTER TABLE [dbo].[tbl_ManagerDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ManagerDetail_tbl_ProjectDetail] FOREIGN KEY([M_Project], [PIC_UID])
REFERENCES [dbo].[tbl_ProjectDetail] ([ProjectName], [PIC_UID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_ManagerDetail] CHECK CONSTRAINT [FK_tbl_ManagerDetail_tbl_ProjectDetail]
GO
ALTER TABLE [dbo].[tbl_ManagerHeader]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ManagerHeader_tbl_SysAccessLevel] FOREIGN KEY([M_AccessLevel])
REFERENCES [dbo].[tbl_SysAccessLevel] ([SysAccessLevel])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_ManagerHeader] CHECK CONSTRAINT [FK_tbl_ManagerHeader_tbl_SysAccessLevel]
GO
ALTER TABLE [dbo].[tbl_PCPDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_PCPDetail_tbl_PCPHeader] FOREIGN KEY([PCP_ID])
REFERENCES [dbo].[tbl_PCPHeader] ([PCP_ID])
GO
ALTER TABLE [dbo].[tbl_PCPDetail] CHECK CONSTRAINT [FK_tbl_PCPDetail_tbl_PCPHeader]
GO
ALTER TABLE [dbo].[tbl_PCPHeader]  WITH CHECK ADD  CONSTRAINT [FK_tbl_PCPHeader_tbl_ProcessCodeHeader1] FOREIGN KEY([PC_ProcessCode])
REFERENCES [dbo].[tbl_ProcessCodeHeader] ([PC_ProcessCode])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_PCPHeader] CHECK CONSTRAINT [FK_tbl_PCPHeader_tbl_ProcessCodeHeader1]
GO
ALTER TABLE [dbo].[tbl_PICDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_PICDetail_tbl_PICHeader] FOREIGN KEY([PIC_UID])
REFERENCES [dbo].[tbl_PICHeader] ([PIC_UID])
GO
ALTER TABLE [dbo].[tbl_PICDetail] CHECK CONSTRAINT [FK_tbl_PICDetail_tbl_PICHeader]
GO
ALTER TABLE [dbo].[tbl_PICHeader]  WITH CHECK ADD  CONSTRAINT [FK_tbl_PICHeader_tbl_SysAccessLevel] FOREIGN KEY([PIC_AccessLevel])
REFERENCES [dbo].[tbl_SysAccessLevel] ([SysAccessLevel])
GO
ALTER TABLE [dbo].[tbl_PICHeader] CHECK CONSTRAINT [FK_tbl_PICHeader_tbl_SysAccessLevel]
GO
ALTER TABLE [dbo].[tbl_ProcessCodeHeader]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ProcessCodeHeader_tbl_ProjectDetail] FOREIGN KEY([PIC_Project], [PIC_UID])
REFERENCES [dbo].[tbl_ProjectDetail] ([ProjectName], [PIC_UID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_ProcessCodeHeader] CHECK CONSTRAINT [FK_tbl_ProcessCodeHeader_tbl_ProjectDetail]
GO
ALTER TABLE [dbo].[tbl_ProjectDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ProjectDetail_tbl_PICHeader] FOREIGN KEY([PIC_UID])
REFERENCES [dbo].[tbl_PICHeader] ([PIC_UID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_ProjectDetail] CHECK CONSTRAINT [FK_tbl_ProjectDetail_tbl_PICHeader]
GO
ALTER TABLE [dbo].[tbl_TaskDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TaskDetail_tbl_TaskHeader] FOREIGN KEY([Task_ID], [PC_ProcessCode], [PIC_Project])
REFERENCES [dbo].[tbl_TaskHeader] ([Task_ID], [PC_ProcessCode], [PIC_Project])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_TaskDetail] CHECK CONSTRAINT [FK_tbl_TaskDetail_tbl_TaskHeader]
GO
ALTER TABLE [dbo].[tbl_TaskHeader]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TaskHeader_tbl_ProcessCodeHeader] FOREIGN KEY([PC_ProcessCode])
REFERENCES [dbo].[tbl_ProcessCodeHeader] ([PC_ProcessCode])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_TaskHeader] CHECK CONSTRAINT [FK_tbl_TaskHeader_tbl_ProcessCodeHeader]
GO
ALTER TABLE [dbo].[tbl_TaskRecordDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TaskRecordDetail_tbl_TaskRecordHeader] FOREIGN KEY([TR_ID], [PCP_ID])
REFERENCES [dbo].[tbl_TaskRecordHeader] ([TR_ID], [PCP_ID])
GO
ALTER TABLE [dbo].[tbl_TaskRecordDetail] CHECK CONSTRAINT [FK_tbl_TaskRecordDetail_tbl_TaskRecordHeader]
GO
ALTER TABLE [dbo].[tbl_TaskRecordDetailModify]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TaskRecordDetailModify_tbl_TaskRecordHeaderModify] FOREIGN KEY([TRM_ID])
REFERENCES [dbo].[tbl_TaskRecordHeaderModify] ([TRM_ID])
GO
ALTER TABLE [dbo].[tbl_TaskRecordDetailModify] CHECK CONSTRAINT [FK_tbl_TaskRecordDetailModify_tbl_TaskRecordHeaderModify]
GO
ALTER TABLE [dbo].[tbl_TaskRecordHeader]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TaskRecordHeader_tbl_PCPHeader] FOREIGN KEY([PCP_ID])
REFERENCES [dbo].[tbl_PCPHeader] ([PCP_ID])
GO
ALTER TABLE [dbo].[tbl_TaskRecordHeader] CHECK CONSTRAINT [FK_tbl_TaskRecordHeader_tbl_PCPHeader]
GO
ALTER TABLE [dbo].[tbl_TaskRecordHeaderModify]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TaskRecordHeaderModify_tbl_TaskRecordHeader] FOREIGN KEY([TR_ID], [PCP_ID])
REFERENCES [dbo].[tbl_TaskRecordHeader] ([TR_ID], [PCP_ID])
GO
ALTER TABLE [dbo].[tbl_TaskRecordHeaderModify] CHECK CONSTRAINT [FK_tbl_TaskRecordHeaderModify_tbl_TaskRecordHeader]
GO
ALTER TABLE [dbo].[tbl_UserManagementDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_UserManagementDetail_tbl_ManagerHeader] FOREIGN KEY([M_UID])
REFERENCES [dbo].[tbl_ManagerHeader] ([M_UID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_UserManagementDetail] CHECK CONSTRAINT [FK_tbl_UserManagementDetail_tbl_ManagerHeader]
GO
ALTER TABLE [dbo].[tbl_UserManagementDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_UserManagementDetail_tbl_ProjectDetail] FOREIGN KEY([P_Project], [PIC_UID])
REFERENCES [dbo].[tbl_ProjectDetail] ([ProjectName], [PIC_UID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_UserManagementDetail] CHECK CONSTRAINT [FK_tbl_UserManagementDetail_tbl_ProjectDetail]
GO
ALTER TABLE [dbo].[tbl_UserManagementDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_UserManagementDetail_tbl_UserManagementHeader] FOREIGN KEY([P_UID])
REFERENCES [dbo].[tbl_UserManagementHeader] ([P_UID])
GO
ALTER TABLE [dbo].[tbl_UserManagementDetail] CHECK CONSTRAINT [FK_tbl_UserManagementDetail_tbl_UserManagementHeader]
GO
ALTER TABLE [dbo].[tbl_UserManagementHeader]  WITH CHECK ADD  CONSTRAINT [FK_tbl_UserManagementHeader_tbl_PTR_QA_StdRates] FOREIGN KEY([PTR_Resources])
REFERENCES [dbo].[tbl_PTR_QA_StdRates] ([PTR_Resources])
GO
ALTER TABLE [dbo].[tbl_UserManagementHeader] CHECK CONSTRAINT [FK_tbl_UserManagementHeader_tbl_PTR_QA_StdRates]
GO
ALTER TABLE [dbo].[tbl_UserManagementHeader]  WITH CHECK ADD  CONSTRAINT [FK_tbl_UserManagementHeader_tbl_SysAccessLevel] FOREIGN KEY([P_AccessLevel])
REFERENCES [dbo].[tbl_SysAccessLevel] ([SysAccessLevel])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_UserManagementHeader] CHECK CONSTRAINT [FK_tbl_UserManagementHeader_tbl_SysAccessLevel]
GO
/****** Object:  StoredProcedure [dbo].[DBoard_ActiveTeamDetailByPIC]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_ActiveTeamDetailByPIC] @mPIC nvarchar(20)

AS

SELECT s.M_UID AS [UID],f.M_Name AS [NAME], s.M_Project AS [PROJECT]/*, s.M_Project_Availability AS [PROJECT AVALIABILITY] */
FROM tbl_ManagerHeader f INNER JOIN tbl_ManagerDetail s ON f.M_UID = s.M_UID 
WHERE s.PIC_UID = @mPIC AND f.M_Availability=1 AND f.M_AccessLevel='Immediate Manager' AND s.[M_Project_Availability]='Active'
ORDER BY s.M_UID

GO
/****** Object:  StoredProcedure [dbo].[DBoard_ActiveTeamDetailByPIC_FilterByManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_ActiveTeamDetailByPIC_FilterByManager] @mPIC nvarchar(20), @mMUID nvarchar(50)

AS

SELECT s.M_UID AS [UID],f.M_Name AS [NAME], s.M_Project AS [PROJECT]/*, s.M_Project_Availability AS [PROJECT AVALIABILITY] */
FROM tbl_ManagerHeader f INNER JOIN tbl_ManagerDetail s ON f.M_UID = s.M_UID 
WHERE s.PIC_UID = @mPIC AND f.M_Availability=1 AND f.M_AccessLevel='Immediate Manager' AND s.[M_Project_Availability]='Active' AND s.M_UID=@mMUID
ORDER BY s.M_UID

GO
/****** Object:  StoredProcedure [dbo].[DBoard_ActiveTeamDetailByPIC_FilterByProject]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_ActiveTeamDetailByPIC_FilterByProject] @mPIC nvarchar(20), @mProject nvarchar(50)

AS

SELECT s.M_UID AS [UID],f.M_Name AS [NAME], s.M_Project AS [PROJECT]/*, s.M_Project_Availability AS [PROJECT AVALIABILITY] */
FROM tbl_ManagerHeader f INNER JOIN tbl_ManagerDetail s ON f.M_UID = s.M_UID 
WHERE s.PIC_UID = @mPIC AND f.M_Availability=1 AND f.M_AccessLevel='Immediate Manager' AND s.[M_Project_Availability]='Active' AND s.M_Project=@mProject
ORDER BY s.M_UID

GO
/****** Object:  StoredProcedure [dbo].[DBoard_ActiveTeamDetailByPIC_FilterByProjectAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_ActiveTeamDetailByPIC_FilterByProjectAndManager] @mPIC nvarchar(20), @mProject nvarchar(50), @mMUID nvarchar(20)

AS

SELECT s.M_UID AS [UID],f.M_Name AS [NAME], s.M_Project AS [PROJECT]/*, s.M_Project_Availability AS [PROJECT AVALIABILITY] */
FROM tbl_ManagerHeader f INNER JOIN tbl_ManagerDetail s ON f.M_UID = s.M_UID 
WHERE s.PIC_UID = @mPIC AND f.M_Availability=1 AND f.M_AccessLevel='Immediate Manager' AND s.[M_Project_Availability]='Active' AND s.M_Project=@mProject AND s.M_UID=@mMUID
ORDER BY s.M_UID

GO
/****** Object:  StoredProcedure [dbo].[Dboard_AllProjectsByPIC]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_AllProjectsByPIC] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime

AS
/* 0-Fresh, 1-Hold, 2-Pending, 3-Done */
SELECT [PROJECT], ISNULL(SUM([REGISTERED VOLUME]),0) AS [REGISTERED VOLUME], ISNULL(MAX(DONE),0) AS [COMPLETED], ISNULL(MAX(PENDING),0) AS [IN-PROCESS], ISNULL(MAX(FRESH),0) AS [FRESH], ISNULL(MAX(HOLD),0) AS [HOLD],  ISNULL(SUM([ACTIVE STATUS]),0) AS  [ACTIVE STATUS]
FROM(
  SELECT TOP 999999999999999 PD.[PCP_Project] AS [PROJECT], COUNT(PD.[PCP_Status]) AS [REGISTERED VOLUME],
  case PD.[PCP_Status] when 2  then SUM(CASE PD.[PCP_Status] when 2 Then 1 END) end AS [PENDING],
  case PD.[PCP_Status] when 3  then SUM(CASE PD.[PCP_Status] when 3 Then 1 END) end AS [DONE],
  case PD.[PCP_Status] when 0  then SUM(CASE PD.[PCP_Status] when 0 Then 1 END) end AS [FRESH],
  case PD.[PCP_Status] when 1  then SUM(CASE PD.[PCP_Status] when 1 Then 1 END) end AS [HOLD],
  case TD.TR_TaskStatus when 1  then SUM(CASE TD.TR_TaskStatus when 1 Then 1 END) end AS [ACTIVE STATUS]
  FROM [CITITO].[dbo].[tbl_PCPDetail] PD
  --INNER JOIN [tbl_PCPHeader] PH ON PH.PCP_ID=PD.PCP_ID
	INNER JOIN [tbl_TaskRecordDetail] TD ON TD.PCP_ID=PD.PCP_ID AND TD.Task_ID=PD.Task_ID
  --WHERE TD.TR_ActualTaskIn BETWEEN @mFrom AND @mTo
GROUP BY PD.[PCP_Project], [PCP_Status],TD.TR_TaskStatus
ORDER BY PD.[PCP_Project]
) A
LEFT OUTER JOIN tbl_ProjectDetail PrD ON PrD.ProjectName=A.[PROJECT]
WHERE PrD.PIC_UID=@mPIC
GROUP BY [PROJECT]
ORDER BY [PROJECT]

GO
/****** Object:  StoredProcedure [dbo].[DBoard_AllTasksAndQuota]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_AllTasksAndQuota] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime

AS

SELECT CONVERT(date,TD.TR_ActualTaskIn) AS [WORKDATE],TD.TR_UID AS [UID], TD.PC_ProcessCode AS [PROCESS CODE], TD.PCP_Project [PROJECT], TD.Task_ID AS [TASK], TDES.Task_Description AS [DESCRIPTION], TD.TR_UOM AS [UOM], TD.QUOTA AS [QUOTA], ROUND(TD.X3,2) AS [PRODUCTIVITY]
	FROM [tbl_Report_TemptaskDetailsQUOTA_Updated] TD
	INNER JOIN [tbl_TaskDetail] TDES ON TDES.PIC_Project=TD.PCP_Project AND TDES.PC_ProcessCode=TD.PC_ProcessCode AND TDES.Task_ID=TD.Task_ID
	WHERE TD.TR_PIC=@mPIC AND TD.TR_ActualTaskIn BETWEEN @mFrom AND @mTo
	ORDER BY TDES.Task_Description

--SELECT CONVERT(date,tsrd.TR_ActualTaskIn) AS [WORKDATE],tsrd.TR_UID AS [UID], tskd.PC_ProcessCode AS [PROCESS CODE], prjd.ProjectName [PROJECT], tskd.Task_ID AS [TASK], tskd.Task_Description AS [DESCRIPTION], tskd.Task_UOM AS [UOM], tskd.Task_Quota AS [QUOTA], ROUND(tsrd.TR_Productivity,2) AS [PRODUCTIVITY]
--	FROM tbl_TaskDetail tskd
--	INNER JOIN tbl_ProjectDetail prjd ON tskd.PIC_Project=prjd.ProjectName
--	INNER JOIN tbl_PCPDetail pcpd ON pcpd.PC_ProcessCode=tskd.PC_ProcessCode AND tskd.Task_ID=pcpd.Task_ID
--	INNER JOIN tbl_TaskRecordDetail tsrd ON pcpd.Task_ID=tsrd.Task_ID AND pcpd.PCP_ID=tsrd.PCP_ID
--WHERE prjd.PIC_UID=@mPIC AND tsrd.TR_InDate BETWEEN @mFrom AND @mTo AND tsrd.TR_Apporval=2
--ORDER BY tskd.Task_Description
GO
/****** Object:  StoredProcedure [dbo].[DBoard_AllTasksAndQuota_FilterByItemCode]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_AllTasksAndQuota_FilterByItemCode] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime, @mItemCode nvarchar(50)

AS

SELECT CONVERT(date,TD.TR_ActualTaskIn) AS [WORKDATE],TD.TR_UID AS [UID], TD.PC_ProcessCode AS [PROCESS CODE], TD.PCP_Project [PROJECT], TD.Task_ID AS [TASK], TDES.Task_Description AS [DESCRIPTION], TD.TR_UOM AS [UOM], TD.QUOTA AS [QUOTA], ROUND(TD.X3,2) AS [PRODUCTIVITY]
	FROM [tbl_Report_TemptaskDetailsQUOTA_Updated] TD
	INNER JOIN [tbl_TaskDetail] TDES ON TDES.PIC_Project=TD.PCP_Project AND TDES.PC_ProcessCode=TD.PC_ProcessCode AND TDES.Task_ID=TD.Task_ID
	WHERE TD.TR_PIC=@mPIC AND TD.TR_ActualTaskIn BETWEEN @mFrom AND @mTo AND TD.PC_ProcessCode=@mItemCode
	ORDER BY TDES.Task_Description

--SELECT CONVERT(date,tsrd.TR_ActualTaskIn) AS [WORKDATE], tsrd.TR_UID AS [UID], tskd.PC_ProcessCode AS [PROCESS CODE], prjd.ProjectName [PROJECT], tskd.Task_ID AS [TASK], tskd.Task_Description AS [DESCRIPTION], tskd.Task_UOM AS [UOM], tskd.Task_Quota AS [QUOTA], ROUND(tsrd.TR_Productivity,2) AS [PRODUCTIVITY]
--	FROM tbl_TaskDetail tskd
--	INNER JOIN tbl_ProjectDetail prjd ON tskd.PIC_Project=prjd.ProjectName
--	INNER JOIN tbl_PCPDetail pcpd ON pcpd.PC_ProcessCode=tskd.PC_ProcessCode AND tskd.Task_ID=pcpd.Task_ID
--	INNER JOIN tbl_TaskRecordDetail tsrd ON pcpd.Task_ID=tsrd.Task_ID AND pcpd.PCP_ID=tsrd.PCP_ID
--WHERE prjd.PIC_UID=@mPIC AND tsrd.TR_InDate BETWEEN @mFrom AND @mTo AND tsrd.TR_Apporval=2 AND tskd.PC_ProcessCode=@mItemCode
--ORDER BY tskd.Task_Description

GO
/****** Object:  StoredProcedure [dbo].[DBoard_AllTasksAndQuota_FilterByProject]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_AllTasksAndQuota_FilterByProject] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime, @mProject nvarchar(30)

AS

SELECT CONVERT(date,TD.TR_ActualTaskIn) AS [WORKDATE],TD.TR_UID AS [UID], TD.PC_ProcessCode AS [PROCESS CODE], TD.PCP_Project [PROJECT], TD.Task_ID AS [TASK], TDES.Task_Description AS [DESCRIPTION], TD.TR_UOM AS [UOM], TD.QUOTA AS [QUOTA], ROUND(TD.X3,2) AS [PRODUCTIVITY]
	FROM [tbl_Report_TemptaskDetailsQUOTA_Updated] TD
	INNER JOIN [tbl_TaskDetail] TDES ON TDES.PIC_Project=TD.PCP_Project AND TDES.PC_ProcessCode=TD.PC_ProcessCode AND TDES.Task_ID=TD.Task_ID
	WHERE TD.TR_PIC=@mPIC AND TD.TR_ActualTaskIn BETWEEN @mFrom AND @mTo AND TD.PCP_Project=@mProject
	ORDER BY TDES.Task_Description

--SELECT CONVERT(date,tsrd.TR_ActualTaskIn) AS [WORKDATE], tsrd.TR_UID AS [UID], tskd.PC_ProcessCode AS [PROCESS CODE], prjd.ProjectName [PROJECT], tskd.Task_ID AS [TASK], tskd.Task_Description AS [DESCRIPTION], tskd.Task_UOM AS [UOM], tskd.Task_Quota AS [QUOTA], ROUND(tsrd.TR_Productivity,2) AS [PRODUCTIVITY]
--	FROM tbl_TaskDetail tskd
--	INNER JOIN tbl_ProjectDetail prjd ON tskd.PIC_Project=prjd.ProjectName
--	INNER JOIN tbl_PCPDetail pcpd ON pcpd.PC_ProcessCode=tskd.PC_ProcessCode AND tskd.Task_ID=pcpd.Task_ID
--	INNER JOIN tbl_TaskRecordDetail tsrd ON pcpd.Task_ID=tsrd.Task_ID AND pcpd.PCP_ID=tsrd.PCP_ID
--WHERE prjd.PIC_UID=@mPIC AND tsrd.TR_InDate BETWEEN @mFrom AND @mTo AND tsrd.TR_Apporval=2 AND tskd.PIC_Project=@mProject
--ORDER BY tskd.Task_Description

GO
/****** Object:  StoredProcedure [dbo].[DBoard_AllTasksAndQuota_FilterByTaskCode]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_AllTasksAndQuota_FilterByTaskCode] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime, @mTaskCode nvarchar(50)

AS

SELECT CONVERT(date,TD.TR_ActualTaskIn) AS [WORKDATE],TD.TR_UID AS [UID], TD.PC_ProcessCode AS [PROCESS CODE], TD.PCP_Project [PROJECT], TD.Task_ID AS [TASK], TDES.Task_Description AS [DESCRIPTION], TD.TR_UOM AS [UOM], TD.QUOTA AS [QUOTA], ROUND(TD.X3,2) AS [PRODUCTIVITY]
	FROM [tbl_Report_TemptaskDetailsQUOTA_Updated] TD
	INNER JOIN [tbl_TaskDetail] TDES ON TDES.PIC_Project=TD.PCP_Project AND TDES.PC_ProcessCode=TD.PC_ProcessCode AND TDES.Task_ID=TD.Task_ID
	WHERE TD.TR_PIC=@mPIC AND TD.TR_ActualTaskIn BETWEEN @mFrom AND @mTo AND TD.Task_ID=@mTaskCode
	ORDER BY TDES.Task_Description


--SELECT CONVERT(date,tsrd.TR_ActualTaskIn) AS [WORKDATE], tsrd.TR_UID AS [UID], tskd.PC_ProcessCode AS [PROCESS CODE], prjd.ProjectName [PROJECT], tskd.Task_ID AS [TASK], tskd.Task_Description AS [DESCRIPTION], tskd.Task_UOM AS [UOM], tskd.Task_Quota AS [QUOTA], ROUND(tsrd.TR_Productivity,2) AS [PRODUCTIVITY]
--	FROM tbl_TaskDetail tskd
--	INNER JOIN tbl_ProjectDetail prjd ON tskd.PIC_Project=prjd.ProjectName
--	INNER JOIN tbl_PCPDetail pcpd ON pcpd.PC_ProcessCode=tskd.PC_ProcessCode AND tskd.Task_ID=pcpd.Task_ID
--	INNER JOIN tbl_TaskRecordDetail tsrd ON pcpd.Task_ID=tsrd.Task_ID AND pcpd.PCP_ID=tsrd.PCP_ID
--WHERE prjd.PIC_UID=@mPIC AND tsrd.TR_InDate BETWEEN @mFrom AND @mTo AND tsrd.TR_Apporval=2 AND tskd.Task_ID=@mTaskCode
--ORDER BY tskd.Task_Description

GO
/****** Object:  StoredProcedure [dbo].[Dboard_AllUserWastage_ByPIC]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_AllUserWastage_ByPIC] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime

AS

SELECT [WORKDATE]
      ,[UID]
      ,[MID] AS [TEAM]
      ,[FIRST_LOGIN] AS [LOGIN]
      ,[LAST_LOGOUT] AS [LOGOUT]
      ,[AMSDIFF] AS [AMS LOG-IN TIME]
      ,[FIRST_TASKED-IN] AS [FIRST TASKED-IN]
      ,[LAST_TASKED-OUT] AS [LAST TASKED-OUT]
      ,[TASKDIFF] AS [TASKED-IN TIME]
      ,[APPROVED_IDLE] AS [APPROVED IDLE]
      ,ROUND([WASTE],2) AS [WASTE TIME]
  FROM [CITITO].[dbo].[tbl_Report_TempIDLEAndWastage]
  WHERE PIC=@mPIC AND WORKDATE BETWEEN @mFrom AND @mTo

GO
/****** Object:  StoredProcedure [dbo].[Dboard_AllUserWastage_ByPIC_FilterByManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_AllUserWastage_ByPIC_FilterByManager] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mMID nvarchar(20)

AS

SELECT [WORKDATE]
      ,[UID]
      ,[MID] AS [TEAM]
      ,[FIRST_LOGIN] AS [LOGIN]
      ,[LAST_LOGOUT] AS [LOGOUT]
      ,[AMSDIFF] AS [AMS LOG-IN TIME]
      ,[FIRST_TASKED-IN] AS [FIRST TASKED-IN]
      ,[LAST_TASKED-OUT] AS [LAST TASKED-OUT]
      ,[TASKDIFF] AS [TASKED-IN TIME]
      ,[APPROVED_IDLE] AS [APPROVED IDLE]
      ,ROUND([WASTE],2) AS [WASTE TIME]
  FROM [CITITO].[dbo].[tbl_Report_TempIDLEAndWastage]
  WHERE PIC=@mPIC AND WORKDATE BETWEEN @mFrom AND @mTo AND MID=@mMID

GO
/****** Object:  StoredProcedure [dbo].[Dboard_AllUserWastage_ByPIC_FilterByUser]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_AllUserWastage_ByPIC_FilterByUser] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mUID nvarchar(20)

AS

SELECT [WORKDATE]
      ,[UID]
      ,[MID] AS [TEAM]
      ,[FIRST_LOGIN] AS [LOGIN]
      ,[LAST_LOGOUT] AS [LOGOUT]
      ,[AMSDIFF] AS [AMS LOG-IN TIME]
      ,[FIRST_TASKED-IN] AS [FIRST TASKED-IN]
      ,[LAST_TASKED-OUT] AS [LAST TASKED-OUT]
      ,[TASKDIFF] AS [TASKED-IN TIME]
      ,[APPROVED_IDLE] AS [APPROVED IDLE]
      ,ROUND([WASTE],2) AS [WASTE TIME]
  FROM [CITITO].[dbo].[tbl_Report_TempIDLEAndWastage]
  WHERE PIC=@mPIC AND WORKDATE BETWEEN @mFrom AND @mTo AND [UID]=@mUID

GO
/****** Object:  StoredProcedure [dbo].[Dboard_AllUserWastage_ByPIC_FilterByUserAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_AllUserWastage_ByPIC_FilterByUserAndManager] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mUID nvarchar(20), @mMUID nvarchar(20)

AS

SELECT [WORKDATE]
      ,[UID]
      ,[MID] AS [TEAM]
      ,[FIRST_LOGIN] AS [LOGIN]
      ,[LAST_LOGOUT] AS [LOGOUT]
      ,[AMSDIFF] AS [AMS LOG-IN TIME]
      ,[FIRST_TASKED-IN] AS [FIRST TASKED-IN]
      ,[LAST_TASKED-OUT] AS [LAST TASKED-OUT]
      ,[TASKDIFF] AS [TASKED-IN TIME]
      ,[APPROVED_IDLE] AS [APPROVED IDLE]
      ,ROUND([WASTE],2) AS [WASTE TIME]
  FROM [CITITO].[dbo].[tbl_Report_TempIDLEAndWastage]
  WHERE PIC=@mPIC AND WORKDATE BETWEEN @mFrom AND @mTo AND [UID]=@mUID AND MID=@mMUID

GO
/****** Object:  StoredProcedure [dbo].[Dboard_CurrentCapacity]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Dboard_CurrentCapacity] @mPIC nvarchar(30) 

AS

DECLARE @CurrentProductivity TABLE(
    TaskedIn varchar(50),
    IDLE varchar(50),
	[Absent] varchar(50)
);
DECLARE @CurrentProductivityFinal TABLE(
    TDetail varchar(50),
    Tcount varchar(50)
);


/*IDELE*/

INSERT INTO @CurrentProductivity (IDLE)
SELECT [UID] AS [IDLE]
FROM (
SELECT [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.P_Project_Availability='Active'
GROUP BY [UID]
) AMSTodayUID

WHERE [UID] NOT IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME) AND TR_TaskStatus=1
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)

/*Tasked In*/
INSERT INTO @CurrentProductivity (TaskedIn)
SELECT [UID] AS [Tasked-In]
FROM (
SELECT [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.P_Project_Availability='Active'
GROUP BY [UID]
) AMSTodayUID

WHERE [UID] IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME) AND TR_TaskStatus=1
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)


/**Absent*/

INSERT INTO @CurrentProductivity ([Absent])
SELECT P_UID AS [Absent] 
FROM ( SELECT uh.P_UID
	  FROM tbl_UserManagementHeader uh
	  INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=uh.P_UID
	  WHERE ud.PIC_UID=@mPIC AND uh.P_Availability=1 AND P_AccessLevel='Common User' AND ud.P_Project_Availability='Active'
	  GROUP BY uh.P_UID
) OperatorCount

WHERE P_UID NOT IN (
SELECT [UID] AS [IDLE]
FROM (
SELECT [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.P_Project_Availability='Active'
GROUP BY [UID]
) AMSTodayUID
)


INSERT INTO @CurrentProductivityFinal (TDetail, Tcount)
SELECT 'TASKED-IN', COUNT(TaskedIn)
FROM @CurrentProductivity

INSERT INTO @CurrentProductivityFinal (TDetail, Tcount)
SELECT 'IDLE', COUNT(IDLE)
FROM @CurrentProductivity


INSERT INTO @CurrentProductivityFinal (TDetail, Tcount)
SELECT 'ABSENT', COUNT([Absent])
FROM @CurrentProductivity


SELECT *
FROM @CurrentProductivityFinal

GO
/****** Object:  StoredProcedure [dbo].[Dboard_CurrentCapacity_MID]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Dboard_CurrentCapacity_MID] @mPIC nvarchar(30),  @mMUID nvarchar(30)

AS

DECLARE @CurrentProductivity TABLE(
    TaskedIn varchar(50),
    IDLE varchar(50),
	[Absent] varchar(50)
);
DECLARE @CurrentProductivityFinal TABLE(
    TDetail varchar(50),
    Tcount varchar(50)
);


/*IDELE*/

INSERT INTO @CurrentProductivity (IDLE)
SELECT [UID] AS [IDLE]
FROM (
SELECT [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND ud.M_UID=@mMUID AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.P_Project_Availability='Active'
GROUP BY [UID]
) AMSTodayUID

WHERE [UID] NOT IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_MID=@mMUID AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME) AND TR_TaskStatus=1
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND TR_MID=@mMUID AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)

/*Tasked In*/
INSERT INTO @CurrentProductivity (TaskedIn)
SELECT [UID] AS [Tasked-In]
FROM (
SELECT [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND ud.M_UID=@mMUID AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.P_Project_Availability='Active'
GROUP BY [UID]
) AMSTodayUID

WHERE [UID] IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_MID=@mMUID AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME) AND TR_TaskStatus=1
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND TR_MID=@mMUID AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)


/**Absent*/

INSERT INTO @CurrentProductivity ([Absent])
SELECT P_UID AS [Absent] 
FROM ( SELECT uh.P_UID
	  FROM tbl_UserManagementHeader uh
	  INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=uh.P_UID
	  WHERE ud.PIC_UID=@mPIC AND ud.M_UID=@mMUID AND uh.P_Availability=1 AND P_AccessLevel='Common User' AND ud.P_Project_Availability='Active'
	  GROUP BY uh.P_UID
) OperatorCount

WHERE P_UID NOT IN (
SELECT [UID] AS [IDLE]
FROM (
SELECT [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND ud.M_UID=@mMUID AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.P_Project_Availability='Active'
GROUP BY [UID]
) AMSTodayUID
)


INSERT INTO @CurrentProductivityFinal (TDetail, Tcount)
SELECT 'TASKED-IN', COUNT(TaskedIn)
FROM @CurrentProductivity

INSERT INTO @CurrentProductivityFinal (TDetail, Tcount)
SELECT 'IDLE', COUNT(IDLE)
FROM @CurrentProductivity


INSERT INTO @CurrentProductivityFinal (TDetail, Tcount)
SELECT 'ABSENT', COUNT([Absent])
FROM @CurrentProductivity


SELECT *
FROM @CurrentProductivityFinal

GO
/****** Object:  StoredProcedure [dbo].[Dboard_CurrentTeamCapacity_DetailedByPIC]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_CurrentTeamCapacity_DetailedByPIC] @mPIC nvarchar(30) 

AS

DECLARE @CurrentProductivity TABLE(
	Team varchar(50),
    TaskedIn varchar(50),
    IDLE varchar(50),
	[Absent] varchar(50)
);
DECLARE @CurrentProductivityFinal TABLE(
	TTeam varchar(50),
    TTaskedIn varchar(50),
    TIDLE varchar(50),
	TAbsent varchar(50)
);
DECLARE @CurrentProductivityFinal1 TABLE(
    ATaskedIn varchar(50),
    AIDLE varchar(50),
	AAbsent varchar(50)
);


/*IDELE*/

INSERT INTO @CurrentProductivity (Team, IDLE)
SELECT [MUID] AS [Team],[UID] AS [IDLE]
FROM (
SELECT ud.M_UID AS [MUID], [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME())  AND ud.P_Project_Availability='Active'
GROUP BY ud.M_UID, [UID]
) AMSTodayUID

WHERE [UID] NOT IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME) AND TR_TaskStatus=1
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)

/*Tasked In*/
INSERT INTO @CurrentProductivity (Team, TaskedIn)
SELECT [MUID] AS [Team], [UID] AS [Tasked-In]
FROM (
SELECT ud.M_UID AS [MUID], [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME())  AND ud.P_Project_Availability='Active'
GROUP BY ud.M_UID, [UID]
) AMSTodayUID

WHERE [UID] IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME) AND TR_TaskStatus=1
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)


/**Absent*/

INSERT INTO @CurrentProductivity (Team, [Absent])
SELECT M_UID AS [Team], P_UID AS [Absent] 
FROM ( SELECT ud.M_UID, uh.P_UID
	  FROM tbl_UserManagementHeader uh
	  INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=uh.P_UID
	  WHERE ud.PIC_UID=@mPIC AND uh.P_Availability=1 AND P_AccessLevel='Common User' AND ud.P_Project_Availability='Active'
	  GROUP BY ud.M_UID, uh.P_UID
) OperatorCount

WHERE P_UID NOT IN (
SELECT [UID] AS [IDLE]
FROM (
SELECT [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME())  AND ud.P_Project_Availability='Active'
GROUP BY [UID]
) AMSTodayUID
)


INSERT INTO @CurrentProductivityFinal (TTeam, TTaskedIn)
SELECT Team, TaskedIn
FROM @CurrentProductivity
GROUP BY Team, TaskedIn

INSERT INTO @CurrentProductivityFinal (TTeam, TIDLE)
SELECT Team, IDLE
FROM @CurrentProductivity
GROUP BY Team, IDLE


INSERT INTO @CurrentProductivityFinal (TTeam, TAbsent)
SELECT Team, [Absent]
FROM @CurrentProductivity
GROUP BY Team, [Absent];


WITH CTE AS (

SELECT
        TTeam,
        MAX(TTaskedIn) AS [TASKED-IN],
        MAX(TIDLE) AS [DILE],
        MAX(TAbsent) AS [ABSENT]
    FROM @CurrentProductivityFinal
    GROUP BY TTeam
    HAVING MAX(TTaskedIn) = MIN(TTaskedIn)
        AND MAX(TIDLE) = MIN(TIDLE)
        AND MAX(TAbsent) = MIN(TAbsent)
),
FINAL AS(
    SELECT [TASKED-IN],[DILE],[ABSENT]
    FROM CTE
    UNION ALL
    SELECT TTaskedIn,TIDLE,TAbsent
    FROM @CurrentProductivityFinal
    WHERE TTeam NOT IN (SELECT TTeam FROM CTE) 
	GROUP BY TTaskedIn,TIDLE,TAbsent
	HAVING TTaskedIn!='NULL' OR TIDLE!='NULL' OR TAbsent!='NULL'
	),
TASKEDIN AS(

	SELECT [TASKED-IN]
	FROM FINAL
	WHERE [TASKED-IN] IS NOT NULL),

DILES AS(
	SELECT [DILE]
	FROM FINAL
	WHERE [DILE] IS NOT NULL),

ABSENTS AS(
	SELECT [ABSENT]
	FROM FINAL
	WHERE [ABSENT] IS NOT NULL)

SELECT [TASKED-IN],[DILE] AS [IDLE],[ABSENT] FROM 
    (SELECT [TASKED-IN], row_number() OVER ( ORDER BY [TASKED-IN] ) as num FROM TASKEDIN) AS X
FULL OUTER JOIN 
    (SELECT [DILE], row_number() OVER ( ORDER BY [DILE] )as num FROM DILES) AS Y
		ON x.num = y.num
FULL OUTER JOIN 
    (SELECT [ABSENT], row_number() OVER ( ORDER BY [ABSENT] ) as num FROM ABSENTS) AS Z
		ON z.num=x.num

GO
/****** Object:  StoredProcedure [dbo].[Dboard_CurrentTeamCapacity_DetailedByPIC_FilterByManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_CurrentTeamCapacity_DetailedByPIC_FilterByManager] @mPIC nvarchar(30), @mMUID nvarchar(50) 

AS

DECLARE @CurrentProductivity TABLE(
	Team varchar(50),
    TaskedIn varchar(50),
    IDLE varchar(50),
	[Absent] varchar(50)
);
DECLARE @CurrentProductivityFinal TABLE(
	TTeam varchar(50),
    TTaskedIn varchar(50),
    TIDLE varchar(50),
	TAbsent varchar(50)
);
DECLARE @CurrentProductivityFinal1 TABLE(
    ATaskedIn varchar(50),
    AIDLE varchar(50),
	AAbsent varchar(50)
);


/*IDELE*/

INSERT INTO @CurrentProductivity (Team, IDLE)
SELECT [MUID] AS [Team],[UID] AS [IDLE]
FROM (
SELECT ud.M_UID AS [MUID], [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.M_UID=@mMUID AND ud.P_Project_Availability='Active'
GROUP BY ud.M_UID, [UID]
) AMSTodayUID

WHERE [UID] NOT IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME) AND TR_TaskStatus=1
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)

/*Tasked In*/
INSERT INTO @CurrentProductivity (Team, TaskedIn)
SELECT [MUID] AS [Team], [UID] AS [Tasked-In]
FROM (
SELECT ud.M_UID AS [MUID], [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.M_UID=@mMUID AND ud.P_Project_Availability='Active'
GROUP BY ud.M_UID, [UID]
) AMSTodayUID

WHERE [UID] IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME) AND TR_TaskStatus=1
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)


/**Absent*/

INSERT INTO @CurrentProductivity (Team, [Absent])
SELECT M_UID AS [Team], P_UID AS [Absent] 
FROM ( SELECT ud.M_UID, uh.P_UID
	  FROM tbl_UserManagementHeader uh
	  INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=uh.P_UID
	  WHERE ud.PIC_UID=@mPIC AND uh.P_Availability=1 AND P_AccessLevel='Common User' AND ud.M_UID=@mMUID AND ud.P_Project_Availability='Active'
	  GROUP BY ud.M_UID, uh.P_UID
) OperatorCount

WHERE P_UID NOT IN (
SELECT [UID] AS [IDLE]
FROM (
SELECT [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.M_UID=@mMUID AND ud.P_Project_Availability='Active'
GROUP BY [UID]
) AMSTodayUID
)


INSERT INTO @CurrentProductivityFinal (TTeam, TTaskedIn)
SELECT Team, TaskedIn
FROM @CurrentProductivity
GROUP BY Team, TaskedIn

INSERT INTO @CurrentProductivityFinal (TTeam, TIDLE)
SELECT Team, IDLE
FROM @CurrentProductivity
GROUP BY Team, IDLE


INSERT INTO @CurrentProductivityFinal (TTeam, TAbsent)
SELECT Team, [Absent]
FROM @CurrentProductivity
GROUP BY Team, [Absent];


WITH CTE AS (

SELECT
        TTeam,
        MAX(TTaskedIn) AS [TASKED-IN],
        MAX(TIDLE) AS [DILE],
        MAX(TAbsent) AS [ABSENT]
    FROM @CurrentProductivityFinal
    GROUP BY TTeam
    HAVING MAX(TTaskedIn) = MIN(TTaskedIn)
        AND MAX(TIDLE) = MIN(TIDLE)
        AND MAX(TAbsent) = MIN(TAbsent)
),
FINAL AS(
    SELECT [TASKED-IN],[DILE],[ABSENT]
    FROM CTE
    UNION ALL
    SELECT TTaskedIn,TIDLE,TAbsent
    FROM @CurrentProductivityFinal
    WHERE TTeam NOT IN (SELECT TTeam FROM CTE) 
	GROUP BY TTaskedIn,TIDLE,TAbsent
	HAVING TTaskedIn!='NULL' OR TIDLE!='NULL' OR TAbsent!='NULL'
	),
TASKEDIN AS(

	SELECT [TASKED-IN]
	FROM FINAL
	WHERE [TASKED-IN] IS NOT NULL),

DILES AS(
	SELECT [DILE]
	FROM FINAL
	WHERE [DILE] IS NOT NULL),

ABSENTS AS(
	SELECT [ABSENT]
	FROM FINAL
	WHERE [ABSENT] IS NOT NULL)

SELECT [TASKED-IN],[DILE] AS [IDLE],[ABSENT] FROM 
    (SELECT [TASKED-IN], row_number() OVER ( ORDER BY [TASKED-IN] ) as num FROM TASKEDIN) AS X
FULL OUTER JOIN 
    (SELECT [DILE], row_number() OVER ( ORDER BY [DILE] )as num FROM DILES) AS Y
		ON x.num = y.num
FULL OUTER JOIN 
    (SELECT [ABSENT], row_number() OVER ( ORDER BY [ABSENT] ) as num FROM ABSENTS) AS Z
		ON z.num=x.num


GO
/****** Object:  StoredProcedure [dbo].[Dboard_CurrentTeamCapacity_DetailedByPIC_FilterByProjct]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_CurrentTeamCapacity_DetailedByPIC_FilterByProjct] @mPIC nvarchar(30), @mProject nvarchar(50) 

AS

DECLARE @CurrentProductivity TABLE(
	Team varchar(50),
    TaskedIn varchar(50),
    IDLE varchar(50),
	[Absent] varchar(50)
);
DECLARE @CurrentProductivityFinal TABLE(
	TTeam varchar(50),
    TTaskedIn varchar(50),
    TIDLE varchar(50),
	TAbsent varchar(50)
);
DECLARE @CurrentProductivityFinal1 TABLE(
    ATaskedIn varchar(50),
    AIDLE varchar(50),
	AAbsent varchar(50)
);


/*IDELE*/

INSERT INTO @CurrentProductivity (Team, IDLE)
SELECT [MUID] AS [Team],[UID] AS [IDLE]
FROM (
SELECT ud.M_UID AS [MUID], [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.P_Project=@mProject AND ud.P_Project_Availability='Active'
GROUP BY ud.M_UID, [UID]
) AMSTodayUID

WHERE [UID] NOT IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME) AND TR_TaskStatus=1
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)

/*Tasked In*/
INSERT INTO @CurrentProductivity (Team, TaskedIn)
SELECT [MUID] AS [Team], [UID] AS [Tasked-In]
FROM (
SELECT ud.M_UID AS [MUID], [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME())  AND ud.P_Project=@mProject AND ud.P_Project_Availability='Active'
GROUP BY ud.M_UID, [UID]
) AMSTodayUID

WHERE [UID] IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME) AND TR_TaskStatus=1
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)


/**Absent*/

INSERT INTO @CurrentProductivity (Team, [Absent])
SELECT M_UID AS [Team], P_UID AS [Absent] 
FROM ( SELECT ud.M_UID, uh.P_UID
	  FROM tbl_UserManagementHeader uh
	  INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=uh.P_UID
	  WHERE ud.PIC_UID=@mPIC AND uh.P_Availability=1 AND P_AccessLevel='Common User' AND ud.P_Project=@mProject AND ud.P_Project_Availability='Active'
	  GROUP BY ud.M_UID, uh.P_UID
) OperatorCount

WHERE P_UID NOT IN (
SELECT [UID] AS [IDLE]
FROM (
SELECT [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME())  AND ud.P_Project=@mProject AND ud.P_Project_Availability='Active'
GROUP BY [UID]
) AMSTodayUID
)


INSERT INTO @CurrentProductivityFinal (TTeam, TTaskedIn)
SELECT Team, TaskedIn
FROM @CurrentProductivity
GROUP BY Team, TaskedIn

INSERT INTO @CurrentProductivityFinal (TTeam, TIDLE)
SELECT Team, IDLE
FROM @CurrentProductivity
GROUP BY Team, IDLE


INSERT INTO @CurrentProductivityFinal (TTeam, TAbsent)
SELECT Team, [Absent]
FROM @CurrentProductivity
GROUP BY Team, [Absent];


WITH CTE AS (

SELECT
        TTeam,
        MAX(TTaskedIn) AS [TASKED-IN],
        MAX(TIDLE) AS [DILE],
        MAX(TAbsent) AS [ABSENT]
    FROM @CurrentProductivityFinal
    GROUP BY TTeam
    HAVING MAX(TTaskedIn) = MIN(TTaskedIn)
        AND MAX(TIDLE) = MIN(TIDLE)
        AND MAX(TAbsent) = MIN(TAbsent)
),
FINAL AS(
    SELECT [TASKED-IN],[DILE],[ABSENT]
    FROM CTE
    UNION ALL
    SELECT TTaskedIn,TIDLE,TAbsent
    FROM @CurrentProductivityFinal
    WHERE TTeam NOT IN (SELECT TTeam FROM CTE) 
	GROUP BY TTaskedIn,TIDLE,TAbsent
	HAVING TTaskedIn!='NULL' OR TIDLE!='NULL' OR TAbsent!='NULL'
	),
TASKEDIN AS(

	SELECT [TASKED-IN]
	FROM FINAL
	WHERE [TASKED-IN] IS NOT NULL),

DILES AS(
	SELECT [DILE]
	FROM FINAL
	WHERE [DILE] IS NOT NULL),

ABSENTS AS(
	SELECT [ABSENT]
	FROM FINAL
	WHERE [ABSENT] IS NOT NULL)

SELECT [TASKED-IN],[DILE] AS [IDLE],[ABSENT] FROM 
    (SELECT [TASKED-IN], row_number() OVER ( ORDER BY [TASKED-IN] ) as num FROM TASKEDIN) AS X
FULL OUTER JOIN 
    (SELECT [DILE], row_number() OVER ( ORDER BY [DILE] )as num FROM DILES) AS Y
		ON x.num = y.num
FULL OUTER JOIN 
    (SELECT [ABSENT], row_number() OVER ( ORDER BY [ABSENT] ) as num FROM ABSENTS) AS Z
		ON z.num=x.num


GO
/****** Object:  StoredProcedure [dbo].[Dboard_CurrentTeamCapacity_DetailedByPIC_FilterByProjctAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_CurrentTeamCapacity_DetailedByPIC_FilterByProjctAndManager] @mPIC nvarchar(30), @mProject nvarchar(50), @mMUID nvarchar(30)

AS

DECLARE @CurrentProductivity TABLE(
	Team varchar(50),
    TaskedIn varchar(50),
    IDLE varchar(50),
	[Absent] varchar(50)
);
DECLARE @CurrentProductivityFinal TABLE(
	TTeam varchar(50),
    TTaskedIn varchar(50),
    TIDLE varchar(50),
	TAbsent varchar(50)
);
DECLARE @CurrentProductivityFinal1 TABLE(
    ATaskedIn varchar(50),
    AIDLE varchar(50),
	AAbsent varchar(50)
);


/*IDELE*/

INSERT INTO @CurrentProductivity (Team, IDLE)
SELECT [MUID] AS [Team],[UID] AS [IDLE]
FROM (
SELECT ud.M_UID AS [MUID], [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND ud.M_UID=@mMUID AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.P_Project=@mProject AND ud.P_Project_Availability='Active'
GROUP BY ud.M_UID, [UID]
) AMSTodayUID

WHERE [UID] NOT IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_MID=@mMUID AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME) AND TR_TaskStatus=1
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)

/*Tasked In*/
INSERT INTO @CurrentProductivity (Team, TaskedIn)
SELECT [MUID] AS [Team], [UID] AS [Tasked-In]
FROM (
SELECT ud.M_UID AS [MUID], [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND ud.M_UID=@mMUID AND [DATE]=CONVERT (date, SYSDATETIME())  AND ud.P_Project=@mProject AND ud.P_Project_Availability='Active'
GROUP BY ud.M_UID, [UID]
) AMSTodayUID

WHERE [UID] IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_MID=@mMUID AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME) AND TR_TaskStatus=1
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)


/**Absent*/

INSERT INTO @CurrentProductivity (Team, [Absent])
SELECT M_UID AS [Team], P_UID AS [Absent] 
FROM ( SELECT ud.M_UID, uh.P_UID
	  FROM tbl_UserManagementHeader uh
	  INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=uh.P_UID
	  WHERE ud.PIC_UID=@mPIC AND ud.M_UID=@mMUID AND uh.P_Availability=1 AND P_AccessLevel='Common User' AND ud.P_Project=@mProject AND ud.P_Project_Availability='Active'
	  GROUP BY ud.M_UID, uh.P_UID
) OperatorCount

WHERE P_UID NOT IN (
SELECT [UID] AS [IDLE]
FROM (
SELECT [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND ud.M_UID=@mMUID AND [DATE]=CONVERT (date, SYSDATETIME())  AND ud.P_Project=@mProject AND ud.P_Project_Availability='Active'
GROUP BY [UID]
) AMSTodayUID
)


INSERT INTO @CurrentProductivityFinal (TTeam, TTaskedIn)
SELECT Team, TaskedIn
FROM @CurrentProductivity
GROUP BY Team, TaskedIn

INSERT INTO @CurrentProductivityFinal (TTeam, TIDLE)
SELECT Team, IDLE
FROM @CurrentProductivity
GROUP BY Team, IDLE


INSERT INTO @CurrentProductivityFinal (TTeam, TAbsent)
SELECT Team, [Absent]
FROM @CurrentProductivity
GROUP BY Team, [Absent];


WITH CTE AS (

SELECT
        TTeam,
        MAX(TTaskedIn) AS [TASKED-IN],
        MAX(TIDLE) AS [DILE],
        MAX(TAbsent) AS [ABSENT]
    FROM @CurrentProductivityFinal
    GROUP BY TTeam
    HAVING MAX(TTaskedIn) = MIN(TTaskedIn)
        AND MAX(TIDLE) = MIN(TIDLE)
        AND MAX(TAbsent) = MIN(TAbsent)
),
FINAL AS(
    SELECT [TASKED-IN],[DILE],[ABSENT]
    FROM CTE
    UNION ALL
    SELECT TTaskedIn,TIDLE,TAbsent
    FROM @CurrentProductivityFinal
    WHERE TTeam NOT IN (SELECT TTeam FROM CTE) 
	GROUP BY TTaskedIn,TIDLE,TAbsent
	HAVING TTaskedIn!='NULL' OR TIDLE!='NULL' OR TAbsent!='NULL'
	),
TASKEDIN AS(

	SELECT [TASKED-IN]
	FROM FINAL
	WHERE [TASKED-IN] IS NOT NULL),

DILES AS(
	SELECT [DILE]
	FROM FINAL
	WHERE [DILE] IS NOT NULL),

ABSENTS AS(
	SELECT [ABSENT]
	FROM FINAL
	WHERE [ABSENT] IS NOT NULL)

SELECT [TASKED-IN],[DILE] AS [IDLE],[ABSENT] FROM 
    (SELECT [TASKED-IN], row_number() OVER ( ORDER BY [TASKED-IN] ) as num FROM TASKEDIN) AS X
FULL OUTER JOIN 
    (SELECT [DILE], row_number() OVER ( ORDER BY [DILE] )as num FROM DILES) AS Y
		ON x.num = y.num
FULL OUTER JOIN 
    (SELECT [ABSENT], row_number() OVER ( ORDER BY [ABSENT] ) as num FROM ABSENTS) AS Z
		ON z.num=x.num


GO
/****** Object:  StoredProcedure [dbo].[Dboard_CurrentTeamCapacity_DetailedByPIC_FilterByUser]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_CurrentTeamCapacity_DetailedByPIC_FilterByUser] @mPIC nvarchar(30), @mUID nvarchar(50) 

AS

DECLARE @CurrentProductivity TABLE(
	Team varchar(50),
    TaskedIn varchar(50),
    IDLE varchar(50),
	[Absent] varchar(50)
);
DECLARE @CurrentProductivityFinal TABLE(
	TTeam varchar(50),
    TTaskedIn int,
    TIDLE int,
	TAbsent int
);


/*IDELE*/

INSERT INTO @CurrentProductivity (Team, IDLE)
SELECT [MUID] AS [Team],[UID] AS [IDLE]
FROM (
SELECT ud.M_UID AS [MUID], [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.P_UID=@mUID AND ud.P_Project_Availability='Active'
GROUP BY ud.M_UID, [UID]
) AMSTodayUID

WHERE [UID] NOT IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME) AND TR_TaskStatus=1
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)

/*Tasked In*/
INSERT INTO @CurrentProductivity (Team, TaskedIn)
SELECT [MUID] AS [Team], [UID] AS [Tasked-In]
FROM (
SELECT ud.M_UID AS [MUID], [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.P_UID=@mUID AND ud.P_Project_Availability='Active'
GROUP BY ud.M_UID, [UID]
) AMSTodayUID

WHERE [UID] IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME) AND TR_TaskStatus=1
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)


/**Absent*/

INSERT INTO @CurrentProductivity (Team, [Absent])
SELECT M_UID AS [Team], P_UID AS [Absent] 
FROM ( SELECT ud.M_UID, uh.P_UID
	  FROM tbl_UserManagementHeader uh
	  INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=uh.P_UID
	  WHERE ud.PIC_UID=@mPIC AND uh.P_Availability=1 AND P_AccessLevel='Common User' AND ud.P_UID=@mUID AND ud.P_Project_Availability='Active'
	  GROUP BY ud.M_UID, uh.P_UID
) OperatorCount

WHERE P_UID NOT IN (
SELECT [UID] AS [IDLE]
FROM (
SELECT [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.P_UID=@mUID AND ud.P_Project_Availability='Active'
GROUP BY [UID]
) AMSTodayUID
)


INSERT INTO @CurrentProductivityFinal (TTeam, TTaskedIn)
SELECT Team, COUNT(TaskedIn)
FROM @CurrentProductivity
GROUP BY Team

INSERT INTO @CurrentProductivityFinal (TTeam, TIDLE)
SELECT Team, COUNT(IDLE)
FROM @CurrentProductivity
GROUP BY Team


INSERT INTO @CurrentProductivityFinal (TTeam, TAbsent)
SELECT Team, COUNT([Absent])
FROM @CurrentProductivity
GROUP BY Team


SELECT TTeam AS [TEAM], SUM(TTaskedIn) AS [TASKED-IN],SUM(TIDLE) AS [IDLE] ,SUM(TAbsent) AS [ABSENT]
FROM @CurrentProductivityFinal
GROUP BY TTeam

GO
/****** Object:  StoredProcedure [dbo].[Dboard_CurrentTeamCapacity_DetailedByPIC_FilterByUserAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_CurrentTeamCapacity_DetailedByPIC_FilterByUserAndManager] @mPIC nvarchar(30), @mUID nvarchar(50), @mMUID nvarchar(30)

AS

DECLARE @CurrentProductivity TABLE(
	Team varchar(50),
    TaskedIn varchar(50),
    IDLE varchar(50),
	[Absent] varchar(50)
);
DECLARE @CurrentProductivityFinal TABLE(
	TTeam varchar(50),
    TTaskedIn int,
    TIDLE int,
	TAbsent int
);


/*IDELE*/

INSERT INTO @CurrentProductivity (Team, IDLE)
SELECT [MUID] AS [Team],[UID] AS [IDLE]
FROM (
SELECT ud.M_UID AS [MUID], [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND ud.M_UID=@mMUID AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.P_UID=@mUID AND ud.P_Project_Availability='Active'
GROUP BY ud.M_UID, [UID]
) AMSTodayUID

WHERE [UID] NOT IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_MID=@mMUID AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME) AND TR_TaskStatus=1
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)

/*Tasked In*/
INSERT INTO @CurrentProductivity (Team, TaskedIn)
SELECT [MUID] AS [Team], [UID] AS [Tasked-In]
FROM (
SELECT ud.M_UID AS [MUID], [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND ud.M_UID=@mMUID AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.P_UID=@mUID AND ud.P_Project_Availability='Active'
GROUP BY ud.M_UID, [UID]
) AMSTodayUID

WHERE [UID] IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_MID=@mMUID AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME) AND TR_TaskStatus=1
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)


/**Absent*/

INSERT INTO @CurrentProductivity (Team, [Absent])
SELECT M_UID AS [Team], P_UID AS [Absent] 
FROM ( SELECT ud.M_UID, uh.P_UID
	  FROM tbl_UserManagementHeader uh
	  INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=uh.P_UID
	  WHERE ud.PIC_UID=@mPIC AND ud.M_UID=@mMUID AND uh.P_Availability=1 AND P_AccessLevel='Common User' AND ud.P_UID=@mUID AND ud.P_Project_Availability='Active'
	  GROUP BY ud.M_UID, uh.P_UID
) OperatorCount

WHERE P_UID NOT IN (
SELECT [UID] AS [IDLE]
FROM (
SELECT [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND ud.M_UID=@mMUID AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.P_UID=@mUID AND ud.P_Project_Availability='Active'
GROUP BY [UID]
) AMSTodayUID
)


INSERT INTO @CurrentProductivityFinal (TTeam, TTaskedIn)
SELECT Team, COUNT(TaskedIn)
FROM @CurrentProductivity
GROUP BY Team

INSERT INTO @CurrentProductivityFinal (TTeam, TIDLE)
SELECT Team, COUNT(IDLE)
FROM @CurrentProductivity
GROUP BY Team


INSERT INTO @CurrentProductivityFinal (TTeam, TAbsent)
SELECT Team, COUNT([Absent])
FROM @CurrentProductivity
GROUP BY Team


SELECT TTeam AS [TEAM], SUM(TTaskedIn) AS [TASKED-IN],SUM(TIDLE) AS [IDLE] ,SUM(TAbsent) AS [ABSENT]
FROM @CurrentProductivityFinal
GROUP BY TTeam

GO
/****** Object:  StoredProcedure [dbo].[Dboard_CurrentTeamCapacityByPIC]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_CurrentTeamCapacityByPIC] @mPIC nvarchar(30) 

AS

DECLARE @CurrentProductivity TABLE(
	Team varchar(50),
    TaskedIn varchar(50),
    IDLE varchar(50),
	[Absent] varchar(50)
);
DECLARE @CurrentProductivityFinal TABLE(
	TTeam varchar(50),
    TTaskedIn int,
    TIDLE int,
	TAbsent int
);


/*IDELE*/

INSERT INTO @CurrentProductivity (Team, IDLE)
SELECT [MUID] AS [Team],[UID] AS [IDLE]
FROM (
SELECT ud.M_UID AS [MUID], [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.P_Project_Availability='Active'
GROUP BY ud.M_UID, [UID]
) AMSTodayUID

WHERE [UID] NOT IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME) AND TR_TaskStatus=1
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)

/*Tasked In*/
INSERT INTO @CurrentProductivity (Team, TaskedIn)
SELECT [MUID] AS [Team], [UID] AS [Tasked-In]
FROM (
SELECT ud.M_UID AS [MUID], [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.P_Project_Availability='Active'
GROUP BY ud.M_UID, [UID]
) AMSTodayUID

WHERE [UID] IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)  AND TR_TaskStatus=1
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)


/**Absent*/

INSERT INTO @CurrentProductivity (Team, [Absent])
SELECT M_UID AS [Team], P_UID AS [Absent] 
FROM ( SELECT ud.M_UID, uh.P_UID
	  FROM tbl_UserManagementHeader uh
	  INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=uh.P_UID
	  WHERE ud.PIC_UID=@mPIC AND uh.P_Availability=1 AND P_AccessLevel='Common User' AND ud.P_Project_Availability='Active'
	  GROUP BY ud.M_UID, uh.P_UID
) OperatorCount

WHERE P_UID NOT IN (
SELECT [UID] AS [IDLE]
FROM (
SELECT [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME())  AND ud.P_Project_Availability='Active'
GROUP BY [UID]
) AMSTodayUID
)


INSERT INTO @CurrentProductivityFinal (TTeam, TTaskedIn)
SELECT Team, COUNT(TaskedIn)
FROM @CurrentProductivity
GROUP BY Team

INSERT INTO @CurrentProductivityFinal (TTeam, TIDLE)
SELECT Team, COUNT(IDLE)
FROM @CurrentProductivity
GROUP BY Team


INSERT INTO @CurrentProductivityFinal (TTeam, TAbsent)
SELECT Team, COUNT([Absent])
FROM @CurrentProductivity
GROUP BY Team


SELECT TTeam AS [TEAM], SUM(TTaskedIn) AS [TASKED-IN],SUM(TIDLE) AS [IDLE] ,SUM(TAbsent) AS [ABSENT]
FROM @CurrentProductivityFinal
GROUP BY TTeam

GO
/****** Object:  StoredProcedure [dbo].[Dboard_CurrentTeamCapacityByPIC_FilterByManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Dboard_CurrentTeamCapacityByPIC_FilterByManager] @mPIC nvarchar(30), @mMUID nvarchar(50) 

AS

DECLARE @CurrentProductivity TABLE(
	Team varchar(50),
    TaskedIn varchar(50),
    IDLE varchar(50),
	[Absent] varchar(50)
);
DECLARE @CurrentProductivityFinal TABLE(
	TTeam varchar(50),
    TTaskedIn int,
    TIDLE int,
	TAbsent int
);


/*IDELE*/

INSERT INTO @CurrentProductivity (Team, IDLE)
SELECT [MUID] AS [Team],[UID] AS [IDLE]
FROM (
SELECT ud.M_UID AS [MUID], [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.M_UID=@mMUID AND ud.P_Project_Availability='Active'
GROUP BY ud.M_UID, [UID]
) AMSTodayUID

WHERE [UID] NOT IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME) AND TR_TaskStatus=1
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)

/*Tasked In*/
INSERT INTO @CurrentProductivity (Team, TaskedIn)
SELECT [MUID] AS [Team], [UID] AS [Tasked-In]
FROM (
SELECT ud.M_UID AS [MUID], [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.M_UID=@mMUID AND ud.P_Project_Availability='Active'
GROUP BY ud.M_UID, [UID]
) AMSTodayUID

WHERE [UID] IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME) AND TR_TaskStatus=1
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)


/**Absent*/

INSERT INTO @CurrentProductivity (Team, [Absent])
SELECT M_UID AS [Team], P_UID AS [Absent] 
FROM ( SELECT ud.M_UID, uh.P_UID
	  FROM tbl_UserManagementHeader uh
	  INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=uh.P_UID
	  WHERE ud.PIC_UID=@mPIC AND uh.P_Availability=1 AND P_AccessLevel='Common User' AND ud.M_UID=@mMUID AND ud.P_Project_Availability='Active'
	  GROUP BY ud.M_UID, uh.P_UID
) OperatorCount

WHERE P_UID NOT IN (
SELECT [UID] AS [IDLE]
FROM (
SELECT [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.M_UID=@mMUID AND ud.P_Project_Availability='Active'
GROUP BY [UID]
) AMSTodayUID
)


INSERT INTO @CurrentProductivityFinal (TTeam, TTaskedIn)
SELECT Team, COUNT(TaskedIn)
FROM @CurrentProductivity
GROUP BY Team

INSERT INTO @CurrentProductivityFinal (TTeam, TIDLE)
SELECT Team, COUNT(IDLE)
FROM @CurrentProductivity
GROUP BY Team


INSERT INTO @CurrentProductivityFinal (TTeam, TAbsent)
SELECT Team, COUNT([Absent])
FROM @CurrentProductivity
GROUP BY Team


SELECT TTeam AS [TEAM], SUM(TTaskedIn) AS [TASKED-IN],SUM(TIDLE) AS [IDLE] ,SUM(TAbsent) AS [ABSENT]
FROM @CurrentProductivityFinal
GROUP BY TTeam

GO
/****** Object:  StoredProcedure [dbo].[Dboard_CurrentTeamCapacityByPIC_FilterByProject]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Dboard_CurrentTeamCapacityByPIC_FilterByProject] @mPIC nvarchar(30), @mProject nvarchar(50) 

AS

DECLARE @CurrentProductivity TABLE(
	Team varchar(50),
    TaskedIn varchar(50),
    IDLE varchar(50),
	[Absent] varchar(50)
);
DECLARE @CurrentProductivityFinal TABLE(
	TTeam varchar(50),
    TTaskedIn int,
    TIDLE int,
	TAbsent int
);


/*IDELE*/

INSERT INTO @CurrentProductivity (Team, IDLE)
SELECT [MUID] AS [Team],[UID] AS [IDLE]
FROM (
SELECT ud.M_UID AS [MUID], [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.P_Project=@mProject AND ud.P_Project_Availability='Active'
GROUP BY ud.M_UID, [UID]
) AMSTodayUID

WHERE [UID] NOT IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME) AND TR_TaskStatus=1
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)

/*Tasked In*/
INSERT INTO @CurrentProductivity (Team, TaskedIn)
SELECT [MUID] AS [Team], [UID] AS [Tasked-In]
FROM (
SELECT ud.M_UID AS [MUID], [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.P_Project=@mProject AND ud.P_Project_Availability='Active'
GROUP BY ud.M_UID, [UID]
) AMSTodayUID

WHERE [UID] IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME) AND TR_TaskStatus=1
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)


/**Absent*/

INSERT INTO @CurrentProductivity (Team, [Absent])
SELECT M_UID AS [Team], P_UID AS [Absent] 
FROM ( SELECT ud.M_UID, uh.P_UID
	  FROM tbl_UserManagementHeader uh
	  INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=uh.P_UID
	  WHERE ud.PIC_UID=@mPIC AND uh.P_Availability=1 AND P_AccessLevel='Common User' AND ud.P_Project=@mProject AND ud.P_Project_Availability='Active'
	  GROUP BY ud.M_UID, uh.P_UID
) OperatorCount

WHERE P_UID NOT IN (
SELECT [UID] AS [IDLE]
FROM (
SELECT [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.P_Project=@mProject AND ud.P_Project_Availability='Active'
GROUP BY [UID]
) AMSTodayUID
)


INSERT INTO @CurrentProductivityFinal (TTeam, TTaskedIn)
SELECT Team, COUNT(TaskedIn)
FROM @CurrentProductivity
GROUP BY Team

INSERT INTO @CurrentProductivityFinal (TTeam, TIDLE)
SELECT Team, COUNT(IDLE)
FROM @CurrentProductivity
GROUP BY Team


INSERT INTO @CurrentProductivityFinal (TTeam, TAbsent)
SELECT Team, COUNT([Absent])
FROM @CurrentProductivity
GROUP BY Team


SELECT TTeam AS [TEAM], SUM(TTaskedIn) AS [TASKED-IN],SUM(TIDLE) AS [IDLE] ,SUM(TAbsent) AS [ABSENT]
FROM @CurrentProductivityFinal
GROUP BY TTeam

GO
/****** Object:  StoredProcedure [dbo].[Dboard_CurrentTeamCapacityByPIC_FilterByProjectAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_CurrentTeamCapacityByPIC_FilterByProjectAndManager] @mPIC nvarchar(30), @mProject nvarchar(50), @mMUID nvarchar(30)

AS

DECLARE @CurrentProductivity TABLE(
	Team varchar(50),
    TaskedIn varchar(50),
    IDLE varchar(50),
	[Absent] varchar(50)
);
DECLARE @CurrentProductivityFinal TABLE(
	TTeam varchar(50),
    TTaskedIn int,
    TIDLE int,
	TAbsent int
);


/*IDELE*/

INSERT INTO @CurrentProductivity (Team, IDLE)
SELECT [MUID] AS [Team],[UID] AS [IDLE]
FROM (
SELECT ud.M_UID AS [MUID], [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND ud.M_UID=@mMUID AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.P_Project=@mProject AND ud.P_Project_Availability='Active'
GROUP BY ud.M_UID, [UID]
) AMSTodayUID

WHERE [UID] NOT IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_MID=@mMUID AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME) AND TR_TaskStatus=1
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)

/*Tasked In*/
INSERT INTO @CurrentProductivity (Team, TaskedIn)
SELECT [MUID] AS [Team], [UID] AS [Tasked-In]
FROM (
SELECT ud.M_UID AS [MUID], [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND ud.M_UID=@mMUID AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.P_Project=@mProject AND ud.P_Project_Availability='Active'
GROUP BY ud.M_UID, [UID]
) AMSTodayUID

WHERE [UID] IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_MID=@mMUID AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME) AND TR_TaskStatus=1
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)


/**Absent*/

INSERT INTO @CurrentProductivity (Team, [Absent])
SELECT M_UID AS [Team], P_UID AS [Absent] 
FROM ( SELECT ud.M_UID, uh.P_UID
	  FROM tbl_UserManagementHeader uh
	  INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=uh.P_UID
	  WHERE ud.PIC_UID=@mPIC AND ud.M_UID=@mMUID AND uh.P_Availability=1 AND P_AccessLevel='Common User' AND ud.P_Project=@mProject AND ud.P_Project_Availability='Active'
	  GROUP BY ud.M_UID, uh.P_UID
) OperatorCount

WHERE P_UID NOT IN (
SELECT [UID] AS [IDLE]
FROM (
SELECT [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND ud.M_UID=@mMUID AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.P_Project=@mProject AND ud.P_Project_Availability='Active'
GROUP BY [UID]
) AMSTodayUID
)


INSERT INTO @CurrentProductivityFinal (TTeam, TTaskedIn)
SELECT Team, COUNT(TaskedIn)
FROM @CurrentProductivity
GROUP BY Team

INSERT INTO @CurrentProductivityFinal (TTeam, TIDLE)
SELECT Team, COUNT(IDLE)
FROM @CurrentProductivity
GROUP BY Team


INSERT INTO @CurrentProductivityFinal (TTeam, TAbsent)
SELECT Team, COUNT([Absent])
FROM @CurrentProductivity
GROUP BY Team


SELECT TTeam AS [TEAM], SUM(TTaskedIn) AS [TASKED-IN],SUM(TIDLE) AS [IDLE] ,SUM(TAbsent) AS [ABSENT]
FROM @CurrentProductivityFinal
GROUP BY TTeam

GO
/****** Object:  StoredProcedure [dbo].[Dboard_CurrentTeamCapacityByPIC_FilterByUser]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_CurrentTeamCapacityByPIC_FilterByUser] @mPIC nvarchar(30), @mUID nvarchar(50) 

AS

DECLARE @CurrentProductivity TABLE(
	Team varchar(50),
    TaskedIn varchar(50),
    IDLE varchar(50),
	[Absent] varchar(50)
);
DECLARE @CurrentProductivityFinal TABLE(
	TTeam varchar(50),
    TTaskedIn varchar(50),
    TIDLE varchar(50),
	TAbsent varchar(50)
);
DECLARE @CurrentProductivityFinal1 TABLE(
    ATaskedIn varchar(50),
    AIDLE varchar(50),
	AAbsent varchar(50)
);


/*IDELE*/

INSERT INTO @CurrentProductivity (Team, IDLE)
SELECT [MUID] AS [Team],[UID] AS [IDLE]
FROM (
SELECT ud.M_UID AS [MUID], [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.P_UID=@mUID AND ud.P_Project_Availability='Active'
GROUP BY ud.M_UID, [UID]
) AMSTodayUID

WHERE [UID] NOT IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME) AND TR_TaskStatus=1
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)

/*Tasked In*/
INSERT INTO @CurrentProductivity (Team, TaskedIn)
SELECT [MUID] AS [Team], [UID] AS [Tasked-In]
FROM (
SELECT ud.M_UID AS [MUID], [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.P_UID=@mUID AND ud.P_Project_Availability='Active'
GROUP BY ud.M_UID, [UID]
) AMSTodayUID

WHERE [UID] IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME) AND TR_TaskStatus=1
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)


/**Absent*/

INSERT INTO @CurrentProductivity (Team, [Absent])
SELECT M_UID AS [Team], P_UID AS [Absent] 
FROM ( SELECT ud.M_UID, uh.P_UID
	  FROM tbl_UserManagementHeader uh
	  INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=uh.P_UID
	  WHERE ud.PIC_UID=@mPIC AND uh.P_Availability=1 AND P_AccessLevel='Common User' AND ud.P_UID=@mUID AND ud.P_Project_Availability='Active'
	  GROUP BY ud.M_UID, uh.P_UID
) OperatorCount

WHERE P_UID NOT IN (
SELECT [UID] AS [IDLE]
FROM (
SELECT [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.P_UID=@mUID AND ud.P_Project_Availability='Active'
GROUP BY [UID]
) AMSTodayUID
)


INSERT INTO @CurrentProductivityFinal (TTeam, TTaskedIn)
SELECT Team, TaskedIn
FROM @CurrentProductivity
GROUP BY Team, TaskedIn

INSERT INTO @CurrentProductivityFinal (TTeam, TIDLE)
SELECT Team, IDLE
FROM @CurrentProductivity
GROUP BY Team, IDLE


INSERT INTO @CurrentProductivityFinal (TTeam, TAbsent)
SELECT Team, [Absent]
FROM @CurrentProductivity
GROUP BY Team, [Absent];


WITH CTE AS (

SELECT
        TTeam,
        MAX(TTaskedIn) AS [TASKED-IN],
        MAX(TIDLE) AS [DILE],
        MAX(TAbsent) AS [ABSENT]
    FROM @CurrentProductivityFinal
    GROUP BY TTeam
    HAVING MAX(TTaskedIn) = MIN(TTaskedIn)
        AND MAX(TIDLE) = MIN(TIDLE)
        AND MAX(TAbsent) = MIN(TAbsent)
),
FINAL AS(
    SELECT [TASKED-IN],[DILE],[ABSENT]
    FROM CTE
    UNION ALL
    SELECT TTaskedIn,TIDLE,TAbsent
    FROM @CurrentProductivityFinal
    WHERE TTeam NOT IN (SELECT TTeam FROM CTE) 
	GROUP BY TTaskedIn,TIDLE,TAbsent
	HAVING TTaskedIn!='NULL' OR TIDLE!='NULL' OR TAbsent!='NULL'
	),
TASKEDIN AS(

	SELECT [TASKED-IN]
	FROM FINAL
	WHERE [TASKED-IN] IS NOT NULL),

DILES AS(
	SELECT [DILE]
	FROM FINAL
	WHERE [DILE] IS NOT NULL),

ABSENTS AS(
	SELECT [ABSENT]
	FROM FINAL
	WHERE [ABSENT] IS NOT NULL)

SELECT [TASKED-IN],[DILE] AS [IDLE],[ABSENT] FROM 
    (SELECT [TASKED-IN], row_number() OVER ( ORDER BY [TASKED-IN] ) as num FROM TASKEDIN) AS X
FULL OUTER JOIN 
    (SELECT [DILE], row_number() OVER ( ORDER BY [DILE] )as num FROM DILES) AS Y
		ON x.num = y.num
FULL OUTER JOIN 
    (SELECT [ABSENT], row_number() OVER ( ORDER BY [ABSENT] ) as num FROM ABSENTS) AS Z
		ON z.num=x.num

GO
/****** Object:  StoredProcedure [dbo].[Dboard_CurrentTeamCapacityByPIC_FilterByUserAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_CurrentTeamCapacityByPIC_FilterByUserAndManager] @mPIC nvarchar(30), @mUID nvarchar(50), @mMUID nvarchar(30)

AS

DECLARE @CurrentProductivity TABLE(
	Team varchar(50),
    TaskedIn varchar(50),
    IDLE varchar(50),
	[Absent] varchar(50)
);
DECLARE @CurrentProductivityFinal TABLE(
	TTeam varchar(50),
    TTaskedIn varchar(50),
    TIDLE varchar(50),
	TAbsent varchar(50)
);
DECLARE @CurrentProductivityFinal1 TABLE(
    ATaskedIn varchar(50),
    AIDLE varchar(50),
	AAbsent varchar(50)
);


/*IDELE*/

INSERT INTO @CurrentProductivity (Team, IDLE)
SELECT [MUID] AS [Team],[UID] AS [IDLE]
FROM (
SELECT ud.M_UID AS [MUID], [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND ud.M_UID=@mMUID AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.P_UID=@mUID AND ud.P_Project_Availability='Active'
GROUP BY ud.M_UID, [UID]
) AMSTodayUID

WHERE [UID] NOT IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_MID=@mMUID AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME) AND TR_TaskStatus=1
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)

/*Tasked In*/
INSERT INTO @CurrentProductivity (Team, TaskedIn)
SELECT [MUID] AS [Team], [UID] AS [Tasked-In]
FROM (
SELECT ud.M_UID AS [MUID], [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND ud.M_UID=@mMUID AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.P_UID=@mUID AND ud.P_Project_Availability='Active'
GROUP BY ud.M_UID, [UID]
) AMSTodayUID

WHERE [UID] IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_MID=@mMUID AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME) AND TR_TaskStatus=1
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)


/**Absent*/

INSERT INTO @CurrentProductivity (Team, [Absent])
SELECT M_UID AS [Team], P_UID AS [Absent] 
FROM ( SELECT ud.M_UID, uh.P_UID
	  FROM tbl_UserManagementHeader uh
	  INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=uh.P_UID
	  WHERE ud.PIC_UID=@mPIC AND ud.M_UID=@mMUID AND uh.P_Availability=1 AND P_AccessLevel='Common User' AND ud.P_UID=@mUID AND ud.P_Project_Availability='Active'
	  GROUP BY ud.M_UID, uh.P_UID
) OperatorCount

WHERE P_UID NOT IN (
SELECT [UID] AS [IDLE]
FROM (
SELECT [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND ud.M_UID=@mMUID AND [DATE]=CONVERT (date, SYSDATETIME()) AND ud.P_UID=@mUID AND ud.P_Project_Availability='Active'
GROUP BY [UID]
) AMSTodayUID
)


INSERT INTO @CurrentProductivityFinal (TTeam, TTaskedIn)
SELECT Team, TaskedIn
FROM @CurrentProductivity
GROUP BY Team, TaskedIn

INSERT INTO @CurrentProductivityFinal (TTeam, TIDLE)
SELECT Team, IDLE
FROM @CurrentProductivity
GROUP BY Team, IDLE


INSERT INTO @CurrentProductivityFinal (TTeam, TAbsent)
SELECT Team, [Absent]
FROM @CurrentProductivity
GROUP BY Team, [Absent];


WITH CTE AS (

SELECT
        TTeam,
        MAX(TTaskedIn) AS [TASKED-IN],
        MAX(TIDLE) AS [DILE],
        MAX(TAbsent) AS [ABSENT]
    FROM @CurrentProductivityFinal
    GROUP BY TTeam
    HAVING MAX(TTaskedIn) = MIN(TTaskedIn)
        AND MAX(TIDLE) = MIN(TIDLE)
        AND MAX(TAbsent) = MIN(TAbsent)
),
FINAL AS(
    SELECT [TASKED-IN],[DILE],[ABSENT]
    FROM CTE
    UNION ALL
    SELECT TTaskedIn,TIDLE,TAbsent
    FROM @CurrentProductivityFinal
    WHERE TTeam NOT IN (SELECT TTeam FROM CTE) 
	GROUP BY TTaskedIn,TIDLE,TAbsent
	HAVING TTaskedIn!='NULL' OR TIDLE!='NULL' OR TAbsent!='NULL'
	),
TASKEDIN AS(

	SELECT [TASKED-IN]
	FROM FINAL
	WHERE [TASKED-IN] IS NOT NULL),

DILES AS(
	SELECT [DILE]
	FROM FINAL
	WHERE [DILE] IS NOT NULL),

ABSENTS AS(
	SELECT [ABSENT]
	FROM FINAL
	WHERE [ABSENT] IS NOT NULL)

SELECT [TASKED-IN],[DILE] AS [IDLE],[ABSENT] FROM 
    (SELECT [TASKED-IN], row_number() OVER ( ORDER BY [TASKED-IN] ) as num FROM TASKEDIN) AS X
FULL OUTER JOIN 
    (SELECT [DILE], row_number() OVER ( ORDER BY [DILE] )as num FROM DILES) AS Y
		ON x.num = y.num
FULL OUTER JOIN 
    (SELECT [ABSENT], row_number() OVER ( ORDER BY [ABSENT] ) as num FROM ABSENTS) AS Z
		ON z.num=x.num

GO
/****** Object:  StoredProcedure [dbo].[Dboard_Exceed5Mins]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Dboard_Exceed5Mins] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime

AS

	SELECT T.TR_UID AS [UID], L.[DATE] AS [DATE], L.FIRSTLOGIN AS [FIRST-IN], MIN(T.TR_InDate) AS [TASKED-IN], CAST(ROUND(DATEDIFF(MINUTE,L.FIRSTLOGIN, MIN(T.TR_InDate))/60.0, 3)AS decimal (6,3)) AS [HOURS]
	FROM tbl_TaskRecordDetail T
	INNER JOIN tbl_UserLILO L ON T.TR_UID=L.[UID] AND L.[DATE]=convert(date, T.TR_InDate)
	WHERE T.TR_PIC=@mPIC AND T.TR_InDate BETWEEN @mFrom AND @mTo
	GROUP BY  T.TR_UID, L.[DATE], L.FIRSTLOGIN
	HAVING DATEDIFF(MINUTE,L.FIRSTLOGIN, MIN(T.TR_InDate)) > 5
	ORDER BY L.[DATE] DESC

GO
/****** Object:  StoredProcedure [dbo].[Dboard_Exceed5MinsByPICAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_Exceed5MinsByPICAndManager] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime, @mMID nvarchar(30)

AS

	SELECT T.TR_UID AS [UID], L.[DATE] AS [DATE], L.FIRSTLOGIN AS [FIRST-IN], MIN(T.TR_InDate) AS [TASKED-IN], CAST(ROUND(DATEDIFF(MINUTE,L.FIRSTLOGIN, MIN(T.TR_InDate))/60.0, 3)AS decimal (6,3)) AS [HOURS]
	FROM tbl_TaskRecordDetail T
	INNER JOIN tbl_UserLILO L ON T.TR_UID=L.[UID] AND L.[DATE]=convert(date, T.TR_InDate)
	WHERE T.TR_PIC=@mPIC AND T.TR_InDate BETWEEN @mFrom AND @mTo AND T.TR_MID=@mMID
	GROUP BY  T.TR_UID, L.[DATE], L.FIRSTLOGIN
	HAVING DATEDIFF(MINUTE,L.FIRSTLOGIN, MIN(T.TR_InDate)) > 5
	ORDER BY L.[DATE] DESC

GO
/****** Object:  StoredProcedure [dbo].[Dboard_Exceed5MinsByPICAndUID]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_Exceed5MinsByPICAndUID] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime, @mUID nvarchar(30)

AS
	SELECT T.TR_UID AS [UID], L.[DATE] AS [DATE], L.FIRSTLOGIN AS [FIRST-IN], MIN(T.TR_InDate) AS [TASKED-IN], CAST(ROUND(DATEDIFF(MINUTE,L.FIRSTLOGIN, MIN(T.TR_InDate))/60.0, 3)AS decimal (6,3)) AS [HOURS]
	FROM tbl_TaskRecordDetail T
	INNER JOIN tbl_UserLILO L ON T.TR_UID=L.[UID] AND L.[DATE]=convert(date, T.TR_InDate)
	WHERE T.TR_PIC=@mPIC AND T.TR_InDate BETWEEN @mFrom AND @mTo AND T.TR_UID=@mUID
	GROUP BY  T.TR_UID, L.[DATE], L.FIRSTLOGIN
	HAVING DATEDIFF(MINUTE,L.FIRSTLOGIN, MIN(T.TR_InDate)) > 5
	ORDER BY L.[DATE] DESC
GO
/****** Object:  StoredProcedure [dbo].[Dboard_Exceed5MinsByProject]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_Exceed5MinsByProject] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime, @mProject nvarchar(30)

AS

SELECT T.TR_UID AS [UID], L.[DATE] AS [DATE], L.FIRSTLOGIN AS [FIRST-IN], MIN(T.TR_InDate) AS [TASKED-IN], CAST(ROUND(DATEDIFF(MINUTE,L.FIRSTLOGIN, MIN(T.TR_InDate))/60.0, 3)AS decimal (6,3)) AS [HOURS]
	FROM tbl_TaskRecordDetail T
	INNER JOIN tbl_UserLILO L ON T.TR_UID=L.[UID] AND L.[DATE]=convert(date, T.TR_InDate)
	INNER JOIN tbl_PCPDetail P ON T.PCP_ID=P.PCP_ID AND P.Task_ID=T.Task_ID
	WHERE T.TR_PIC=@mPIC AND T.TR_InDate BETWEEN @mFrom AND @mTo AND P.PCP_Project=@mProject
	GROUP BY  T.TR_UID, L.[DATE], L.FIRSTLOGIN
	HAVING DATEDIFF(MINUTE,L.FIRSTLOGIN, MIN(T.TR_InDate)) > 5
	ORDER BY L.[DATE] DESC

GO
/****** Object:  StoredProcedure [dbo].[Dboard_ExceedProductivity150]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Dboard_ExceedProductivity150] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime

AS

SELECT TR_UID AS [UID], TR_InDate [TASKED-IN],ROUND(TR_Productivity,3) AS [PRODUCTIVITY] 
FROM tbl_TaskRecordDetail 
WHERE TR_Apporval = 2  AND TR_PIC = @mPIC AND TR_InDate BETWEEN @mFrom AND @mTo 
GROUP BY TR_UID, TR_InDate, TR_Productivity
HAVING TR_Productivity > 150
ORDER BY TR_InDate DESC

GO
/****** Object:  StoredProcedure [dbo].[Dboard_ExceedProductivity150ByProject]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_ExceedProductivity150ByProject] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime, @mProject nvarchar(30)

AS

SELECT T.TR_UID AS [UID], T.TR_InDate [TASKED-IN],ROUND(T.TR_Productivity,3) AS [PRODUCTIVITY] 
FROM tbl_TaskRecordDetail T
INNER JOIN tbl_PCPDetail P ON T.PCP_ID=P.PCP_ID AND P.Task_ID=T.Task_ID
WHERE T.TR_Apporval = 2  AND T.TR_PIC = @mPIC AND T.TR_InDate BETWEEN @mFrom AND @mTo AND P.PCP_Project=@mProject
GROUP BY T.TR_UID, T.TR_InDate, T.TR_Productivity
HAVING T.TR_Productivity > 150
ORDER BY T.TR_InDate DESC

GO
/****** Object:  StoredProcedure [dbo].[Dboard_ExceedProductivity150ByProjectAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_ExceedProductivity150ByProjectAndManager] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime, @mProject nvarchar(30), @mMUID nvarchar(30)

AS

SELECT T.TR_UID AS [UID], T.TR_InDate [TASKED-IN],ROUND(T.TR_Productivity,3) AS [PRODUCTIVITY] 
FROM tbl_TaskRecordDetail T
INNER JOIN tbl_PCPDetail P ON T.PCP_ID=P.PCP_ID AND P.Task_ID=T.Task_ID
WHERE T.TR_Apporval = 2  AND T.TR_PIC = @mPIC AND T.TR_InDate BETWEEN @mFrom AND @mTo AND P.PCP_Project=@mProject AND T.TR_MID=@mMUID
GROUP BY T.TR_UID, T.TR_InDate, T.TR_Productivity
HAVING T.TR_Productivity > 150
ORDER BY T.TR_InDate DESC

GO
/****** Object:  StoredProcedure [dbo].[Dboard_ExceedProductivity150PICAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_ExceedProductivity150PICAndManager] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime, @mMID nvarchar(30)

AS

	SELECT TR_UID AS [UID], TR_InDate [TASKED-IN],ROUND(TR_Productivity,3) AS [PRODUCTIVITY] 
	FROM tbl_TaskRecordDetail 
	WHERE TR_Apporval = 2  AND TR_PIC = @mPIC AND TR_InDate BETWEEN @mFrom AND @mTo AND TR_MID=@mMID
	GROUP BY TR_UID, TR_InDate, TR_Productivity
	HAVING TR_Productivity > 150
	ORDER BY TR_InDate DESC

GO
/****** Object:  StoredProcedure [dbo].[Dboard_ExceedProductivity150PICAndUID]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_ExceedProductivity150PICAndUID] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime, @mUID nvarchar(30)
 
AS

	SELECT TR_UID AS [UID], TR_InDate [TASKED-IN],ROUND(TR_Productivity,3) AS [PRODUCTIVITY] 
	FROM tbl_TaskRecordDetail 
	WHERE TR_Apporval = 2  AND TR_PIC = @mPIC AND TR_InDate BETWEEN @mFrom AND @mTo AND TR_UID=@mUID
	GROUP BY TR_UID, TR_InDate, TR_Productivity
	HAVING TR_Productivity > 150
	ORDER BY TR_InDate DESC

GO
/****** Object:  StoredProcedure [dbo].[Dboard_ExceedProductivity150PICAndUIDAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_ExceedProductivity150PICAndUIDAndManager] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime, @mUID nvarchar(30),  @mMUID nvarchar(30)
 
AS

	SELECT TR_UID AS [UID], TR_InDate [TASKED-IN],ROUND(TR_Productivity,3) AS [PRODUCTIVITY] 
	FROM tbl_TaskRecordDetail 
	WHERE TR_Apporval = 2  AND TR_PIC = @mPIC AND TR_InDate BETWEEN @mFrom AND @mTo AND TR_UID=@mUID AND TR_MID=@mMUID
	GROUP BY TR_UID, TR_InDate, TR_Productivity
	HAVING TR_Productivity > 150
	ORDER BY TR_InDate DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_IDLEAndWastageViewRecordsByUID]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_IDLEAndWastageViewRecordsByUID] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime, @mUID nvarchar(30)

AS

SELECT CONVERT(date,T.WORKDATE) AS [WORKDATE],T.[MID] AS [TEAM], T.[UID] AS [UID],T.[FIRST_LOGIN] AS [LOGIN],T.[LAST_LOGOUT] AS [LOGOUT],T.[FIRST_TASKED-IN] AS [FIRST TASKED-IN],T.[LAST_TASKED-OUT] AS [LAST TASKED-OUT], ROUND(CAST(T.[FIRST_TASKED-IN] - T.[FIRST_LOGIN] AS float)*24,2) AS [WASTE BEFORE FIRST TITO], ROUND(CAST(T.[LAST_LOGOUT]-T.[LAST_TASKED-OUT] AS float)*24,2) AS [WASTE AFTER LAST TITO], ROUND(T.[WASTE],2) AS [TOTAL WASTE], ROUND((T.[APPROVED_IDLE]),2) AS [APPROVED IDLE]
FROM tbl_Report_TempIDLEAndWastage T
WHERE T.PIC=@mPIC AND T.WORKDATE BETWEEN @mFrom AND @mTo AND T.[UID]=@mUID
GROUP BY  T.WORKDATE,T.[MID], T.[UID],T.[FIRST_TASKED-IN],T.[FIRST_LOGIN],T.[LAST_LOGOUT],T.[LAST_TASKED-OUT],T.[WASTE],T.[APPROVED_IDLE]

GO
/****** Object:  StoredProcedure [dbo].[Dboard_PTRdetails]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_PTRdetails] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime

AS



/*Tasks*/
SELECT *
FROM (
SELECT  TOP (999999999999999999) [TR_UID] AS [User ID]
	  ,UH.P_Name AS [Employee Name]
	  ,NULL AS [Resource ID]
	  ,NULL AS [Res ID]
	  ,NULL AS [P Type]
	  ,NULL AS [DEPT]
	 ,CONVERT(Date, TR.[TR_ActualTaskIn]) AS [Date]
	  ,usr.P_Project AS [Project]
	  ,NULL AS [New Assigned Project]
	  ,TD.Task_Description AS [Activity Task Code]
      ,ROUND(ISNULL(CAST(TR.TR_OutDate - TR.TR_ActualTaskIn AS float),0)*24,2) AS [Hours]
	  ,NULL AS [New Task Code]
	  ,NULL AS [New Task Description]
	  ,NULL AS [CLUSTER]
  FROM [CITITO].[dbo].[tbl_TaskRecordDetail] TR
  INNER JOIN [tbl_PCPDetail] PCP ON PCP.PCP_ID=TR.PCP_ID AND TR.Task_ID=PCP.Task_ID
  INNER JOIN [tbl_UserManagementHeader] UH ON UH.P_UID=TR.TR_UID
  INNER JOIN tbl_UserManagementDetail usr ON usr.P_UID=TR.TR_UID AND usr.P_Project_Availability='Active' AND PCP.PCP_Project=usr.P_Project
  INNER JOIN [tbl_TaskDetail] TD ON TD.Task_ID=PCP.Task_ID AND TD.PIC_Project=PCP.PCP_Project AND TD.PC_ProcessCode=PCP.PC_ProcessCode
  WHERE usr.PIC_UID=@mPIC AND CONVERT(Date, TR.[TR_ActualTaskIn]) BETWEEN @mFrom AND @mTo AND TR.TR_TaskStatus!=1
  ORDER BY TR.TR_UID, CONVERT(Date, TR.[TR_ActualTaskIn])
  ) TASKS
  
  UNION ALL

  /*IDLE*/
  SELECT * 
  FROM (
  SELECT  TOP (999999999999999999) IDL.IDLE_UID AS [User ID]
	  ,UH.P_Name AS [Employee Name]
	  ,NULL AS [Resource ID]
	  ,NULL AS [Res ID]
	  ,NULL AS [P Type]
	  ,NULL AS [DEPT]
	 ,CONVERT(Date, IDL.[IDLE_InDate]) AS [Date]
	  ,usr.P_Project AS [Project]
	  ,NULL AS [New Assigned Project]
	  ,CONCAT('[IDLE] ', IDL.[IDLE_Reason]) AS [Activity Task Code]
      ,ROUND(ISNULL(IDL.IDLE_Hours,0),2) AS [Hours]
	  ,NULL AS [New Task Code]
	  ,NULL AS [New Task Description]
	  ,NULL AS [CLUSTER]
  FROM [tbl_IDLEDetail] IDL 
  INNER JOIN tbl_IDLEHeader IDLH  ON IDLH.IDLE_ID=IDL.IDLE_ID
  INNER JOIN [tbl_UserManagementHeader] UH ON UH.P_UID=IDL.IDLE_UID
  INNER JOIN tbl_UserManagementDetail usr ON usr.P_UID=IDL.IDLE_UID AND usr.P_Project_Availability='Active' AND IDLH.IDLE_Project=usr.P_Project
  WHERE usr.PIC_UID=@mPIC AND CONVERT(Date, IDL.[IDLE_InDate]) BETWEEN @mFrom AND @mTo AND IDL.IDLE_Apporval=2
  ) IDLE

 UNION ALL

 /*WASTE*/
  SELECT * 
  FROM (
   SELECT  TOP (999999999999999999) WTE.[UID] AS [User ID]
	  ,UH.P_Name AS [Employee Name]
	  ,NULL AS [Resource ID]
	  ,NULL AS [Res ID]
	  ,NULL AS [P Type]
	  ,NULL AS [DEPT]
	  ,WTE.[WORKDATE] AS [Date]
	  ,MAX(usr.P_Project) AS [Project]
	  ,NULL AS [New Assigned Project]
	  ,'[WASTE]' AS [Activity Task Code]
      ,ROUND(ISNULL(WTE.[WASTE],0),2) AS [Hours]
	  ,NULL AS [New Task Code]
	  ,NULL AS [New Task Description]
	  ,NULL AS [CLUSTER]
  FROM [tbl_Report_TempIDLEAndWastage] WTE 
  INNER JOIN [tbl_UserManagementHeader] UH ON UH.P_UID=WTE.[UID]
  INNER JOIN tbl_UserManagementDetail usr ON usr.P_UID=WTE.[UID] AND usr.P_Project_Availability='Active'
  WHERE usr.PIC_UID=@mPIC AND WTE.[WORKDATE] BETWEEN @mFrom AND @mTo
  GROUP BY WTE.[UID], UH.P_Name, WTE.[WORKDATE],WTE.[WASTE]

  )Waste

ORDER BY [User ID], [Date]

--///////////////////////////////////////

--SELECT *
--FROM (
--SELECT  TOP (999999999999999999) [TR_UID] AS [User ID]
--	  ,UH.P_Name AS [Employee Name]
--	  ,NULL AS [Resource ID]
--	  ,NULL AS [Res ID]
--	  ,NULL AS [P Type]
--	  ,NULL AS [DEPT]
--	 ,CONVERT(Date, TR.[TR_ActualTaskIn]) AS [Date]
--	  ,usr.P_Project AS [Project]
--	  ,NULL AS [New Assigned Project]
--	  ,TD.Task_Description AS [Activity Task Code]
--      ,ROUND(ISNULL(CAST(TR.TR_OutDate - TR.TR_ActualTaskIn AS float),0)*24,2) AS [Hours]
--	  ,NULL AS [New Task Code]
--	  ,NULL AS [New Task Description]
--	  ,NULL AS [CLUSTER]
--  FROM [CITITO].[dbo].[tbl_TaskRecordDetail] TR
--  INNER JOIN [tbl_PCPDetail] PCP ON PCP.PCP_ID=TR.PCP_ID AND TR.Task_ID=PCP.Task_ID
--  INNER JOIN [tbl_UserManagementHeader] UH ON UH.P_UID=TR.TR_UID
--  INNER JOIN tbl_UserManagementDetail usr ON usr.P_UID=TR.TR_UID AND usr.P_Project_Availability='Active' AND PCP.PCP_Project=usr.P_Project
--  INNER JOIN [tbl_TaskDetail] TD ON TD.Task_ID=PCP.Task_ID AND TD.PIC_Project=PCP.PCP_Project AND TD.PC_ProcessCode=PCP.PC_ProcessCode
--  WHERE usr.PIC_UID=@mPIC AND CONVERT(Date, TR.[TR_ActualTaskIn]) BETWEEN @mFrom AND @mTo AND TR.TR_TaskStatus!=1
--  ORDER BY TR.TR_UID, CONVERT(Date, TR.[TR_ActualTaskIn])
--  ) TASKS
  
--  UNION ALL
--  SELECT * 
--  FROM (
--  SELECT  TOP (999999999999999999) IDL.IDLE_UID AS [User ID]
--	  ,UH.P_Name AS [Employee Name]
--	  ,NULL AS [Resource ID]
--	  ,NULL AS [Res ID]
--	  ,NULL AS [P Type]
--	  ,NULL AS [DEPT]
--	 ,CONVERT(Date, IDL.[IDLE_InDate]) AS [Date]
--	  ,usr.P_Project AS [Project]
--	  ,NULL AS [New Assigned Project]
--	  ,CONCAT('[IDLE] ', IDL.[IDLE_Reason]) AS [Activity Task Code]
--      ,ROUND(ISNULL(IDL.IDLE_Hours,0),2) AS [Hours]
--	  ,NULL AS [New Task Code]
--	  ,NULL AS [New Task Description]
--	  ,NULL AS [CLUSTER]
--  FROM [tbl_IDLEDetail] IDL 
--  INNER JOIN tbl_IDLEHeader IDLH  ON IDLH.IDLE_ID=IDL.IDLE_ID
--  INNER JOIN [tbl_UserManagementHeader] UH ON UH.P_UID=IDL.IDLE_UID
--  INNER JOIN tbl_UserManagementDetail usr ON usr.P_UID=IDL.IDLE_UID AND usr.P_Project_Availability='Active' AND IDLH.IDLE_Project=usr.P_Project
--  WHERE usr.PIC_UID=@mPIC AND CONVERT(Date, IDL.[IDLE_InDate]) BETWEEN @mFrom AND @mTo AND IDL.IDLE_Apporval=2
--  ) IDLE

--  ORDER BY [User ID], [Date]

--////////////////////////////////////////////
--SELECT [TR_UID] AS [User ID]
--	  ,UH.P_Name AS [Employee Name]
--	  ,NULL AS [Resource ID]
--	  ,NULL AS [Res ID]
--	  ,NULL AS [P Type]
--	  ,NULL AS [DEPT]
--	 ,CONVERT(Date, TR.[TR_ActualTaskIn]) AS [Date]
--	  ,usr.P_Project AS [Project]
--	  ,NULL AS [New Assigned Project]
--	  ,TD.Task_Description AS [Activity Task Code]
--      ,ROUND(ISNULL(CAST(TR.TR_OutDate - TR.TR_ActualTaskIn AS float),0)*24,2) AS [Hours]
--	  ,NULL AS [New Task Code]
--	  ,NULL AS [New Task Description]
--	  ,NULL AS [CLUSTER]
--  FROM [CITITO].[dbo].[tbl_TaskRecordDetail] TR
--  INNER JOIN [tbl_PCPDetail] PCP ON PCP.PCP_ID=TR.PCP_ID AND TR.Task_ID=PCP.Task_ID
--  INNER JOIN [tbl_UserManagementHeader] UH ON UH.P_UID=TR.TR_UID
--  INNER JOIN tbl_UserManagementDetail usr ON usr.P_UID=TR.TR_UID AND usr.P_Project_Availability='Active' AND PCP.PCP_Project=usr.P_Project
--  INNER JOIN [tbl_TaskDetail] TD ON TD.Task_ID=PCP.Task_ID AND TD.PIC_Project=PCP.PCP_Project AND TD.PC_ProcessCode=PCP.PC_ProcessCode
--  WHERE usr.PIC_UID=@mPIC AND CONVERT(Date, TR.[TR_ActualTaskIn]) BETWEEN @mFrom AND @mTo AND TR.TR_TaskStatus!=1
--  ORDER BY TR.TR_UID, CONVERT(Date, TR.[TR_ActualTaskIn])

--///////////////////////////////////////////
--SELECT [TR_UID] AS [User ID]
--	  ,UH.P_Name AS [Employee Name]
--	  ,NULL AS [Resource ID]
--	  ,NULL AS [Res ID]
--	  ,NULL AS [P Type]
--	  ,NULL AS [DEPT]
--	 ,CONVERT(Date, TR.[TR_ActualTaskIn]) AS [Date]
--	  ,PCP.[PCP_Project] AS [Project]
--	  ,NULL AS [New Assigned Project]
--	  ,TD.Task_Description AS [Activity Task Code]
--      ,ROUND(ISNULL(CAST(TR.TR_OutDate - TR.TR_ActualTaskIn AS float),0)*24,2) AS [Hours]
--	  ,NULL AS [New Task Code]
--	  ,NULL AS [New Task Description]
--	  ,NULL AS [CLUSTER]
--  FROM [CITITO].[dbo].[tbl_TaskRecordDetail] TR
--  INNER JOIN [tbl_PCPDetail] PCP ON PCP.PCP_ID=TR.PCP_ID AND TR.Task_ID=PCP.Task_ID
--  INNER JOIN [tbl_UserManagementHeader] UH ON UH.P_UID=TR.TR_UID
--  INNER JOIN [tbl_TaskDetail] TD ON TD.Task_ID=PCP.Task_ID AND TD.PIC_Project=PCP.PCP_Project AND TD.PC_ProcessCode=PCP.PC_ProcessCode
--  WHERE TR.TR_PIC=@mPIC AND CONVERT(Date, TR.[TR_ActualTaskIn]) BETWEEN @mFrom AND @mTo AND TR.TR_TaskStatus!=1
--  ORDER BY TR.TR_UID, CONVERT(Date, TR.[TR_ActualTaskIn])

--SELECT QU.[TR_UID] AS [User ID]
--      ,UH.P_Name AS [Employee Name]
--	  ,NULL AS [Resource ID]
--	  ,NULL AS [Res ID]
--	  ,NULL AS [P Type]
--	  ,NULL AS [DEPT]
--      ,QU.[WORKDATE] AS [Date]
--	  ,QU.[PCP_Project] AS [Project]
--	  ,NULL AS [New Assigned Project]
--	  ,TD.Task_Description AS [Activity Task Code]
--	  ,ROUND(QU.[WORKED_HOURS],2) AS [Hours]
--	  ,NULL AS [New Task Code]
--	  ,NULL AS [New Task Description]
--	  ,NULL AS [CLUSTER]
--  FROM [CITITO].[dbo].[tbl_Report_TemptaskDetailsQUOTA_Updated] QU
--  INNER JOIN [tbl_UserManagementHeader] UH ON UH.P_UID=QU.TR_UID
--  INNER JOIN [tbl_TaskDetail] TD ON TD.Task_ID=QU.Task_ID AND TD.PIC_Project=QU.PCP_Project AND TD.PC_ProcessCode=QU.PC_ProcessCode
--  WHERE QU.TR_PIC=@mPIC AND QU.WORKDATE BETWEEN @mFrom AND @mTo
--  ORDER BY QU.TR_UID, QU.WORKDATE

GO
/****** Object:  StoredProcedure [dbo].[Dboard_TaskAndWastageCount]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_TaskAndWastageCount]  @mPIC nvarchar(30)

AS

SELECT COUNT(tskd.Task_ID)
FROM tbl_TaskDetail tskd
INNER JOIN tbl_ProjectDetail prjd ON tskd.PIC_Project=prjd.ProjectName
WHERE prjd.PIC_UID=@mPIC



GO
/****** Object:  StoredProcedure [dbo].[DBoard_TasksAndQuota]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_TasksAndQuota] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime

AS

	SELECT TD.PCP_Project AS [PROJECT], TD.PC_ProcessCode AS [ITEM CODE], TD.Task_ID AS [TASK CODE], TDES.Task_Description AS [DESCRIPTION], TD.TR_UOM AS [UOM], TD.QUOTA AS [QUOTA], COUNT(DISTINCT TD.TR_UID) AS [# OF OPERATORS], ROUND(AVG(TD.X3),2) AS [AVERAGE PRODUCTIVITY], ROUND(MAX(TD.X3),2) AS [HIGHEST PRODUCTIVITY], ROUND(MIN(TD.X3),2) AS [LOWEST PRODUCTIVITY], ROUND(STDEV(TD.X3),2) AS [STANDARD DEVIATION], COUNT(TD.TR_UID) AS [# OF RECORDS]
	FROM [tbl_Report_TemptaskDetailsQUOTA_Updated] TD
	INNER JOIN [tbl_TaskDetail] TDES ON TDES.PIC_Project=TD.PCP_Project AND TDES.PC_ProcessCode=TD.PC_ProcessCode AND TDES.Task_ID=TD.Task_ID
	WHERE TD.TR_PIC=@mPIC AND TD.TR_ActualTaskIn BETWEEN @mFrom AND @mTo
	GROUP BY  TD.PCP_Project, TD.PC_ProcessCode, TD.Task_ID, TDES.Task_Description, TD.TR_UOM, TD.QUOTA

	--SELECT [PROJECT], [PROCESS CODE] AS [ITEM CODE], [TASK] AS [TASK CODE], [DESCRIPTION], [UOM], [QUOTA], COUNT(DISTINCT [UID]) AS [# OF OPERATORS], ROUND(AVG([PRODUCTIVITY]),2) AS [AVERAGE PRODUCTIVITY], ROUND(MAX([PRODUCTIVITY]),2) AS [HIGHEST PRODUCTIVITY], ROUND(MIN([PRODUCTIVITY]),2) AS [LOWEST PRODUCTIVITY], ROUND(STDEV([PRODUCTIVITY]),2) AS [STANDARD DEVIATION], COUNT([UID]) AS [# OF RECORDS]
	--FROM (
	--	SELECT tsrd.TR_Index AS [INDEX], tsrd.TR_UID AS [UID], pcpd.PCP_ID AS [JOB CODE], prjd.ProjectName [PROJECT], tskd.Task_ID AS [TASK], tskd.Task_Description AS [DESCRIPTION], tskd.Task_UOM AS [UOM], tskd.Task_Quota AS [QUOTA], tskd.PC_ProcessCode AS [PROCESS CODE], tsrd.TR_Productivity AS [PRODUCTIVITY]
	--	FROM tbl_TaskDetail tskd
	--	INNER JOIN tbl_ProjectDetail prjd ON tskd.PIC_Project=prjd.ProjectName
	--	INNER JOIN tbl_PCPDetail pcpd ON pcpd.PC_ProcessCode=tskd.PC_ProcessCode AND tskd.Task_ID=pcpd.Task_ID
	--	INNER JOIN tbl_TaskRecordDetail tsrd ON pcpd.Task_ID=tsrd.Task_ID AND pcpd.PCP_ID=tsrd.PCP_ID
	--	WHERE prjd.PIC_UID=@mPIC AND tsrd.TR_InDate BETWEEN @mFrom AND @mTo AND tsrd.TR_Apporval=2
	--) GroupDetails
	--GROUP BY [PROJECT], [PROCESS CODE], [TASK], [DESCRIPTION], [UOM], [QUOTA]
GO
/****** Object:  StoredProcedure [dbo].[DBoard_TasksAndQuota_FilterByItemCode]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_TasksAndQuota_FilterByItemCode] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime, @mItemCode nvarchar(50)

AS

SELECT TD.PCP_Project AS [PROJECT], TD.PC_ProcessCode AS [ITEM CODE], TD.Task_ID AS [TASK CODE], TDES.Task_Description AS [DESCRIPTION], TD.TR_UOM AS [UOM], TD.QUOTA AS [QUOTA], COUNT(DISTINCT TD.TR_UID) AS [# OF OPERATORS], ROUND(AVG(TD.X3),2) AS [AVERAGE PRODUCTIVITY], ROUND(MAX(TD.X3),2) AS [HIGHEST PRODUCTIVITY], ROUND(MIN(TD.X3),2) AS [LOWEST PRODUCTIVITY], ROUND(STDEV(TD.X3),2) AS [STANDARD DEVIATION], COUNT(TD.TR_UID) AS [# OF RECORDS]
	FROM [tbl_Report_TemptaskDetailsQUOTA_Updated] TD
	INNER JOIN [tbl_TaskDetail] TDES ON TDES.PIC_Project=TD.PCP_Project AND TDES.PC_ProcessCode=TD.PC_ProcessCode AND TDES.Task_ID=TD.Task_ID
	WHERE TD.TR_PIC=@mPIC AND TD.TR_ActualTaskIn BETWEEN @mFrom AND @mTo AND TD.PC_ProcessCode=@mItemCode
	GROUP BY  TD.PCP_Project, TD.PC_ProcessCode, TD.Task_ID, TDES.Task_Description, TD.TR_UOM, TD.QUOTA

	--SELECT [PROJECT], [PROCESS CODE] AS [ITEM CODE], [TASK] AS [TASK CODE], [DESCRIPTION], [UOM], [QUOTA], COUNT(DISTINCT [UID]) AS [# OF OPERATORS], ROUND(AVG([PRODUCTIVITY]),2) AS [AVERAGE PRODUCTIVITY], ROUND(MAX([PRODUCTIVITY]),2) AS [HIGHEST PRODUCTIVITY], ROUND(MIN([PRODUCTIVITY]),2) AS [LOWEST PRODUCTIVITY], ROUND(STDEV([PRODUCTIVITY]),2) AS [STANDARD DEVIATION], COUNT([UID]) AS [# OF RECORDS]
	--FROM (
	--	SELECT tsrd.TR_Index AS [INDEX], tsrd.TR_UID AS [UID], pcpd.PCP_ID AS [JOB CODE], prjd.ProjectName [PROJECT], tskd.Task_ID AS [TASK], tskd.Task_Description AS [DESCRIPTION], tskd.Task_UOM AS [UOM], tskd.Task_Quota AS [QUOTA], tskd.PC_ProcessCode AS [PROCESS CODE], tsrd.TR_Productivity AS [PRODUCTIVITY]
	--	FROM tbl_TaskDetail tskd
	--	INNER JOIN tbl_ProjectDetail prjd ON tskd.PIC_Project=prjd.ProjectName
	--	INNER JOIN tbl_PCPDetail pcpd ON pcpd.PC_ProcessCode=tskd.PC_ProcessCode AND tskd.Task_ID=pcpd.Task_ID
	--	INNER JOIN tbl_TaskRecordDetail tsrd ON pcpd.Task_ID=tsrd.Task_ID AND pcpd.PCP_ID=tsrd.PCP_ID
	--	WHERE prjd.PIC_UID=@mPIC AND tsrd.TR_InDate BETWEEN @mFrom AND @mTo AND tsrd.TR_Apporval=2 AND tskd.PC_ProcessCode=@mItemCode
	--) GroupDetails
	--GROUP BY [PROJECT], [PROCESS CODE], [TASK], [DESCRIPTION], [UOM], [QUOTA]

GO
/****** Object:  StoredProcedure [dbo].[DBoard_TasksAndQuota_FilterByProject]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_TasksAndQuota_FilterByProject] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime, @mProject nvarchar(50)

AS

SELECT TD.PCP_Project AS [PROJECT], TD.PC_ProcessCode AS [ITEM CODE], TD.Task_ID AS [TASK CODE], TDES.Task_Description AS [DESCRIPTION], TD.TR_UOM AS [UOM], TD.QUOTA AS [QUOTA], COUNT(DISTINCT TD.TR_UID) AS [# OF OPERATORS], ROUND(AVG(TD.X3),2) AS [AVERAGE PRODUCTIVITY], ROUND(MAX(TD.X3),2) AS [HIGHEST PRODUCTIVITY], ROUND(MIN(TD.X3),2) AS [LOWEST PRODUCTIVITY], ROUND(STDEV(TD.X3),2) AS [STANDARD DEVIATION], COUNT(TD.TR_UID) AS [# OF RECORDS]
	FROM [tbl_Report_TemptaskDetailsQUOTA_Updated] TD
	INNER JOIN [tbl_TaskDetail] TDES ON TDES.PIC_Project=TD.PCP_Project AND TDES.PC_ProcessCode=TD.PC_ProcessCode AND TDES.Task_ID=TD.Task_ID
	WHERE TD.TR_PIC=@mPIC AND TD.TR_ActualTaskIn BETWEEN @mFrom AND @mTo AND TD.PCP_Project=@mProject
	GROUP BY  TD.PCP_Project, TD.PC_ProcessCode, TD.Task_ID, TDES.Task_Description, TD.TR_UOM, TD.QUOTA

	--SELECT [PROJECT], [PROCESS CODE] AS [ITEM CODE], [TASK] AS [TASK CODE], [DESCRIPTION], [UOM], [QUOTA], COUNT(DISTINCT [UID]) AS [# OF OPERATORS], ROUND(AVG([PRODUCTIVITY]),2) AS [AVERAGE PRODUCTIVITY], ROUND(MAX([PRODUCTIVITY]),2) AS [HIGHEST PRODUCTIVITY], ROUND(MIN([PRODUCTIVITY]),2) AS [LOWEST PRODUCTIVITY], ROUND(STDEV([PRODUCTIVITY]),2) AS [STANDARD DEVIATION], COUNT([UID]) AS [# OF RECORDS]
	--FROM (
	--	SELECT tsrd.TR_Index AS [INDEX], tsrd.TR_UID AS [UID], pcpd.PCP_ID AS [JOB CODE], prjd.ProjectName [PROJECT], tskd.Task_ID AS [TASK], tskd.Task_Description AS [DESCRIPTION], tskd.Task_UOM AS [UOM], tskd.Task_Quota AS [QUOTA], tskd.PC_ProcessCode AS [PROCESS CODE], tsrd.TR_Productivity AS [PRODUCTIVITY]
	--	FROM tbl_TaskDetail tskd
	--	INNER JOIN tbl_ProjectDetail prjd ON tskd.PIC_Project=prjd.ProjectName
	--	INNER JOIN tbl_PCPDetail pcpd ON pcpd.PC_ProcessCode=tskd.PC_ProcessCode AND tskd.Task_ID=pcpd.Task_ID
	--	INNER JOIN tbl_TaskRecordDetail tsrd ON pcpd.Task_ID=tsrd.Task_ID AND pcpd.PCP_ID=tsrd.PCP_ID
	--	WHERE prjd.PIC_UID=@mPIC AND tsrd.TR_InDate BETWEEN @mFrom AND @mTo AND tsrd.TR_Apporval=2 AND tskd.PIC_Project=@mProject
	--) GroupDetails
	--GROUP BY [PROJECT], [PROCESS CODE], [TASK], [DESCRIPTION], [UOM], [QUOTA]

GO
/****** Object:  StoredProcedure [dbo].[DBoard_TasksAndQuota_FilterByTaskCode]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_TasksAndQuota_FilterByTaskCode] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime, @mTaskCode nvarchar(50)

AS

SELECT TD.PCP_Project AS [PROJECT], TD.PC_ProcessCode AS [ITEM CODE], TD.Task_ID AS [TASK CODE], TDES.Task_Description AS [DESCRIPTION], TD.TR_UOM AS [UOM], TD.QUOTA AS [QUOTA], COUNT(DISTINCT TD.TR_UID) AS [# OF OPERATORS], ROUND(AVG(TD.X3),2) AS [AVERAGE PRODUCTIVITY], ROUND(MAX(TD.X3),2) AS [HIGHEST PRODUCTIVITY], ROUND(MIN(TD.X3),2) AS [LOWEST PRODUCTIVITY], ROUND(STDEV(TD.X3),2) AS [STANDARD DEVIATION], COUNT(TD.TR_UID) AS [# OF RECORDS]
	FROM [tbl_Report_TemptaskDetailsQUOTA_Updated] TD
	INNER JOIN [tbl_TaskDetail] TDES ON TDES.PIC_Project=TD.PCP_Project AND TDES.PC_ProcessCode=TD.PC_ProcessCode AND TDES.Task_ID=TD.Task_ID
	WHERE TD.TR_PIC=@mPIC AND TD.TR_ActualTaskIn BETWEEN @mFrom AND @mTo AND TD.Task_ID=@mTaskCode
	GROUP BY  TD.PCP_Project, TD.PC_ProcessCode, TD.Task_ID, TDES.Task_Description, TD.TR_UOM, TD.QUOTA

	--SELECT [PROJECT], [PROCESS CODE] AS [ITEM CODE], [TASK] AS [TASK CODE], [DESCRIPTION], [UOM], [QUOTA], COUNT(DISTINCT [UID]) AS [# OF OPERATORS], ROUND(AVG([PRODUCTIVITY]),2) AS [AVERAGE PRODUCTIVITY], ROUND(MAX([PRODUCTIVITY]),2) AS [HIGHEST PRODUCTIVITY], ROUND(MIN([PRODUCTIVITY]),2) AS [LOWEST PRODUCTIVITY], ROUND(STDEV([PRODUCTIVITY]),2) AS [STANDARD DEVIATION], COUNT([UID]) AS [# OF RECORDS]
	--FROM (
	--	SELECT tsrd.TR_Index AS [INDEX], tsrd.TR_UID AS [UID], pcpd.PCP_ID AS [JOB CODE], prjd.ProjectName [PROJECT], tskd.Task_ID AS [TASK], tskd.Task_Description AS [DESCRIPTION], tskd.Task_UOM AS [UOM], tskd.Task_Quota AS [QUOTA], tskd.PC_ProcessCode AS [PROCESS CODE], tsrd.TR_Productivity AS [PRODUCTIVITY]
	--	FROM tbl_TaskDetail tskd
	--	INNER JOIN tbl_ProjectDetail prjd ON tskd.PIC_Project=prjd.ProjectName
	--	INNER JOIN tbl_PCPDetail pcpd ON pcpd.PC_ProcessCode=tskd.PC_ProcessCode AND tskd.Task_ID=pcpd.Task_ID
	--	INNER JOIN tbl_TaskRecordDetail tsrd ON pcpd.Task_ID=tsrd.Task_ID AND pcpd.PCP_ID=tsrd.PCP_ID
	--	WHERE prjd.PIC_UID=@mPIC AND tsrd.TR_InDate BETWEEN @mFrom AND @mTo AND tsrd.TR_Apporval=2 AND tskd.Task_ID=@mTaskCode
	--) GroupDetails
	--GROUP BY [PROJECT], [PROCESS CODE], [TASK], [DESCRIPTION], [UOM], [QUOTA]

GO
/****** Object:  StoredProcedure [dbo].[DBoard_TasksAndQuotaByViewRecords]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_TasksAndQuotaByViewRecords] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime, @mProject nvarchar(30), @mProcessCode nvarchar(30), @mTaskCode nvarchar(30), @mTaskDesc nvarchar(30)

AS

	SELECT CONVERT(date,TD.TR_ActualTaskIn) AS [WORKDATE], TD.TR_UID AS [UID], TD.PC_ProcessCode AS [PROCESS CODE], TD.PCP_Project [PROJECT], TD.Task_ID AS [TASK], TDES.Task_Description AS [DESCRIPTION], TD.TR_UOM AS [UOM], TD.QUOTA AS [QUOTA], ROUND(TD.X3,2) AS [PRODUCTIVITY]
	FROM [tbl_Report_TemptaskDetailsQUOTA_Updated] TD
	INNER JOIN [tbl_TaskDetail] TDES ON TDES.PIC_Project=TD.PCP_Project AND TDES.PC_ProcessCode=TD.PC_ProcessCode AND TDES.Task_ID=TD.Task_ID
	WHERE TD.TR_PIC=@mPIC AND TD.TR_ActualTaskIn BETWEEN @mFrom AND @mTo AND TD.PCP_Project=@mProject AND TD.PC_ProcessCode=@mProcessCode AND TD.Task_ID=@mTaskCode AND TDES.Task_Description=@mTaskDesc

	--SELECT CONVERT(date,tsrd.TR_ActualTaskIn) AS [WORKDATE], tsrd.TR_UID AS [UID], tskd.PC_ProcessCode AS [PROCESS CODE], prjd.ProjectName [PROJECT], tskd.Task_ID AS [TASK], tskd.Task_Description AS [DESCRIPTION], tskd.Task_UOM AS [UOM], tskd.Task_Quota AS [QUOTA], ROUND(tsrd.TR_Productivity,2) AS [PRODUCTIVITY]
	--FROM tbl_TaskDetail tskd
	--INNER JOIN tbl_ProjectDetail prjd ON tskd.PIC_Project=prjd.ProjectName
	--INNER JOIN tbl_PCPDetail pcpd ON pcpd.PC_ProcessCode=tskd.PC_ProcessCode AND tskd.Task_ID=pcpd.Task_ID
	--INNER JOIN tbl_TaskRecordDetail tsrd ON pcpd.Task_ID=tsrd.Task_ID AND pcpd.PCP_ID=tsrd.PCP_ID
	--WHERE prjd.PIC_UID=@mPIC AND tsrd.TR_InDate BETWEEN @mFrom AND @mTo AND tsrd.TR_Apporval=2 AND prjd.ProjectName=@mProject AND tskd.PC_ProcessCode=@mProcessCode AND tskd.Task_ID=@mTaskCode AND tskd.Task_Description=@mTaskDesc
	--ORDER BY tskd.Task_Description

GO
/****** Object:  StoredProcedure [dbo].[Dboard_UserWastage_ByPIC]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_UserWastage_ByPIC] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime

AS

--SELECT T.[MID] AS [TEAM], T.[UID] AS [UID],SUM(ROUND(AMSDIFF,2)) AS [TOTAL AMS HOURS],SUM(ROUND(TASKDIFF,2)) AS [TOTAL TITO HOURS],(ROUND((SUM(ROUND(TASKDIFF,2))/SUM(ROUND(AMSDIFF,2))),2)*100) AS [CAPACITY UTILIZATION], SUM(ROUND(CAST(T.[FIRST_TASKED-IN] - T.[FIRST_LOGIN] AS float)*24,2)) AS [TOTAL WASTE BEFORE FIRST TITO], SUM(ROUND(CAST(T.[LAST_LOGOUT]-T.[LAST_TASKED-OUT] AS float)*24,2)) AS [TOTAL WASTE AFTER LAST TITO], ROUND(SUM(T.[WASTE])/COUNT(T.[UID]),2) AS [AVERAGE WASTE PER DAY], ROUND(SUM(T.[APPROVED_IDLE])/COUNT(T.[UID]),2) AS [AVERAGE APPROVED IDLE PER DAY]
SELECT T.[MID] AS [TEAM], T.[UID] AS [UID],SUM(ROUND(AMSDIFF,2)) AS [TOTAL AMS HOURS],SUM(ROUND(TASKDIFF,2)) AS [TOTAL TITO HOURS],SUM(ROUND([WASTE],2)) AS [TOTAL WASTE HOURS],SUM(ROUND([APPROVED_IDLE],2)) AS [TOTAL IDLE HOURS], (ROUND((SUM(ROUND(TASKDIFF,2))/SUM(ROUND(AMSDIFF,2))),2)*100) AS [CAPACITY UTILIZATION], SUM(ROUND(CAST(T.[FIRST_TASKED-IN] - T.[FIRST_LOGIN] AS float)*24,2)) AS [TOTAL WASTE HOURS BEFORE FIRST TITO], SUM(ROUND(CAST(T.[LAST_LOGOUT]-T.[LAST_TASKED-OUT] AS float)*24,2)) AS [TOTAL WASTE HOURS AFTER LAST TITO], ROUND(SUM(T.[WASTE])/COUNT(T.[UID]),2) AS [AVERAGE WASTE HOURS PER DAY], ROUND(SUM(T.[APPROVED_IDLE])/COUNT(T.[UID]),2) AS [AVERAGE APPROVED IDLE HOURS PER DAY]
FROM tbl_Report_TempIDLEAndWastage T
WHERE T.PIC=@mPIC AND T.WORKDATE BETWEEN @mFrom AND @mTo
GROUP BY  T.[MID], T.[UID]

--SELECT T.[MID] AS [TEAM], T.[UID] AS [UID], SUM(ROUND(CAST(T.[FIRST_TASKED-IN] - T.[FIRST_LOGIN] AS float)*24,2)) AS [TOTAL WASTE BEFORE FIRST TITO], SUM(ROUND(CAST(T.[LAST_LOGOUT]-T.[LAST_TASKED-OUT] AS float)*24,2)) AS [TOTAL WASTE AFTER LAST TITO], ROUND(SUM(T.[WASTE])/COUNT(T.[UID]),2) AS [AVERAGE WASTE PER DAY], ROUND(SUM(T.[APPROVED_IDLE])/COUNT(T.[UID]),2) AS [AVERAGE APPROVED IDLE PER DAY]
--FROM tbl_Report_TempIDLEAndWastage T
--WHERE T.PIC=@mPIC AND T.WORKDATE BETWEEN @mFrom AND @mTo
--GROUP BY  T.[MID], T.[UID]


--DECLARE @TempAMSDIFF_@mPIC TABLE(

--[UID] nvarchar(50), 
--[WORKDATE] DateTime,
--[FLOGIN] DateTime,
--[LLOGOUT] DateTime,
--[DIFFIN] Time,
--[SHIFT] Time,
--[DIFFOUT] Time
--); 

--INSERT INTO @TempAMSDIFF_@mPIC
--SELECT T.TR_UID AS [UID], convert(date,L.[DATE]) AS [DATE],L.FIRSTLOGIN, L.LASTLOGOUT, CONVERT(TIME,MIN(T.TR_InDate) - L.FIRSTLOGIN) AS [DIFFIN], CONVERT(TIME, (L.LASTLOGOUT - L.FIRSTLOGIN) - ((MIN(T.TR_InDate) - L.FIRSTLOGIN) + (L.LASTLOGOUT - MAX(T.TR_OutDate)))) AS [SHIFT], CONVERT(TIME, L.LASTLOGOUT - MAX(T.TR_OutDate)) AS [DIFFOUT]
--	FROM tbl_TaskRecordDetail T
--	INNER JOIN tbl_UserLILO L ON T.TR_UID=L.[UID] AND L.[DATE]=convert(date, T.TR_InDate)
--	WHERE T.TR_PIC=@mPIC AND T.TR_InDate BETWEEN @mFrom AND @mTo
--	GROUP BY  T.TR_UID, L.[DATE], L.FIRSTLOGIN, L.LASTLOGOUT
--	HAVING (CAST(ROUND(DATEDIFF(MINUTE,L.LASTLOGOUT, MAX(T.TR_OutDate))/60.0, 3)AS decimal (6,3))) NOT IN (0)
--	ORDER BY L.[DATE] DESC

--SELECT [UID], CAST(CAST(SUM(( DATEPART(hh, [DIFFIN]) * 3600 ) + ( DATEPART(mi, [DIFFIN]) * 60 ) + DATEPART(ss, [DIFFIN])) AS float)/3600 AS decimal(6,3)) AS [TOTAL WASTE BEFORE FIRST TITO], CAST(CAST(SUM(( DATEPART(hh, [DIFFOUT]) * 3600 ) + ( DATEPART(mi, [DIFFOUT]) * 60 ) + DATEPART(ss, [DIFFOUT])) AS float)/3600 AS decimal(6,3)) AS [TOTAL WASTE AFTER LAST TITO], ROUND(CAST(((CAST(CAST(SUM(( DATEPART(hh, [DIFFIN]) * 3600 ) + ( DATEPART(mi, [DIFFIN]) * 60 ) + DATEPART(ss, [DIFFIN])) AS float)/3600 AS decimal(6,3))) + (CAST(CAST(SUM(( DATEPART(hh, [DIFFOUT]) * 3600 ) + ( DATEPART(mi, [DIFFOUT]) * 60 ) + DATEPART(ss, [DIFFOUT])) AS float)/3600 AS decimal(6,3))))/COUNT(WORKDATE)As float),3) AS [AVERAGE WASTE PER DAY]
--FROM @TempAMSDIFF_@mPIC
--GROUP BY [UID]

GO
/****** Object:  StoredProcedure [dbo].[Dboard_UserWastage_ByPIC_FilterByMID]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_UserWastage_ByPIC_FilterByMID] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime, @mMUID nvarchar(30)

AS

--SELECT T.[MID] AS [TEAM], T.[UID] AS [UID],SUM(ROUND(AMSDIFF,2)) AS [TOTAL AMS HOURS],SUM(ROUND(TASKDIFF,2)) AS [TOTAL TITO HOURS],(ROUND((SUM(ROUND(TASKDIFF,2))/SUM(ROUND(AMSDIFF,2))),2)*100) AS [CAPACITY UTILIZATION], SUM(ROUND(CAST(T.[FIRST_TASKED-IN] - T.[FIRST_LOGIN] AS float)*24,2)) AS [TOTAL WASTE BEFORE FIRST TITO], SUM(ROUND(CAST(T.[LAST_LOGOUT]-T.[LAST_TASKED-OUT] AS float)*24,2)) AS [TOTAL WASTE AFTER LAST TITO], ROUND(SUM(T.[WASTE])/COUNT(T.[UID]),2) AS [AVERAGE WASTE PER DAY], ROUND(SUM(T.[APPROVED_IDLE])/COUNT(T.[UID]),2) AS [AVERAGE APPROVED IDLE PER DAY]
SELECT T.[MID] AS [TEAM], T.[UID] AS [UID],SUM(ROUND(AMSDIFF,2)) AS [TOTAL AMS HOURS],SUM(ROUND(TASKDIFF,2)) AS [TOTAL TITO HOURS],SUM(ROUND([WASTE],2)) AS [TOTAL WASTE HOURS],SUM(ROUND([APPROVED_IDLE],2)) AS [TOTAL IDLE HOURS], (ROUND((SUM(ROUND(TASKDIFF,2))/SUM(ROUND(AMSDIFF,2))),2)*100) AS [CAPACITY UTILIZATION], SUM(ROUND(CAST(T.[FIRST_TASKED-IN] - T.[FIRST_LOGIN] AS float)*24,2)) AS [TOTAL WASTE HOURS BEFORE FIRST TITO], SUM(ROUND(CAST(T.[LAST_LOGOUT]-T.[LAST_TASKED-OUT] AS float)*24,2)) AS [TOTAL WASTE HOURS AFTER LAST TITO], ROUND(SUM(T.[WASTE])/COUNT(T.[UID]),2) AS [AVERAGE WASTE HOURS PER DAY], ROUND(SUM(T.[APPROVED_IDLE])/COUNT(T.[UID]),2) AS [AVERAGE APPROVED IDLE HOURS PER DAY]
FROM tbl_Report_TempIDLEAndWastage T
WHERE T.PIC=@mPIC AND T.WORKDATE BETWEEN @mFrom AND @mTo AND T.[MID]=@mMUID
GROUP BY  T.[MID], T.[UID]


--SELECT T.[MID] AS [TEAM], T.[UID] AS [UID], SUM(ROUND(CAST(T.[FIRST_TASKED-IN] - T.[FIRST_LOGIN] AS float)*24,2)) AS [TOTAL WASTE BEFORE FIRST TITO], SUM(ROUND(CAST(T.[LAST_LOGOUT]-T.[LAST_TASKED-OUT] AS float)*24,2)) AS [TOTAL WASTE AFTER LAST TITO], ROUND(SUM(T.[WASTE])/COUNT(T.[UID]),2) AS [AVERAGE WASTE PER DAY], ROUND(SUM(T.[APPROVED_IDLE])/COUNT(T.[UID]),2) AS [AVERAGE APPROVED IDLE PER DAY]
--FROM tbl_Report_TempIDLEAndWastage T
--WHERE T.PIC=@mPIC AND T.WORKDATE BETWEEN @mFrom AND @mTo AND T.[MID]=@mMUID
--GROUP BY  T.[MID], T.[UID]

GO
/****** Object:  StoredProcedure [dbo].[Dboard_UserWastage_ByPIC_FilterByUser]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_UserWastage_ByPIC_FilterByUser] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime, @mUID nvarchar(30)

AS


--SELECT T.[MID] AS [TEAM], T.[UID] AS [UID],SUM(ROUND(AMSDIFF,2)) AS [TOTAL AMS HOURS],SUM(ROUND(TASKDIFF,2)) AS [TOTAL TITO HOURS],(ROUND((SUM(ROUND(TASKDIFF,2))/SUM(ROUND(AMSDIFF,2))),2)*100) AS [CAPACITY UTILIZATION], SUM(ROUND(CAST(T.[FIRST_TASKED-IN] - T.[FIRST_LOGIN] AS float)*24,2)) AS [TOTAL WASTE BEFORE FIRST TITO], SUM(ROUND(CAST(T.[LAST_LOGOUT]-T.[LAST_TASKED-OUT] AS float)*24,2)) AS [TOTAL WASTE AFTER LAST TITO], ROUND(SUM(T.[WASTE])/COUNT(T.[UID]),2) AS [AVERAGE WASTE PER DAY], ROUND(SUM(T.[APPROVED_IDLE])/COUNT(T.[UID]),2) AS [AVERAGE APPROVED IDLE PER DAY]
SELECT T.[MID] AS [TEAM], T.[UID] AS [UID],SUM(ROUND(AMSDIFF,2)) AS [TOTAL AMS HOURS],SUM(ROUND(TASKDIFF,2)) AS [TOTAL TITO HOURS],SUM(ROUND([WASTE],2)) AS [TOTAL WASTE HOURS],SUM(ROUND([APPROVED_IDLE],2)) AS [TOTAL IDLE HOURS], (ROUND((SUM(ROUND(TASKDIFF,2))/SUM(ROUND(AMSDIFF,2))),2)*100) AS [CAPACITY UTILIZATION], SUM(ROUND(CAST(T.[FIRST_TASKED-IN] - T.[FIRST_LOGIN] AS float)*24,2)) AS [TOTAL WASTE HOURS BEFORE FIRST TITO], SUM(ROUND(CAST(T.[LAST_LOGOUT]-T.[LAST_TASKED-OUT] AS float)*24,2)) AS [TOTAL WASTE HOURS AFTER LAST TITO], ROUND(SUM(T.[WASTE])/COUNT(T.[UID]),2) AS [AVERAGE WASTE HOURS PER DAY], ROUND(SUM(T.[APPROVED_IDLE])/COUNT(T.[UID]),2) AS [AVERAGE APPROVED IDLE HOURS PER DAY]
FROM tbl_Report_TempIDLEAndWastage T
WHERE T.PIC=@mPIC AND T.WORKDATE BETWEEN @mFrom AND @mTo AND T.[UID]=@mUID
GROUP BY  T.[MID], T.[UID]

--SELECT T.[MID] AS [TEAM], T.[UID] AS [UID], SUM(ROUND(CAST(T.[FIRST_TASKED-IN] - T.[FIRST_LOGIN] AS float)*24,2)) AS [TOTAL WASTE BEFORE FIRST TITO], SUM(ROUND(CAST(T.[LAST_LOGOUT]-T.[LAST_TASKED-OUT] AS float)*24,2)) AS [TOTAL WASTE AFTER LAST TITO], ROUND(SUM(T.[WASTE])/COUNT(T.[UID]),2) AS [AVERAGE WASTE PER DAY], ROUND(SUM(T.[APPROVED_IDLE])/COUNT(T.[UID]),2) AS [AVERAGE APPROVED IDLE PER DAY]
--FROM tbl_Report_TempIDLEAndWastage T
--WHERE T.PIC=@mPIC AND T.WORKDATE BETWEEN @mFrom AND @mTo AND T.[UID]=@mUID
--GROUP BY  T.[MID], T.[UID]

--DECLARE @TempAMSDIFF_@mPIC TABLE(

--[UID] nvarchar(50), 
--[WORKDATE] DateTime,
--[FLOGIN] DateTime,
--[LLOGOUT] DateTime,
--[DIFFIN] Time,
--[SHIFT] Time,
--[DIFFOUT] Time
--); 

--INSERT INTO @TempAMSDIFF_@mPIC
--SELECT T.TR_UID AS [UID], convert(date,L.[DATE]) AS [DATE],L.FIRSTLOGIN, L.LASTLOGOUT, CONVERT(TIME,MIN(T.TR_InDate) - L.FIRSTLOGIN) AS [DIFFIN], CONVERT(TIME, (L.LASTLOGOUT - L.FIRSTLOGIN) - ((MIN(T.TR_InDate) - L.FIRSTLOGIN) + (L.LASTLOGOUT - MAX(T.TR_OutDate)))) AS [SHIFT], CONVERT(TIME, L.LASTLOGOUT - MAX(T.TR_OutDate)) AS [DIFFOUT]
--	FROM tbl_TaskRecordDetail T
--	INNER JOIN tbl_UserLILO L ON T.TR_UID=L.[UID] AND L.[DATE]=convert(date, T.TR_InDate)
--	WHERE T.TR_PIC=@mPIC AND T.TR_InDate BETWEEN @mFrom AND @mTo
--	GROUP BY  T.TR_UID, L.[DATE], L.FIRSTLOGIN, L.LASTLOGOUT
--	HAVING (CAST(ROUND(DATEDIFF(MINUTE,L.LASTLOGOUT, MAX(T.TR_OutDate))/60.0, 3)AS decimal (6,3))) NOT IN (0)
--	ORDER BY L.[DATE] DESC

--SELECT [UID], CAST(CAST(SUM(( DATEPART(hh, [DIFFIN]) * 3600 ) + ( DATEPART(mi, [DIFFIN]) * 60 ) + DATEPART(ss, [DIFFIN])) AS float)/3600 AS decimal(6,3)) AS [TOTAL WASTE BEFORE FIRST TITO], CAST(CAST(SUM(( DATEPART(hh, [DIFFOUT]) * 3600 ) + ( DATEPART(mi, [DIFFOUT]) * 60 ) + DATEPART(ss, [DIFFOUT])) AS float)/3600 AS decimal(6,3)) AS [TOTAL WASTE AFTER LAST TITO], ROUND(CAST(((CAST(CAST(SUM(( DATEPART(hh, [DIFFIN]) * 3600 ) + ( DATEPART(mi, [DIFFIN]) * 60 ) + DATEPART(ss, [DIFFIN])) AS float)/3600 AS decimal(6,3))) + (CAST(CAST(SUM(( DATEPART(hh, [DIFFOUT]) * 3600 ) + ( DATEPART(mi, [DIFFOUT]) * 60 ) + DATEPART(ss, [DIFFOUT])) AS float)/3600 AS decimal(6,3))))/COUNT(WORKDATE)AS float),2) AS [AVERAGE WASTE PER DAY]
--FROM @TempAMSDIFF_@mPIC
--WHERE [UID]=@mUID
--GROUP BY [UID]

GO
/****** Object:  StoredProcedure [dbo].[Dboard_UserWastage_ByPIC_FilterByUserAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_UserWastage_ByPIC_FilterByUserAndManager] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime, @mUID nvarchar(30), @mMUID nvarchar(30)

AS


--SELECT T.[MID] AS [TEAM], T.[UID] AS [UID],SUM(ROUND(AMSDIFF,2)) AS [TOTAL AMS HOURS],SUM(ROUND(TASKDIFF,2)) AS [TOTAL TITO HOURS],(ROUND((SUM(ROUND(TASKDIFF,2))/SUM(ROUND(AMSDIFF,2))),2)*100) AS [CAPACITY UTILIZATION], SUM(ROUND(CAST(T.[FIRST_TASKED-IN] - T.[FIRST_LOGIN] AS float)*24,2)) AS [TOTAL WASTE BEFORE FIRST TITO], SUM(ROUND(CAST(T.[LAST_LOGOUT]-T.[LAST_TASKED-OUT] AS float)*24,2)) AS [TOTAL WASTE AFTER LAST TITO], ROUND(SUM(T.[WASTE])/COUNT(T.[UID]),2) AS [AVERAGE WASTE PER DAY], ROUND(SUM(T.[APPROVED_IDLE])/COUNT(T.[UID]),2) AS [AVERAGE APPROVED IDLE PER DAY]
SELECT T.[MID] AS [TEAM], T.[UID] AS [UID],SUM(ROUND(AMSDIFF,2)) AS [TOTAL AMS HOURS],SUM(ROUND(TASKDIFF,2)) AS [TOTAL TITO HOURS],SUM(ROUND([WASTE],2)) AS [TOTAL WASTE HOURS],SUM(ROUND([APPROVED_IDLE],2)) AS [TOTAL IDLE HOURS], (ROUND((SUM(ROUND(TASKDIFF,2))/SUM(ROUND(AMSDIFF,2))),2)*100) AS [CAPACITY UTILIZATION], SUM(ROUND(CAST(T.[FIRST_TASKED-IN] - T.[FIRST_LOGIN] AS float)*24,2)) AS [TOTAL WASTE HOURS BEFORE FIRST TITO], SUM(ROUND(CAST(T.[LAST_LOGOUT]-T.[LAST_TASKED-OUT] AS float)*24,2)) AS [TOTAL WASTE HOURS AFTER LAST TITO], ROUND(SUM(T.[WASTE])/COUNT(T.[UID]),2) AS [AVERAGE WASTE HOURS PER DAY], ROUND(SUM(T.[APPROVED_IDLE])/COUNT(T.[UID]),2) AS [AVERAGE APPROVED IDLE HOURS PER DAY]
FROM tbl_Report_TempIDLEAndWastage T
WHERE T.PIC=@mPIC AND T.WORKDATE BETWEEN @mFrom AND @mTo AND T.[UID]=@mUID AND T.MID=@mMUID
GROUP BY  T.[MID], T.[UID]

GO
/****** Object:  StoredProcedure [dbo].[Dboard_UserWastage_CountByPIC]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_UserWastage_CountByPIC] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime

AS

SELECT T.[MID] AS [TEAM]
FROM tbl_Report_TempIDLEAndWastage T
WHERE T.PIC=@mPIC AND T.WORKDATE BETWEEN @mFrom AND @mTo
GROUP BY  T.[MID], T.[UID]

--DECLARE @TempAMSDIFF_@mPIC TABLE(

--[UID] nvarchar(50), 
--[WORKDATE] DateTime,
--[FLOGIN] DateTime,
--[LLOGOUT] DateTime,
--[DIFFIN] Time,
--[SHIFT] Time,
--[DIFFOUT] Time
--); 

--INSERT INTO @TempAMSDIFF_@mPIC
--SELECT T.TR_UID AS [UID], convert(date,L.[DATE]) AS [DATE],L.FIRSTLOGIN, L.LASTLOGOUT, CONVERT(TIME,MIN(T.TR_InDate) - L.FIRSTLOGIN) AS [DIFFIN], CONVERT(TIME, (L.LASTLOGOUT - L.FIRSTLOGIN) - ((MIN(T.TR_InDate) - L.FIRSTLOGIN) + (L.LASTLOGOUT - MAX(T.TR_OutDate)))) AS [SHIFT], CONVERT(TIME, L.LASTLOGOUT - MAX(T.TR_OutDate)) AS [DIFFOUT]
--	FROM tbl_TaskRecordDetail T
--	INNER JOIN tbl_UserLILO L ON T.TR_UID=L.[UID] AND L.[DATE]=convert(date, T.TR_InDate)
--	WHERE T.TR_PIC=@mPIC AND T.TR_InDate BETWEEN @mFrom AND @mTo
--	GROUP BY  T.TR_UID, L.[DATE], L.FIRSTLOGIN, L.LASTLOGOUT
--	HAVING (CAST(ROUND(DATEDIFF(MINUTE,L.LASTLOGOUT, MAX(T.TR_OutDate))/60.0, 3)AS decimal (6,3))) NOT IN (0)
--	ORDER BY L.[DATE] DESC

--SELECT COUNT([WORKDATE])
--FROM @TempAMSDIFF_@mPIC
GO
/****** Object:  StoredProcedure [dbo].[Dboard_WasteByDateGraph]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WasteByDateGraph] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime

AS

DECLARE @TempAMSDIFF_@mPIC TABLE(

[UID] nvarchar(50), 
[WORKDATE] DateTime,
[FLOGIN] DateTime,
[LLOGOUT] DateTime,
[DIFFIN] Time,
[SHIFT] Time,
[DIFFOUT] Time
); 

INSERT INTO @TempAMSDIFF_@mPIC
SELECT T.TR_UID AS [UID], convert(date,L.[DATE]) AS [DATE],L.FIRSTLOGIN, L.LASTLOGOUT, CONVERT(TIME,MIN(T.TR_ActualTaskIn) - L.FIRSTLOGIN) AS [DIFFIN], CONVERT(TIME, (L.LASTLOGOUT - L.FIRSTLOGIN) - ((MIN(T.TR_ActualTaskIn) - L.FIRSTLOGIN) + (L.LASTLOGOUT - MAX(T.TR_OutDate)))) AS [SHIFT], CONVERT(TIME, L.LASTLOGOUT - MAX(T.TR_OutDate)) AS [DIFFOUT]
	FROM tbl_TaskRecordDetail T
	INNER JOIN tbl_UserLILO L ON T.TR_UID=L.[UID] AND L.[DATE]=convert(date, T.TR_ActualTaskIn)
	INNER JOIN tbl_UserManagementDetail usr ON usr.P_UID=T.TR_UID AND usr.P_Project_Availability='Active'
	WHERE usr.PIC_UID=@mPIC AND T.TR_ActualTaskIn BETWEEN @mFrom AND @mTo
	GROUP BY  T.TR_UID, L.[DATE], L.FIRSTLOGIN, L.LASTLOGOUT
	HAVING (CONVERT(TIME, (L.LASTLOGOUT - L.FIRSTLOGIN) - ((MIN(T.TR_ActualTaskIn) - L.FIRSTLOGIN) + (L.LASTLOGOUT - MAX(T.TR_OutDate))))) IS NOT NULL AND CONVERT(TIME, L.LASTLOGOUT - MAX(T.TR_OutDate)) IS NOT NULL
	ORDER BY L.[DATE] DESC

--INSERT INTO @TempAMSDIFF_@mPIC
----Set Actual Task In
--SELECT T.TR_UID AS [UID], convert(date,L.[DATE]) AS [DATE],L.FIRSTLOGIN, L.LASTLOGOUT, CONVERT(TIME,MIN(T.TR_ActualTaskIn) - L.FIRSTLOGIN) AS [DIFFIN], CONVERT(TIME, (L.LASTLOGOUT - L.FIRSTLOGIN) - ((MIN(T.TR_ActualTaskIn) - L.FIRSTLOGIN) + (L.LASTLOGOUT - MAX(T.TR_OutDate)))) AS [SHIFT], CONVERT(TIME, L.LASTLOGOUT - MAX(T.TR_OutDate)) AS [DIFFOUT]
--	FROM tbl_TaskRecordDetail T
--	INNER JOIN tbl_UserLILO L ON T.TR_UID=L.[UID] AND L.[DATE]=convert(date, T.TR_ActualTaskIn)
--	WHERE T.TR_PIC=@mPIC AND T.TR_ActualTaskIn BETWEEN @mFrom AND @mTo
--	GROUP BY  T.TR_UID, L.[DATE], L.FIRSTLOGIN, L.LASTLOGOUT
--	HAVING (CONVERT(TIME, (L.LASTLOGOUT - L.FIRSTLOGIN) - ((MIN(T.TR_ActualTaskIn) - L.FIRSTLOGIN) + (L.LASTLOGOUT - MAX(T.TR_OutDate))))) IS NOT NULL AND CONVERT(TIME, L.LASTLOGOUT - MAX(T.TR_OutDate)) IS NOT NULL
--	ORDER BY L.[DATE] DESC



--SELECT T.TR_UID AS [UID], convert(date,L.[DATE]) AS [DATE],L.FIRSTLOGIN, L.LASTLOGOUT, CONVERT(TIME,MIN(T.TR_InDate) - L.FIRSTLOGIN) AS [DIFFIN], CONVERT(TIME, (L.LASTLOGOUT - L.FIRSTLOGIN) - ((MIN(T.TR_InDate) - L.FIRSTLOGIN) + (L.LASTLOGOUT - MAX(T.TR_OutDate)))) AS [SHIFT], CONVERT(TIME, L.LASTLOGOUT - MAX(T.TR_OutDate)) AS [DIFFOUT]
--	FROM tbl_TaskRecordDetail T
--	INNER JOIN tbl_UserLILO L ON T.TR_UID=L.[UID] AND L.[DATE]=convert(date, T.TR_InDate)
--	WHERE T.TR_PIC=@mPIC AND T.TR_InDate BETWEEN @mFrom AND @mTo
--	GROUP BY  T.TR_UID, L.[DATE], L.FIRSTLOGIN, L.LASTLOGOUT
--	HAVING (CAST(ROUND(DATEDIFF(MINUTE,L.LASTLOGOUT, MAX(T.TR_OutDate))/60.0, 3)AS decimal (6,3))) NOT IN (0)
--	ORDER BY L.[DATE] DESC

--SELECT convert(date, WORKDATE) AS [WORKDATE], CAST(CAST(SUM(( DATEPART(hh, [DIFFIN]) * 3600 ) + ( DATEPART(mi, [DIFFIN]) * 60 ) + DATEPART(ss, [DIFFIN])) AS float)/3600 AS decimal(6,3)) AS [MORNING WASTE], CAST(CAST(SUM(( DATEPART(hh, [SHIFT]) * 3600 ) + ( DATEPART(mi, [SHIFT]) * 60 ) + DATEPART(ss, [SHIFT])) AS float)/3600 AS decimal(6,3)) AS [PRODUCTIVE HOURS], CAST(CAST(SUM(( DATEPART(hh, [DIFFOUT]) * 3600 ) + ( DATEPART(mi, [DIFFOUT]) * 60 ) + DATEPART(ss, [DIFFOUT])) AS float)/3600 AS decimal(6,3)) AS [AFTERNOON WASTE]
SELECT convert(date, WORKDATE) AS [WORKDATE], CAST(CAST(SUM(( DATEPART(hh, [DIFFIN]) * 3600 ) + ( DATEPART(mi, [DIFFIN]) * 60 ) + DATEPART(ss, [DIFFIN])) AS float)/3600 AS decimal(6,3)) AS [MORNING WASTE], CAST(CAST(SUM(( DATEPART(hh, [SHIFT]) * 3600 ) + ( DATEPART(mi, [SHIFT]) * 60 ) + DATEPART(ss, [SHIFT])) AS float)/3600 AS decimal(6,3)) AS [PRODUCTIVE HOURS], ROUND(CAST(CAST(SUM(( DATEPART(hh, [DIFFOUT]) * 3600 ) + ( DATEPART(mi, [DIFFOUT]) * 60 ) + DATEPART(ss, [DIFFOUT])) AS float)/3600 AS float),3) AS [AFTERNOON WASTE]
FROM @TempAMSDIFF_@mPIC
GROUP BY WORKDATE

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WasteByDateGraphByMID]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WasteByDateGraphByMID] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime, @mMUID nvarchar(30)

AS

DECLARE @TempAMSDIFF_@mPIC TABLE(

[UID] nvarchar(50), 
[WORKDATE] DateTime,
[FLOGIN] DateTime,
[LLOGOUT] DateTime,
[DIFFIN] Time,
[SHIFT] Time,
[DIFFOUT] Time
); 

INSERT INTO @TempAMSDIFF_@mPIC
SELECT T.TR_UID AS [UID], convert(date,L.[DATE]) AS [DATE],L.FIRSTLOGIN, L.LASTLOGOUT, CONVERT(TIME,MIN(T.TR_ActualTaskIn) - L.FIRSTLOGIN) AS [DIFFIN], CONVERT(TIME, (L.LASTLOGOUT - L.FIRSTLOGIN) - ((MIN(T.TR_ActualTaskIn) - L.FIRSTLOGIN) + (L.LASTLOGOUT - MAX(T.TR_OutDate)))) AS [SHIFT], CONVERT(TIME, L.LASTLOGOUT - MAX(T.TR_OutDate)) AS [DIFFOUT]
	FROM tbl_TaskRecordDetail T
	INNER JOIN tbl_UserLILO L ON T.TR_UID=L.[UID] AND L.[DATE]=convert(date, T.TR_ActualTaskIn)
	INNER JOIN tbl_UserManagementDetail usr ON usr.P_UID=T.TR_UID AND usr.P_Project_Availability='Active'
	WHERE usr.PIC_UID=@mPIC AND T.TR_ActualTaskIn BETWEEN @mFrom AND @mTo AND usr.M_UID=@mMUID
	GROUP BY  T.TR_UID, L.[DATE], L.FIRSTLOGIN, L.LASTLOGOUT
	HAVING (CONVERT(TIME, (L.LASTLOGOUT - L.FIRSTLOGIN) - ((MIN(T.TR_ActualTaskIn) - L.FIRSTLOGIN) + (L.LASTLOGOUT - MAX(T.TR_OutDate))))) IS NOT NULL AND CONVERT(TIME, L.LASTLOGOUT - MAX(T.TR_OutDate)) IS NOT NULL
	ORDER BY L.[DATE] DESC


--SELECT convert(date, WORKDATE) AS [WORKDATE], CAST(CAST(SUM(( DATEPART(hh, [DIFFIN]) * 3600 ) + ( DATEPART(mi, [DIFFIN]) * 60 ) + DATEPART(ss, [DIFFIN])) AS float)/3600 AS decimal(6,3)) AS [MORNING WASTE], CAST(CAST(SUM(( DATEPART(hh, [SHIFT]) * 3600 ) + ( DATEPART(mi, [SHIFT]) * 60 ) + DATEPART(ss, [SHIFT])) AS float)/3600 AS decimal(6,3)) AS [PRODUCTIVE HOURS], CAST(CAST(SUM(( DATEPART(hh, [DIFFOUT]) * 3600 ) + ( DATEPART(mi, [DIFFOUT]) * 60 ) + DATEPART(ss, [DIFFOUT])) AS float)/3600 AS decimal(6,3)) AS [AFTERNOON WASTE]
SELECT convert(date, WORKDATE) AS [WORKDATE], CAST(CAST(SUM(( DATEPART(hh, [DIFFIN]) * 3600 ) + ( DATEPART(mi, [DIFFIN]) * 60 ) + DATEPART(ss, [DIFFIN])) AS float)/3600 AS decimal(6,3)) AS [MORNING WASTE], CAST(CAST(SUM(( DATEPART(hh, [SHIFT]) * 3600 ) + ( DATEPART(mi, [SHIFT]) * 60 ) + DATEPART(ss, [SHIFT])) AS float)/3600 AS decimal(6,3)) AS [PRODUCTIVE HOURS], ROUND(CAST(CAST(SUM(( DATEPART(hh, [DIFFOUT]) * 3600 ) + ( DATEPART(mi, [DIFFOUT]) * 60 ) + DATEPART(ss, [DIFFOUT])) AS float)/3600 AS float),3) AS [AFTERNOON WASTE]
FROM @TempAMSDIFF_@mPIC
GROUP BY WORKDATE

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Dboard_WorkLoad] @mPIC nvarchar(30) 

AS


SELECT   
  tblPivot.Property, tblPivot.Value 
FROM   
(	
	SELECT 
		SUM(CASE WHEN [STATUS]='In-Process' THEN 1 ELSE 0 END) AS  [IN-PROCESS],
		SUM(CASE WHEN [STATUS]='Fresh' THEN 1 ELSE 0 END) AS  [FRESH],
		SUM(CASE WHEN [STATUS]='Hold' THEN 1 ELSE 0 END) AS  [HOLD]
	FROM(
		SELECT PROJECT, [JOB CODE], [FILE NAME],
		CASE WHEN ([IN-PROCESS COUNT]>=1 AND [HOLD COUNT]=0) THEN ('In-Process') ELSE (CASE WHEN ([HOLD COUNT]>=1 AND [IN-PROCESS COUNT]=0) THEN ('Hold') ELSE (CASE WHEN ([TASK COUNT]=[DONE COUNT]) THEN ('Done') ELSE (CASE WHEN ([DONE COUNT] != 0 AND [TASK COUNT]=([DONE COUNT]+[FRESH COUNT])) THEN ('In-Process') ELSE (CASE WHEN ([TASK COUNT]=[FRESH COUNT]) THEN ('Fresh') END) END) END) END) END AS  [STATUS]
		FROM(
			SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], pd.PCP_File AS [FILE NAME], COUNT(pd.PCP_Status) AS [TASK COUNT], 
			(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=0 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [FRESH COUNT],
			(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=2 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [IN-PROCESS COUNT],
			(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=3 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [DONE COUNT],
			(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=1 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [HOLD COUNT]
			FROM tbl_PCPDetail pd
			INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
			WHERE pch.PIC_UID=@mPIC
			GROUP BY pd.PCP_Project, pd.PCP_ID, pd.PCP_File
		) WLResource
	) WorkLoadGraph
) Person
UNPIVOT (Value For Property In (/*[DONE], */[IN-PROCESS], [FRESH],[HOLD])) as tblPivot
ORDER BY tblPivot.Value DESC


--SELECT   
--  tblPivot.Property, tblPivot.Value 
--FROM   
--(	SELECT 
--	--SUM(CASE WHEN pd.PCP_Status=3 THEN 1 ELSE 0 END) AS  [DONE],
--	SUM(CASE WHEN pd.PCP_Status=2 THEN 1 ELSE 0 END) AS  [IN-PROCESS],
--	SUM(CASE WHEN pd.PCP_Status=0 THEN 1 ELSE 0 END) AS  [FRESH],
--	SUM(CASE WHEN pd.PCP_Status=1 THEN 1 ELSE 0 END) AS  [HOLD]
--	FROM tbl_PCPDetail pd
--	INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
--	WHERE pch.PIC_UID=@mPIC 
--) Person
--  UNPIVOT (Value For Property In (/*[DONE], */[IN-PROCESS], [FRESH],[HOLD])) as tblPivot
--ORDER BY tblPivot.Value DESC



--DECLARE @WorkLoad TABLE(
--    InProcess varchar(50),
--    IDLE varchar(50),
--	Hold varchar(50)
--);
--DECLARE @WorkLoadFinal TABLE(
--    TDetail varchar(50),
--    Tcount varchar(50)
--);



----//PCP_Status        int             Unchecked /* 0-Fresh, 1-Hold, 2-Pending, 3-Done */

--/*Fresh Titles*/
--INSERT INTO @WorkLoad (InProcess)

--SELECT PCP_ID AS [In-Process]
--FROM
--	(
--	SELECT PCP_ID
--	FROM tbl_PCPDetail pd
--	INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
--	WHERE PCP_Status=0 AND pch.PIC_UID=@mPIC
--	GROUP BY PCP_ID
--	) FreshTitles

--/*Pending Titles*/
--INSERT INTO @WorkLoad (IDLE)
--SELECT PCP_ID AS [IDLE]
--FROM
--	(
--	SELECT PCP_ID
--	FROM tbl_PCPDetail pd
--	INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
--	WHERE PCP_Status=2 AND pch.PIC_UID=@mPIC
--	GROUP BY PCP_ID
--	) PendingTitles


--/*On Hold Titles*/
--INSERT INTO @WorkLoad (Hold)
--SELECT PCP_ID AS [Hold]
--FROM
--	(
--	SELECT PCP_ID
--	FROM tbl_PCPDetail pd
--	INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
--	WHERE PCP_Status=1 AND pch.PIC_UID=@mPIC
--	GROUP BY PCP_ID
--	) HoldTitles

--INSERT INTO @WorkLoadFinal (TDetail, Tcount)
--SELECT 'IN-PROCESS', COUNT(InProcess)
--FROM @WorkLoad
--WHERE InProcess!='NULL'

--INSERT INTO @WorkLoadFinal (TDetail, Tcount)
--SELECT 'IDLE', COUNT(IDLE)
--FROM @WorkLoad
--WHERE IDLE!='NULL'

--INSERT INTO @WorkLoadFinal (TDetail, Tcount)
--SELECT 'HOLD', COUNT(Hold)
--FROM @WorkLoad
--WHERE Hold!='NULL'

--SELECT *
--FROM @WorkLoadFinal

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_DataSetByCustomeQuery]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_DataSetByCustomeQuery] @mPIC varchar(50), @mWhere varchar(5000)

AS 

DECLARE @mQuery VARCHAR(8000)

SELECT @mQuery ='
SELECT * 
FROM(
	SELECT[CREATED DATE], PROJECT, [JOB CODE], [SHIPMENT], [FILE NAME], [TASK COUNT], [FRESH COUNT] AS[FRESH TASKS], [IN - PROCESS COUNT] AS[IN - PROCESS TASKS], [DONE COUNT] AS[DONE TASKS], [HOLD COUNT] AS[HOLD TASKS],
	    CASE WHEN([IN - PROCESS COUNT] >= 1 AND[HOLD COUNT] = 0) THEN(''In-Process'') ELSE(CASE WHEN([HOLD COUNT] >= 1 AND[IN - PROCESS COUNT] = 0) THEN(''Hold'') ELSE(CASE WHEN([TASK COUNT] =[DONE COUNT]) THEN(''Done'') ELSE(CASE WHEN([DONE COUNT] != 0 AND[TASK COUNT] = ([DONE COUNT] +[FRESH COUNT])) THEN(''In-Process'') ELSE(CASE WHEN([TASK COUNT] =[FRESH COUNT]) THEN(''Fresh'') END) END) END) END) END AS[STATUS]
		    FROM(
			    SELECT MIN(CONVERT(Date, pd.PCP_StartDate)) AS[CREATED DATE], pd.PCP_Project AS[PROJECT], pd.PCP_ID AS[JOB CODE], ph.PCP_Shipment AS[SHIPMENT], pd.PCP_File AS[FILE NAME], COUNT(pd.PCP_Status) AS[TASK COUNT],
					    (SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status = 0 AND  pd.PCP_File = cd.PCP_File AND  pd.PCP_ID = cd.PCP_ID) AS[FRESH COUNT],
						(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status = 2 AND pd.PCP_File = cd.PCP_File AND pd.PCP_ID = cd.PCP_ID) AS[IN - PROCESS COUNT],
						(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status = 3 AND pd.PCP_File = cd.PCP_File AND pd.PCP_ID = cd.PCP_ID) AS[DONE COUNT],
						(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status = 1 AND pd.PCP_File = cd.PCP_File AND pd.PCP_ID = cd.PCP_ID) AS[HOLD COUNT]
						FROM tbl_PCPDetail pd
						INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode = pch.PC_ProcessCode AND pd.PCP_Project = pch.PIC_Project
						INNER JOIN tbl_PCPHeader ph ON pd.PCP_ID = ph.PCP_ID
						WHERE pch.PIC_UID ='''+ @mPIC +'''
						GROUP BY pd.PCP_Project, pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File
				)WLResource				
			) WLDataSet'
+ @mWhere + '
GROUP BY [CREATED DATE], [PROJECT], [JOB CODE], [SHIPMENT], [FILE NAME]
, [TASK COUNT], [FRESH TASKS], [IN - PROCESS TASKS], [DONE TASKS] , [HOLD TASKS],[STATUS]
ORDER BY[CREATED DATE] DESC';

EXEC (@mQuery)

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_DataSetByMID]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_DataSetByMID] @mPIC varchar(50), @mMUID varchar(50)

AS

/*WORKLOAD DATASET*/
SELECT [CREATED DATE], PROJECT, [JOB CODE], [SHIPMENT], [FILE NAME], [TASK COUNT], [FRESH COUNT] AS [FRESH TASKS], [IN-PROCESS COUNT] AS [IN-PROCESS TASKS], [DONE COUNT] AS [DONE TASKS], [HOLD COUNT] AS [HOLD TASKS],
	CASE WHEN ([IN-PROCESS COUNT]>=1 AND [HOLD COUNT]=0) THEN ('In-Process') ELSE (CASE WHEN ([HOLD COUNT]>=1 AND [IN-PROCESS COUNT]=0) THEN ('Hold') ELSE (CASE WHEN ([TASK COUNT]=[DONE COUNT]) THEN ('Done') ELSE (CASE WHEN ([DONE COUNT] != 0 AND [TASK COUNT]=([DONE COUNT]+[FRESH COUNT])) THEN ('In-Process') ELSE (CASE WHEN ([TASK COUNT]=[FRESH COUNT]) THEN ('Fresh') END) END) END) END) END AS  [STATUS]
	FROM(
		SELECT MIN(CONVERT(Date, pd.PCP_StartDate)) AS [CREATED DATE],pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], COUNT(pd.PCP_Status) AS [TASK COUNT], 
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=0 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [FRESH COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=2 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [IN-PROCESS COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=3 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [DONE COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=1 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [HOLD COUNT]
		FROM tbl_PCPDetail pd
		INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
		INNER JOIN tbl_PCPHeader ph ON pd.PCP_ID=ph.PCP_ID
		INNER JOIN tbl_ManagerDetail md ON pd.PCP_Project=md.M_Project AND md.M_Project_Availability='Active'
		WHERE pch.PIC_UID=@mPIC AND md.M_UID=@mMUID
		GROUP BY pd.PCP_Project, pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File
	)WLResource
ORDER BY [CREATED DATE] DESC

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_DataSetByPIC]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_DataSetByPIC] @mPIC varchar(50)

AS

/*WORKLOAD DATASET*/
SELECT [CREATED DATE], PROJECT, [JOB CODE], [SHIPMENT], [FILE NAME], [TASK COUNT], [FRESH COUNT] AS [FRESH TASKS], [IN-PROCESS COUNT] AS [IN-PROCESS TASKS], [DONE COUNT] AS [DONE TASKS], [HOLD COUNT] AS [HOLD TASKS],
	CASE WHEN ([IN-PROCESS COUNT]>=1 AND [HOLD COUNT]=0) THEN ('In-Process') ELSE (CASE WHEN ([HOLD COUNT]>=1 AND [IN-PROCESS COUNT]=0) THEN ('Hold') ELSE (CASE WHEN ([TASK COUNT]=[DONE COUNT]) THEN ('Done') ELSE (CASE WHEN ([DONE COUNT] != 0 AND [TASK COUNT]=([DONE COUNT]+[FRESH COUNT])) THEN ('In-Process') ELSE (CASE WHEN ([TASK COUNT]=[FRESH COUNT]) THEN ('Fresh') END) END) END) END) END AS  [STATUS]
	FROM(
		SELECT MIN(CONVERT(Date, pd.PCP_StartDate)) AS [CREATED DATE],pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], COUNT(pd.PCP_Status) AS [TASK COUNT], 
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=0 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [FRESH COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=2 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [IN-PROCESS COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=3 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [DONE COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=1 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [HOLD COUNT]
		FROM tbl_PCPDetail pd
		INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
		INNER JOIN tbl_PCPHeader ph ON pd.PCP_ID=ph.PCP_ID
		WHERE pch.PIC_UID=@mPIC
		GROUP BY pd.PCP_Project, pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File
	)WLResource
ORDER BY [CREATED DATE] DESC

--SELECT PROJECT, [JOB CODE], [SHIPMENT], [FILE NAME], [TASK COUNT], [FRESH COUNT] AS [FRESH TASKS], [IN-PROCESS COUNT] AS [IN-PROCESS TASKS], [DONE COUNT] AS [DONE TASKS], [HOLD COUNT] AS [HOLD TASKS],
--	CASE WHEN ([IN-PROCESS COUNT]>=1 AND [HOLD COUNT]=0) THEN ('In-Process') ELSE (CASE WHEN ([HOLD COUNT]>=1 AND [IN-PROCESS COUNT]=0) THEN ('Hold') ELSE (CASE WHEN ([TASK COUNT]=[DONE COUNT]) THEN ('Done') ELSE (CASE WHEN [DONE COUNT] != 0 AND ([TASK COUNT]=([DONE COUNT]+[FRESH COUNT])) THEN ('In-Process') ELSE (CASE WHEN ([TASK COUNT]=[FRESH COUNT]) THEN ('Fresh') END) END) END) END) END AS  [STATUS]
--	FROM(
--		SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], COUNT(pd.PCP_Status) AS [TASK COUNT], 
--		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=0 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [FRESH COUNT],
--		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=2 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [IN-PROCESS COUNT],
--		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=3 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [DONE COUNT],
--		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=1 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [HOLD COUNT]
--		FROM tbl_PCPDetail pd
--		INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
--		INNER JOIN tbl_PCPHeader ph ON pd.PCP_ID=ph.PCP_ID
--		WHERE pch.PIC_UID=@mPIC
--		GROUP BY pd.PCP_Project, pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File
--	)WLResource
GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_DataSetByPICAndDate]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_DataSetByPICAndDate] @mPIC varchar(50), @mFrom DateTime, @mTo DateTime

AS

/*WORKLOAD DATASET*/
SELECT [CREATED DATE], PROJECT, [JOB CODE], [SHIPMENT], [FILE NAME], [TASK COUNT], [FRESH COUNT], [IN-PROCESS COUNT], [DONE COUNT], [HOLD COUNT],
	CASE WHEN ([IN-PROCESS COUNT]>=1 AND [HOLD COUNT]=0) THEN ('In-Process') ELSE (CASE WHEN ([HOLD COUNT]>=1 AND [IN-PROCESS COUNT]=0) THEN ('Hold') ELSE (CASE WHEN ([TASK COUNT]=[DONE COUNT]) THEN ('Done') ELSE (CASE WHEN ([DONE COUNT] != 0 AND [TASK COUNT]=([DONE COUNT]+[FRESH COUNT])) THEN ('In-Process') ELSE (CASE WHEN ([TASK COUNT]=[FRESH COUNT]) THEN ('Fresh') END) END) END) END) END AS  [STATUS]
	FROM(
		SELECT MIN(CONVERT(Date, pd.PCP_StartDate)) AS [CREATED DATE],pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], COUNT(pd.PCP_Status) AS [TASK COUNT], 
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=0 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [FRESH COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=2 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [IN-PROCESS COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=3 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [DONE COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=1 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [HOLD COUNT]
		FROM tbl_PCPDetail pd
		INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
		INNER JOIN tbl_PCPHeader ph ON pd.PCP_ID=ph.PCP_ID
		WHERE pch.PIC_UID=@mPIC AND pd.PCP_StartDate BETWEEN @mFrom AND @mTo
		GROUP BY pd.PCP_Project, pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File
	)WLResource
ORDER BY [CREATED DATE] DESC

--SELECT PROJECT, [JOB CODE], [SHIPMENT], [FILE NAME], [TASK COUNT], [FRESH COUNT] AS [FRESH TASKS], [IN-PROCESS COUNT] AS [IN-PROCESS TASKS], [DONE COUNT] AS [DONE TASKS], [HOLD COUNT] AS [HOLD TASKS],
--	CASE WHEN ([IN-PROCESS COUNT]>=1 AND [HOLD COUNT]=0) THEN ('In-Process') ELSE (CASE WHEN ([HOLD COUNT]>=1 AND [IN-PROCESS COUNT]=0) THEN ('Hold') ELSE (CASE WHEN ([TASK COUNT]=[DONE COUNT]) THEN ('Done') ELSE (CASE WHEN [DONE COUNT] != 0 AND ([TASK COUNT]=([DONE COUNT]+[FRESH COUNT])) THEN ('In-Process') ELSE (CASE WHEN ([TASK COUNT]=[FRESH COUNT]) THEN ('Fresh') END) END) END) END) END AS  [STATUS]
--	FROM(
--		SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], COUNT(pd.PCP_Status) AS [TASK COUNT], 
--		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=0 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [FRESH COUNT],
--		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=2 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [IN-PROCESS COUNT],
--		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=3 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [DONE COUNT],
--		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=1 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [HOLD COUNT]
--		FROM tbl_PCPDetail pd
--		INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
--		INNER JOIN tbl_PCPHeader ph ON pd.PCP_ID=ph.PCP_ID
--		WHERE pch.PIC_UID=@mPIC AND pd.PCP_StartDate BETWEEN @mFrom AND @mTo
--		GROUP BY pd.PCP_Project, pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File
--	)WLResource

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_DataSetByPICAndDateAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_DataSetByPICAndDateAndManager] @mPIC varchar(50), @mFrom DateTime, @mTo DateTime, @mMUID varchar(50)

AS


SELECT [CREATED DATE], PROJECT, [JOB CODE], [SHIPMENT], [FILE NAME], [TASK COUNT], [FRESH COUNT] AS [FRESH TASKS], [IN-PROCESS COUNT] AS [IN-PROCESS TASKS], [DONE COUNT] AS [DONE TASKS], [HOLD COUNT] AS [HOLD TASKS],
	CASE WHEN ([IN-PROCESS COUNT]>=1 AND [HOLD COUNT]=0) THEN ('In-Process') ELSE (CASE WHEN ([HOLD COUNT]>=1 AND [IN-PROCESS COUNT]=0) THEN ('Hold') ELSE (CASE WHEN ([TASK COUNT]=[DONE COUNT]) THEN ('Done') ELSE (CASE WHEN ([DONE COUNT] != 0 AND [TASK COUNT]=([DONE COUNT]+[FRESH COUNT])) THEN ('In-Process') ELSE (CASE WHEN ([TASK COUNT]=[FRESH COUNT]) THEN ('Fresh') END) END) END) END) END AS  [STATUS]
	FROM(
		SELECT MIN(CONVERT(Date, pd.PCP_StartDate)) AS [CREATED DATE],pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], COUNT(pd.PCP_Status) AS [TASK COUNT], 
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=0 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [FRESH COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=2 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [IN-PROCESS COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=3 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [DONE COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=1 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [HOLD COUNT]
		FROM tbl_PCPDetail pd
		INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
		INNER JOIN tbl_PCPHeader ph ON pd.PCP_ID=ph.PCP_ID
		INNER JOIN tbl_ManagerDetail md ON pd.PCP_Project=md.M_Project AND md.M_Project_Availability='Active'
		WHERE pch.PIC_UID=@mPIC AND md.M_UID=@mMUID AND pd.PCP_StartDate BETWEEN @mFrom AND @mTo
		GROUP BY pd.PCP_Project, pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File
	)WLResource
ORDER BY [CREATED DATE] DESC
GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_DataSetByPICAndFileName]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_DataSetByPICAndFileName] @mPIC varchar(50), @mFileName varchar(5000)

AS

/*WORKLOAD DATASET*/
SELECT [CREATED DATE], PROJECT, [JOB CODE], [SHIPMENT], [FILE NAME], [TASK COUNT], [FRESH COUNT] AS [FRESH TASKS], [IN-PROCESS COUNT] AS [IN-PROCESS TASKS], [DONE COUNT] AS [DONE TASKS], [HOLD COUNT] AS [HOLD TASKS],
	CASE WHEN ([IN-PROCESS COUNT]>=1 AND [HOLD COUNT]=0) THEN ('In-Process') ELSE (CASE WHEN ([HOLD COUNT]>=1 AND [IN-PROCESS COUNT]=0) THEN ('Hold') ELSE (CASE WHEN ([TASK COUNT]=[DONE COUNT]) THEN ('Done') ELSE (CASE WHEN ([DONE COUNT] != 0 AND [TASK COUNT]=([DONE COUNT]+[FRESH COUNT])) THEN ('In-Process') ELSE (CASE WHEN ([TASK COUNT]=[FRESH COUNT]) THEN ('Fresh') END) END) END) END) END AS  [STATUS]
	FROM(
		SELECT MIN(CONVERT(Date, pd.PCP_StartDate)) AS [CREATED DATE],pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], COUNT(pd.PCP_Status) AS [TASK COUNT], 
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=0 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [FRESH COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=2 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [IN-PROCESS COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=3 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [DONE COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=1 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [HOLD COUNT]
		FROM tbl_PCPDetail pd
		INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
		INNER JOIN tbl_PCPHeader ph ON pd.PCP_ID=ph.PCP_ID
		WHERE pch.PIC_UID=@mPIC AND pd.PCP_File=@mFileName
		GROUP BY pd.PCP_Project, pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File
	)WLResource
ORDER BY [CREATED DATE] DESC

--SELECT PROJECT, [JOB CODE], [SHIPMENT], [FILE NAME], [TASK COUNT], [FRESH COUNT] AS [FRESH TASKS], [IN-PROCESS COUNT] AS [IN-PROCESS TASKS], [DONE COUNT] AS [DONE TASKS], [HOLD COUNT] AS [HOLD TASKS],
--	CASE WHEN ([IN-PROCESS COUNT]>=1 AND [HOLD COUNT]=0) THEN ('In-Process') ELSE (CASE WHEN ([HOLD COUNT]>=1 AND [IN-PROCESS COUNT]=0) THEN ('Hold') ELSE (CASE WHEN ([TASK COUNT]=[DONE COUNT]) THEN ('Done') ELSE (CASE WHEN ([DONE COUNT] != 0 AND [TASK COUNT]=([DONE COUNT]+[FRESH COUNT])) THEN ('In-Process') ELSE (CASE WHEN ([TASK COUNT]=[FRESH COUNT]) THEN ('Fresh') END) END) END) END) END AS  [STATUS]
--	FROM(
--		SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], COUNT(pd.PCP_Status) AS [TASK COUNT], 
--		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=0 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [FRESH COUNT],
--		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=2 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [IN-PROCESS COUNT],
--		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=3 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [DONE COUNT],
--		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=1 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [HOLD COUNT]
--		FROM tbl_PCPDetail pd
--		INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
--		INNER JOIN tbl_PCPHeader ph ON pd.PCP_ID=ph.PCP_ID
--		WHERE pch.PIC_UID=@mPIC AND pd.PCP_File=@mFileName
--		GROUP BY pd.PCP_Project, pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File
--	)WLResource

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_DataSetByPICAndPCPCode]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_DataSetByPICAndPCPCode] @mPIC varchar(50), @mPCPCode varchar(100)

AS


SELECT pd.PCP_Project AS [PROJECT]
, pd.PCP_ID AS [JOB CODE]
, ph.PCP_Shipment AS [SHIPMENT]
, pd.PCP_File AS [FILE NAME]
, pd.PCP_FileSize AS [SIZE]
, pd.Task_UOM AS [UOM]
, pd.Task_Quota AS [QUOTA]
, pd.PC_ProcessCode AS [ITEM CODE]
, pd.Task_ID AS [TASK CODE]
, td.Task_Description AS [DESCRIPTION]
, CASE WHEN (pd.PCP_Status=0) THEN ('Fresh') ELSE (CASE WHEN (pd.PCP_Status=1) THEN ('Hold') ELSE (CASE WHEN (pd.PCP_Status=2) THEN ('In-Process') ELSE (CASE WHEN (pd.PCP_Status=3) THEN ('Done') END) END) END) END AS  [STATUS]
, pd.PCP_StartDate AS [CREATED DATE]
, pd.PCP_EndDate AS [ENDED DATE]
, trd.TR_UID AS [USER ID]
FROM tbl_PCPDetail pd
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_PCPHeader ph ON pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_TaskDetail td ON td.PIC_Project=pd.PCP_Project AND td.PC_ProcessCode=pd.PC_ProcessCode AND td.Task_ID=pd.Task_ID
LEFT OUTER JOIN tbl_TaskRecordDetail trd ON trd.PCP_ID=pd.PCP_ID AND trd.Task_ID=pd.Task_ID 
WHERE pch.PIC_UID=@mPIC AND pd.PCP_ID=@mPCPCode
GROUP BY 
pd.PCP_Project
, pd.PCP_ID
, ph.PCP_Shipment
, pd.PCP_File
, pd.PCP_FileSize
, pd.Task_UOM
, pd.Task_Quota
, pd.PC_ProcessCode
, pd.Task_ID
, td.Task_Description
, pd.PCP_Status
, pd.PCP_StartDate
, pd.PCP_EndDate
, trd.TR_UID


--SELECT pd.PCP_Project AS [PROJECT]
--, pd.PCP_ID AS [JOB CODE]
--, ph.PCP_Shipment AS [SHIPMENT]
--, pd.PCP_File AS [FILE NAME]
--, pd.PCP_FileSize AS [SIZE]
--, pd.Task_UOM AS [UOM]
--, pd.Task_Quota AS [QUOTA]
--, pd.PC_ProcessCode AS [ITEM CODE]
--, pd.Task_ID AS [TASK CODE]
--, td.Task_Description AS [DESCRIPTION]
--, CASE WHEN (pd.PCP_Status=0) THEN ('Fresh') ELSE (CASE WHEN (pd.PCP_Status=1) THEN ('Hold') ELSE (CASE WHEN (pd.PCP_Status=2) THEN ('In-Process') ELSE (CASE WHEN (pd.PCP_Status=3) THEN ('Done') END) END) END) END AS  [STATUS]
--, pd.PCP_StartDate AS [CREATED DATE]
--, pd.PCP_EndDate AS [ENDED DATE]
--, pd.PCP_CreatorUID AS [DCD UID]
--FROM tbl_PCPDetail pd
--INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
--INNER JOIN tbl_PCPHeader ph ON pd.PCP_ID=ph.PCP_ID
--INNER JOIN tbl_TaskDetail td ON td.PIC_Project=pd.PCP_Project AND td.PC_ProcessCode=pd.PC_ProcessCode AND td.Task_ID=pd.Task_ID
--WHERE pch.PIC_UID=@mPIC AND pd.PCP_ID=@mPCPCode

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_DataSetByPICAndProject]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_DataSetByPICAndProject] @mPIC varchar(50), @mProject varchar(150)

AS

/*WORKLOAD DATASET*/
SELECT [CREATED DATE], PROJECT, [JOB CODE], [SHIPMENT], [FILE NAME], [TASK COUNT], [FRESH COUNT] AS [FRESH TASKS], [IN-PROCESS COUNT] AS [IN-PROCESS TASKS], [DONE COUNT] AS [DONE TASKS], [HOLD COUNT] AS [HOLD TASKS],
	CASE WHEN ([IN-PROCESS COUNT]>=1 AND [HOLD COUNT]=0) THEN ('In-Process') ELSE (CASE WHEN ([HOLD COUNT]>=1 AND [IN-PROCESS COUNT]=0) THEN ('Hold') ELSE (CASE WHEN ([TASK COUNT]=[DONE COUNT]) THEN ('Done') ELSE (CASE WHEN ([DONE COUNT] != 0 AND [TASK COUNT]=([DONE COUNT]+[FRESH COUNT])) THEN ('In-Process') ELSE (CASE WHEN ([TASK COUNT]=[FRESH COUNT]) THEN ('Fresh') END) END) END) END) END AS  [STATUS]
	FROM(
		SELECT MIN(CONVERT(Date, pd.PCP_StartDate)) AS [CREATED DATE],pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], COUNT(pd.PCP_Status) AS [TASK COUNT], 
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=0 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [FRESH COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=2 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [IN-PROCESS COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=3 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [DONE COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=1 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [HOLD COUNT]
		FROM tbl_PCPDetail pd
		INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
		INNER JOIN tbl_PCPHeader ph ON pd.PCP_ID=ph.PCP_ID
		WHERE pch.PIC_UID=@mPIC AND pd.PCP_Project=@mProject
		GROUP BY pd.PCP_Project, pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File
	)WLResource
ORDER BY [CREATED DATE] DESC

--SELECT PROJECT, [JOB CODE], [SHIPMENT], [FILE NAME], [TASK COUNT], [FRESH COUNT] AS [FRESH TASKS], [IN-PROCESS COUNT] AS [IN-PROCESS TASKS], [DONE COUNT] AS [DONE TASKS], [HOLD COUNT] AS [HOLD TASKS],
--	CASE WHEN ([IN-PROCESS COUNT]>=1 AND [HOLD COUNT]=0) THEN ('In-Process') ELSE (CASE WHEN ([HOLD COUNT]>=1 AND [IN-PROCESS COUNT]=0) THEN ('Hold') ELSE (CASE WHEN ([TASK COUNT]=[DONE COUNT]) THEN ('Done') ELSE (CASE WHEN ([DONE COUNT] != 0 AND [TASK COUNT]=([DONE COUNT]+[FRESH COUNT])) THEN ('In-Process') ELSE (CASE WHEN ([TASK COUNT]=[FRESH COUNT]) THEN ('Fresh') END) END) END) END) END AS  [STATUS]
--	FROM(
--		SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], COUNT(pd.PCP_Status) AS [TASK COUNT], 
--		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=0 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [FRESH COUNT],
--		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=2 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [IN-PROCESS COUNT],
--		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=3 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [DONE COUNT],
--		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=1 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [HOLD COUNT]
--		FROM tbl_PCPDetail pd
--		INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
--		INNER JOIN tbl_PCPHeader ph ON pd.PCP_ID=ph.PCP_ID
--		WHERE pch.PIC_UID=@mPIC AND pd.PCP_Project=@mProject
--		GROUP BY pd.PCP_Project, pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File
--	)WLResource

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_DataSetByPICAndShipment]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_DataSetByPICAndShipment] @mPIC varchar(50), @mShipment varchar(1000)

AS

/*WORKLOAD DATASET*/
SELECT [CREATED DATE], PROJECT, [JOB CODE], [SHIPMENT], [FILE NAME], [TASK COUNT], [FRESH COUNT] AS [FRESH TASKS], [IN-PROCESS COUNT] AS [IN-PROCESS TASKS], [DONE COUNT] AS [DONE TASKS], [HOLD COUNT] AS [HOLD TASKS],
	CASE WHEN ([IN-PROCESS COUNT]>=1 AND [HOLD COUNT]=0) THEN ('In-Process') ELSE (CASE WHEN ([HOLD COUNT]>=1 AND [IN-PROCESS COUNT]=0) THEN ('Hold') ELSE (CASE WHEN ([TASK COUNT]=[DONE COUNT]) THEN ('Done') ELSE (CASE WHEN ([DONE COUNT] != 0 AND [TASK COUNT]=([DONE COUNT]+[FRESH COUNT])) THEN ('In-Process') ELSE (CASE WHEN ([TASK COUNT]=[FRESH COUNT]) THEN ('Fresh') END) END) END) END) END AS  [STATUS]
	FROM(
		SELECT MIN(CONVERT(Date, pd.PCP_StartDate)) AS [CREATED DATE],pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], COUNT(pd.PCP_Status) AS [TASK COUNT], 
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=0 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [FRESH COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=2 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [IN-PROCESS COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=3 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [DONE COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=1 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [HOLD COUNT]
		FROM tbl_PCPDetail pd
		INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
		INNER JOIN tbl_PCPHeader ph ON pd.PCP_ID=ph.PCP_ID
		WHERE pch.PIC_UID=@mPIC AND ph.PCP_Shipment=@mShipment
		GROUP BY pd.PCP_Project, pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File
	)WLResource
ORDER BY [CREATED DATE] DESC

--SELECT PROJECT, [JOB CODE], [SHIPMENT], [FILE NAME], [TASK COUNT], [FRESH COUNT] AS [FRESH TASKS], [IN-PROCESS COUNT] AS [IN-PROCESS TASKS], [DONE COUNT] AS [DONE TASKS], [HOLD COUNT] AS [HOLD TASKS],
--	CASE WHEN ([IN-PROCESS COUNT]>=1 AND [HOLD COUNT]=0) THEN ('In-Process') ELSE (CASE WHEN ([HOLD COUNT]>=1 AND [IN-PROCESS COUNT]=0) THEN ('Hold') ELSE (CASE WHEN ([TASK COUNT]=[DONE COUNT]) THEN ('Done') ELSE (CASE WHEN ([DONE COUNT] != 0 AND [TASK COUNT]=([DONE COUNT]+[FRESH COUNT])) THEN ('In-Process') ELSE (CASE WHEN ([TASK COUNT]=[FRESH COUNT]) THEN ('Fresh') END) END) END) END) END AS  [STATUS]
--	FROM(
--		SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], COUNT(pd.PCP_Status) AS [TASK COUNT], 
--		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=0 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [FRESH COUNT],
--		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=2 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [IN-PROCESS COUNT],
--		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=3 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [DONE COUNT],
--		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=1 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [HOLD COUNT]
--		FROM tbl_PCPDetail pd
--		INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
--		INNER JOIN tbl_PCPHeader ph ON pd.PCP_ID=ph.PCP_ID
--		WHERE pch.PIC_UID=@mPIC AND ph.PCP_Shipment=@mShipment
--		GROUP BY pd.PCP_Project, pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File
--	)WLResource

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_DoneTitles]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_DoneTitles] @mPIC nvarchar(30) 

AS 
/* Done titles */ 
SELECT ROW_NUMBER() OVER(ORDER BY pd.PCP_ID ASC) AS [#], pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT/BATCH], pd.PCP_File AS [FILENAME]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
WHERE PCP_Status=3 AND pch.PIC_UID=@mPIC
GROUP BY pd.PCP_Project, pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File
GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_DoneTitlesByProject]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_DoneTitlesByProject] @mPIC nvarchar(30), @mProject nvarchar(150)

AS 
/* Done titles */ 
SELECT ROW_NUMBER() OVER(ORDER BY pd.PCP_ID ASC) AS [#], pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT/BATCH], pd.PCP_File AS [FILENAME]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
WHERE PCP_Status=3 AND pch.PIC_UID=@mPIC AND pch.PIC_Project=@mProject
GROUP BY pd.PCP_Project, pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_DoneTitlesDataSet]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Dboard_WorkLoad_DoneTitlesDataSet] @mPIC nvarchar(30) 

AS 
/* Done titles Data Set*/
SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], pd.PCP_FileSize AS [FILE SIZE], 
 CASE WHEN (pd.PCP_Status=0) THEN ('Fresh') ELSE (CASE WHEN (pd.PCP_Status=1) THEN ('Hold') ELSE (CASE WHEN (pd.PCP_Status=2) THEN ('Pending') ELSE (CASE WHEN (pd.PCP_Status=3) THEN ('Done') END) END) END) END AS [STATUS]
, pd.Task_UOM AS [UOM], pd.Task_Quota AS [QUOTA], pd.PCP_StartDate AS [JOB CREATED DATE], pd.PCP_EndDate AS [JOB ENDED DATE], pd.PCP_CreatorUID [DCD UID], pd.PC_ProcessCode AS [ITEM CODE], pd.Task_ID AS [TASK CODE], td.Task_Description AS [DESCRIPTION]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_TaskDetail td ON pd.PC_ProcessCode=td.PC_ProcessCode AND pd.PCP_Project=td.PIC_Project AND td.Task_ID=pd.Task_ID
WHERE PCP_Status=3 AND pch.PIC_UID=@mPIC
GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_DoneTitlesDataSetByCreatedDate]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_DoneTitlesDataSetByCreatedDate] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime

AS 
/* Done titles Data Set*/
SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], pd.PCP_FileSize AS [FILE SIZE], 
 CASE WHEN (pd.PCP_Status=0) THEN ('Fresh') ELSE (CASE WHEN (pd.PCP_Status=1) THEN ('Hold') ELSE (CASE WHEN (pd.PCP_Status=2) THEN ('Pending') ELSE (CASE WHEN (pd.PCP_Status=3) THEN ('Done') END) END) END) END AS [STATUS]
, pd.Task_UOM AS [UOM], pd.Task_Quota AS [QUOTA], pd.PCP_StartDate AS [JOB CREATED DATE], pd.PCP_EndDate AS [JOB ENDED DATE], pd.PCP_CreatorUID [DCD UID], pd.PC_ProcessCode AS [ITEM CODE], pd.Task_ID AS [TASK CODE], td.Task_Description AS [DESCRIPTION]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_TaskDetail td ON pd.PC_ProcessCode=td.PC_ProcessCode AND pd.PCP_Project=td.PIC_Project AND td.Task_ID=pd.Task_ID
WHERE PCP_Status=3 AND pch.PIC_UID=@mPIC AND pd.PCP_EndDate BETWEEN @mFrom AND @mTo

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_DoneTitlesDataSetByItemCode]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_DoneTitlesDataSetByItemCode] @mPIC nvarchar(30), @mItemCode nvarchar(150)

AS 
/* Done titles Data Set*/
SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], pd.PCP_FileSize AS [FILE SIZE], 
 CASE WHEN (pd.PCP_Status=0) THEN ('Fresh') ELSE (CASE WHEN (pd.PCP_Status=1) THEN ('Hold') ELSE (CASE WHEN (pd.PCP_Status=2) THEN ('Pending') ELSE (CASE WHEN (pd.PCP_Status=3) THEN ('Done') END) END) END) END AS [STATUS]
, pd.Task_UOM AS [UOM], pd.Task_Quota AS [QUOTA], pd.PCP_StartDate AS [JOB CREATED DATE], pd.PCP_EndDate AS [JOB ENDED DATE], pd.PCP_CreatorUID [DCD UID], pd.PC_ProcessCode AS [ITEM CODE], pd.Task_ID AS [TASK CODE], td.Task_Description AS [DESCRIPTION]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_TaskDetail td ON pd.PC_ProcessCode=td.PC_ProcessCode AND pd.PCP_Project=td.PIC_Project AND td.Task_ID=pd.Task_ID
WHERE PCP_Status=3 AND pch.PIC_UID=@mPIC AND pd.PC_ProcessCode=@mItemCode

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_DoneTitlesDataSetByPICAndDate]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_DoneTitlesDataSetByPICAndDate] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime

AS 
/* Done titles Data Set*/
SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], pd.PCP_FileSize AS [FILE SIZE], 
 CASE WHEN (pd.PCP_Status=0) THEN ('Fresh') ELSE (CASE WHEN (pd.PCP_Status=1) THEN ('Hold') ELSE (CASE WHEN (pd.PCP_Status=2) THEN ('Pending') ELSE (CASE WHEN (pd.PCP_Status=3) THEN ('Done') END) END) END) END AS [STATUS]
, pd.Task_UOM AS [UOM], pd.Task_Quota AS [QUOTA], pd.PCP_StartDate AS [JOB CREATED DATE], pd.PCP_EndDate AS [JOB ENDED DATE], pd.PCP_CreatorUID [DCD UID], pd.PC_ProcessCode AS [ITEM CODE], pd.Task_ID AS [TASK CODE], td.Task_Description AS [DESCRIPTION]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_TaskDetail td ON pd.PC_ProcessCode=td.PC_ProcessCode AND pd.PCP_Project=td.PIC_Project AND td.Task_ID=pd.Task_ID
WHERE PCP_Status=3 AND pch.PIC_UID=@mPIC AND pd.PCP_StartDate BETWEEN @mFrom AND @mTo

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_DoneTitlesDataSetByProject]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_DoneTitlesDataSetByProject] @mPIC nvarchar(30), @mProject nvarchar(150)

AS 
/* Done titles Data Set*/
SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], pd.PCP_FileSize AS [FILE SIZE], 
 CASE WHEN (pd.PCP_Status=0) THEN ('Fresh') ELSE (CASE WHEN (pd.PCP_Status=1) THEN ('Hold') ELSE (CASE WHEN (pd.PCP_Status=2) THEN ('Pending') ELSE (CASE WHEN (pd.PCP_Status=3) THEN ('Done') END) END) END) END AS [STATUS]
, pd.Task_UOM AS [UOM], pd.Task_Quota AS [QUOTA], pd.PCP_StartDate AS [JOB CREATED DATE], pd.PCP_EndDate AS [JOB ENDED DATE], pd.PCP_CreatorUID [DCD UID], pd.PC_ProcessCode AS [ITEM CODE], pd.Task_ID AS [TASK CODE], td.Task_Description AS [DESCRIPTION]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_TaskDetail td ON pd.PC_ProcessCode=td.PC_ProcessCode AND pd.PCP_Project=td.PIC_Project AND td.Task_ID=pd.Task_ID
WHERE PCP_Status=3 AND pch.PIC_UID=@mPIC AND pd.PCP_Project=@mProject

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_DoneTitlesDetails]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Dboard_WorkLoad_DoneTitlesDetails] @mPIC nvarchar(30), @mProject nvarchar(100), @mJobCode nvarchar(200), @mShipment nvarchar(1000)

AS 
/* Done title details */ 
SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], pd.PCP_FileSize AS [FILE SIZE], pd.PCP_Status AS [STATUS], pd.Task_UOM AS [UOM], pd.Task_Quota AS [QUOTA]/*, pd.PCP_StartDate AS [JOB CREATED DATE], pd.PCP_EndDate AS [JOB ENDED DATE] */, pd.PCP_CreatorUID [DCD UID], pd.PC_ProcessCode AS [ITEM CODE], pd.Task_ID AS [TASK CODE], td.Task_Description AS [DESCRIPTION]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_TaskDetail td ON pd.PC_ProcessCode=td.PC_ProcessCode AND pd.PCP_Project=td.PIC_Project AND td.Task_ID=pd.Task_ID
WHERE PCP_Status=3 AND pch.PIC_UID=@mPIC AND pd.PCP_Project=@mProject AND  pd.PCP_ID=@mJobCode AND ph.PCP_Shipment=@mShipment
GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_ExportAllDataSetByProject]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_ExportAllDataSetByProject] @mPIC nvarchar(30), @mProject nvarchar(150)
AS
SELECT ROW_NUMBER() OVER(ORDER BY pd.PCP_ID ASC) AS [#], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT/BATCH], pd.PCP_File AS [FILENAME],
CASE WHEN (pd.PCP_Status=0) THEN ('Fresh') ELSE (CASE WHEN (pd.PCP_Status=1) THEN ('Hold') ELSE (CASE WHEN (pd.PCP_Status=2) THEN ('Pending') ELSE (CASE WHEN (pd.PCP_Status=3) THEN ('Done') END) END) END) END AS [STATUS]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
WHERE pch.PIC_UID=@mPIC AND pch.PIC_Project=@mProject
GROUP BY pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File,pd.PCP_Status
GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_FreshTitles]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_FreshTitles] @mPIC nvarchar(30) 

AS 
/* Fresh titles */ 
SELECT ROW_NUMBER() OVER(ORDER BY pd.PCP_ID ASC) AS [#], pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT/BATCH], pd.PCP_File AS [FILENAME]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
WHERE PCP_Status=0 AND pch.PIC_UID=@mPIC
GROUP BY pd.PCP_Project, pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File
GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_FreshTitlesByProject]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_FreshTitlesByProject] @mPIC nvarchar(30), @mProject nvarchar(150)

AS 
/* Fresh titles */ 
SELECT ROW_NUMBER() OVER(ORDER BY pd.PCP_ID ASC) AS [#], pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT/BATCH], pd.PCP_File AS [FILENAME]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
WHERE PCP_Status=0 AND pch.PIC_UID=@mPIC AND pch.PIC_Project=@mProject
GROUP BY pd.PCP_Project, pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_FreshTitlesDataSet]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Dboard_WorkLoad_FreshTitlesDataSet] @mPIC nvarchar(30) 

AS 
/* Fresh titles Data Set*/
SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], pd.PCP_FileSize AS [FILE SIZE], 
 CASE WHEN (pd.PCP_Status=0) THEN ('Fresh') ELSE (CASE WHEN (pd.PCP_Status=1) THEN ('Hold') ELSE (CASE WHEN (pd.PCP_Status=2) THEN ('Pending') ELSE (CASE WHEN (pd.PCP_Status=3) THEN ('Done') END) END) END) END AS [STATUS]
, pd.Task_UOM AS [UOM], pd.Task_Quota AS [QUOTA], pd.PCP_StartDate AS [JOB CREATED DATE]/*, pd.PCP_EndDate AS [JOB ENDED DATE] */, pd.PCP_CreatorUID [DCD UID], pd.PC_ProcessCode AS [ITEM CODE], pd.Task_ID AS [TASK CODE], td.Task_Description AS [DESCRIPTION]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_TaskDetail td ON pd.PC_ProcessCode=td.PC_ProcessCode AND pd.PCP_Project=td.PIC_Project AND td.Task_ID=pd.Task_ID
WHERE PCP_Status=0 AND pch.PIC_UID=@mPIC
GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_FreshTitlesDataSetByCreatedDate]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_FreshTitlesDataSetByCreatedDate] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime

AS 
/* Fresh titles Data Set*/
SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], pd.PCP_FileSize AS [FILE SIZE], 
 CASE WHEN (pd.PCP_Status=0) THEN ('Fresh') ELSE (CASE WHEN (pd.PCP_Status=1) THEN ('Hold') ELSE (CASE WHEN (pd.PCP_Status=2) THEN ('Pending') ELSE (CASE WHEN (pd.PCP_Status=3) THEN ('Done') END) END) END) END AS [STATUS]
, pd.Task_UOM AS [UOM], pd.Task_Quota AS [QUOTA], pd.PCP_StartDate AS [JOB CREATED DATE]/*, pd.PCP_EndDate AS [JOB ENDED DATE] */, pd.PCP_CreatorUID [DCD UID], pd.PC_ProcessCode AS [ITEM CODE], pd.Task_ID AS [TASK CODE], td.Task_Description AS [DESCRIPTION]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_TaskDetail td ON pd.PC_ProcessCode=td.PC_ProcessCode AND pd.PCP_Project=td.PIC_Project AND td.Task_ID=pd.Task_ID
WHERE PCP_Status=0 AND pch.PIC_UID=@mPIC AND pd.PCP_StartDate BETWEEN @mFrom AND @mTo

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_FreshTitlesDataSetByItemCode]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_FreshTitlesDataSetByItemCode] @mPIC nvarchar(30), @mItemCode nvarchar(150)

AS 
/* Fresh titles Data Set*/
SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], pd.PCP_FileSize AS [FILE SIZE], 
 CASE WHEN (pd.PCP_Status=0) THEN ('Fresh') ELSE (CASE WHEN (pd.PCP_Status=1) THEN ('Hold') ELSE (CASE WHEN (pd.PCP_Status=2) THEN ('Pending') ELSE (CASE WHEN (pd.PCP_Status=3) THEN ('Done') END) END) END) END AS [STATUS]
, pd.Task_UOM AS [UOM], pd.Task_Quota AS [QUOTA], pd.PCP_StartDate AS [JOB CREATED DATE]/*, pd.PCP_EndDate AS [JOB ENDED DATE] */, pd.PCP_CreatorUID [DCD UID], pd.PC_ProcessCode AS [ITEM CODE], pd.Task_ID AS [TASK CODE], td.Task_Description AS [DESCRIPTION]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_TaskDetail td ON pd.PC_ProcessCode=td.PC_ProcessCode AND pd.PCP_Project=td.PIC_Project AND td.Task_ID=pd.Task_ID
WHERE PCP_Status=0 AND pch.PIC_UID=@mPIC AND pd.PC_ProcessCode=@mItemCode

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_FreshTitlesDataSetByProject]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_FreshTitlesDataSetByProject] @mPIC nvarchar(30), @mProject nvarchar(150)

AS 
/* Fresh titles Data Set*/
SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], pd.PCP_FileSize AS [FILE SIZE], 
 CASE WHEN (pd.PCP_Status=0) THEN ('Fresh') ELSE (CASE WHEN (pd.PCP_Status=1) THEN ('Hold') ELSE (CASE WHEN (pd.PCP_Status=2) THEN ('Pending') ELSE (CASE WHEN (pd.PCP_Status=3) THEN ('Done') END) END) END) END AS [STATUS]
, pd.Task_UOM AS [UOM], pd.Task_Quota AS [QUOTA], pd.PCP_StartDate AS [JOB CREATED DATE]/*, pd.PCP_EndDate AS [JOB ENDED DATE] */, pd.PCP_CreatorUID [DCD UID], pd.PC_ProcessCode AS [ITEM CODE], pd.Task_ID AS [TASK CODE], td.Task_Description AS [DESCRIPTION]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_TaskDetail td ON pd.PC_ProcessCode=td.PC_ProcessCode AND pd.PCP_Project=td.PIC_Project AND td.Task_ID=pd.Task_ID
WHERE PCP_Status=0 AND pch.PIC_UID=@mPIC AND pd.PCP_Project=@mProject

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_FreshTitlesDetails]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Dboard_WorkLoad_FreshTitlesDetails] @mPIC nvarchar(30), @mProject nvarchar(100), @mJobCode nvarchar(200), @mShipment nvarchar(1000)

AS 
/* Fresh title details */ 
SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], pd.PCP_FileSize AS [FILE SIZE], pd.PCP_Status AS [STATUS], pd.Task_UOM AS [UOM], pd.Task_Quota AS [QUOTA]/*, pd.PCP_StartDate AS [JOB CREATED DATE], pd.PCP_EndDate AS [JOB ENDED DATE] */, pd.PCP_CreatorUID [DCD UID], pd.PC_ProcessCode AS [ITEM CODE], pd.Task_ID AS [TASK CODE], td.Task_Description AS [DESCRIPTION]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_TaskDetail td ON pd.PC_ProcessCode=td.PC_ProcessCode AND pd.PCP_Project=td.PIC_Project AND td.Task_ID=pd.Task_ID
WHERE PCP_Status=0 AND pch.PIC_UID=@mPIC AND pd.PCP_Project=@mProject AND  pd.PCP_ID=@mJobCode AND ph.PCP_Shipment=@mShipment
GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_HoldTitles]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_HoldTitles] @mPIC nvarchar(30) 

AS 
/* Hold titles */ 
SELECT ROW_NUMBER() OVER(ORDER BY pd.PCP_ID ASC) AS [#], pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT/BATCH], pd.PCP_File AS [FILENAME]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
WHERE PCP_Status=1 AND pch.PIC_UID=@mPIC
GROUP BY pd.PCP_Project, pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File
GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_HoldTitlesByProject]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_HoldTitlesByProject] @mPIC nvarchar(30), @mProject nvarchar(150)

AS 
/* Hold titles */ 
SELECT ROW_NUMBER() OVER(ORDER BY pd.PCP_ID ASC) AS [#], pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT/BATCH], pd.PCP_File AS [FILENAME]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
WHERE PCP_Status=1 AND pch.PIC_UID=@mPIC AND pch.PIC_Project=@mProject
GROUP BY pd.PCP_Project, pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_HoldTitlesDataSet]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Dboard_WorkLoad_HoldTitlesDataSet] @mPIC nvarchar(30) 

AS 
/* Hold titles Data Set*/
SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], pd.PCP_FileSize AS [FILE SIZE], 
 CASE WHEN (pd.PCP_Status=0) THEN ('Fresh') ELSE (CASE WHEN (pd.PCP_Status=1) THEN ('Hold') ELSE (CASE WHEN (pd.PCP_Status=2) THEN ('Pending') ELSE (CASE WHEN (pd.PCP_Status=3) THEN ('Done') END) END) END) END AS [STATUS]
, pd.Task_UOM AS [UOM], pd.Task_Quota AS [QUOTA], pd.PCP_StartDate AS [JOB CREATED DATE]/*, pd.PCP_EndDate AS [JOB ENDED DATE] */, pd.PCP_CreatorUID [DCD UID], pd.PC_ProcessCode AS [ITEM CODE], pd.Task_ID AS [TASK CODE], td.Task_Description AS [DESCRIPTION]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_TaskDetail td ON pd.PC_ProcessCode=td.PC_ProcessCode AND pd.PCP_Project=td.PIC_Project AND td.Task_ID=pd.Task_ID
WHERE PCP_Status=1 AND pch.PIC_UID=@mPIC
GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_HoldTitlesDataSetByCreatedDate]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_HoldTitlesDataSetByCreatedDate] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime

AS 
/* Hold titles Data Set*/
SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], pd.PCP_FileSize AS [FILE SIZE], 
 CASE WHEN (pd.PCP_Status=0) THEN ('Fresh') ELSE (CASE WHEN (pd.PCP_Status=1) THEN ('Hold') ELSE (CASE WHEN (pd.PCP_Status=2) THEN ('Pending') ELSE (CASE WHEN (pd.PCP_Status=3) THEN ('Done') END) END) END) END AS [STATUS]
, pd.Task_UOM AS [UOM], pd.Task_Quota AS [QUOTA], pd.PCP_StartDate AS [JOB CREATED DATE]/*, pd.PCP_EndDate AS [JOB ENDED DATE] */, pd.PCP_CreatorUID [DCD UID], pd.PC_ProcessCode AS [ITEM CODE], pd.Task_ID AS [TASK CODE], td.Task_Description AS [DESCRIPTION]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_TaskDetail td ON pd.PC_ProcessCode=td.PC_ProcessCode AND pd.PCP_Project=td.PIC_Project AND td.Task_ID=pd.Task_ID
WHERE PCP_Status=1 AND pch.PIC_UID=@mPIC AND pd.PCP_StartDate BETWEEN @mFrom AND @mTo

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_HoldTitlesDataSetByItemCode]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_HoldTitlesDataSetByItemCode] @mPIC nvarchar(30), @mItemCode nvarchar(150)

AS 
/* Hold titles Data Set*/
SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], pd.PCP_FileSize AS [FILE SIZE], 
 CASE WHEN (pd.PCP_Status=0) THEN ('Fresh') ELSE (CASE WHEN (pd.PCP_Status=1) THEN ('Hold') ELSE (CASE WHEN (pd.PCP_Status=2) THEN ('Pending') ELSE (CASE WHEN (pd.PCP_Status=3) THEN ('Done') END) END) END) END AS [STATUS]
, pd.Task_UOM AS [UOM], pd.Task_Quota AS [QUOTA], pd.PCP_StartDate AS [JOB CREATED DATE]/*, pd.PCP_EndDate AS [JOB ENDED DATE] */, pd.PCP_CreatorUID [DCD UID], pd.PC_ProcessCode AS [ITEM CODE], pd.Task_ID AS [TASK CODE], td.Task_Description AS [DESCRIPTION]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_TaskDetail td ON pd.PC_ProcessCode=td.PC_ProcessCode AND pd.PCP_Project=td.PIC_Project AND td.Task_ID=pd.Task_ID
WHERE PCP_Status=1 AND pch.PIC_UID=@mPIC AND pd.PC_ProcessCode=@mItemCode

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_HoldTitlesDataSetByProject]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_HoldTitlesDataSetByProject] @mPIC nvarchar(30), @mProject nvarchar(150)

AS 
/* Hold titles Data Set*/
SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], pd.PCP_FileSize AS [FILE SIZE], 
 CASE WHEN (pd.PCP_Status=0) THEN ('Fresh') ELSE (CASE WHEN (pd.PCP_Status=1) THEN ('Hold') ELSE (CASE WHEN (pd.PCP_Status=2) THEN ('Pending') ELSE (CASE WHEN (pd.PCP_Status=3) THEN ('Done') END) END) END) END AS [STATUS]
, pd.Task_UOM AS [UOM], pd.Task_Quota AS [QUOTA], pd.PCP_StartDate AS [JOB CREATED DATE]/*, pd.PCP_EndDate AS [JOB ENDED DATE] */, pd.PCP_CreatorUID [DCD UID], pd.PC_ProcessCode AS [ITEM CODE], pd.Task_ID AS [TASK CODE], td.Task_Description AS [DESCRIPTION]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_TaskDetail td ON pd.PC_ProcessCode=td.PC_ProcessCode AND pd.PCP_Project=td.PIC_Project AND td.Task_ID=pd.Task_ID
WHERE PCP_Status=1 AND pch.PIC_UID=@mPIC AND pd.PCP_Project=@mProject

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_HoldTitlesDetails]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Dboard_WorkLoad_HoldTitlesDetails] @mPIC nvarchar(30), @mProject nvarchar(100), @mJobCode nvarchar(200), @mShipment nvarchar(1000)

AS 
/* Hold title details */ 
SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], pd.PCP_FileSize AS [FILE SIZE], pd.PCP_Status AS [STATUS], pd.Task_UOM AS [UOM], pd.Task_Quota AS [QUOTA]/*, pd.PCP_StartDate AS [JOB CREATED DATE], pd.PCP_EndDate AS [JOB ENDED DATE] */, pd.PCP_CreatorUID [DCD UID], pd.PC_ProcessCode AS [ITEM CODE], pd.Task_ID AS [TASK CODE], td.Task_Description AS [DESCRIPTION]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_TaskDetail td ON pd.PC_ProcessCode=td.PC_ProcessCode AND pd.PCP_Project=td.PIC_Project AND td.Task_ID=pd.Task_ID
WHERE PCP_Status=1 AND pch.PIC_UID=@mPIC AND pd.PCP_Project=@mProject AND  pd.PCP_ID=@mJobCode AND ph.PCP_Shipment=@mShipment
GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_PendingTitles]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_PendingTitles] @mPIC nvarchar(30) 

AS 
/* Pending titles */ 
SELECT ROW_NUMBER() OVER(ORDER BY pd.PCP_ID ASC) AS [#], pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT/BATCH], pd.PCP_File AS [FILENAME]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
WHERE PCP_Status=2 AND pch.PIC_UID=@mPIC
GROUP BY pd.PCP_Project, pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File
GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_PendingTitlesByProject]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_PendingTitlesByProject]  @mPIC nvarchar(30), @mProject nvarchar(150)

AS 
/* Pending titles */ 
SELECT ROW_NUMBER() OVER(ORDER BY pd.PCP_ID ASC) AS [#], pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT/BATCH], pd.PCP_File AS [FILENAME]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
WHERE PCP_Status=2 AND pch.PIC_UID=@mPIC AND pch.PIC_Project=@mProject
GROUP BY pd.PCP_Project, pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_PendingTitlesDataSet]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Dboard_WorkLoad_PendingTitlesDataSet] @mPIC nvarchar(30) 

AS 
/* Pending titles Data Set*/
SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], pd.PCP_FileSize AS [FILE SIZE], 
 CASE WHEN (pd.PCP_Status=0) THEN ('Fresh') ELSE (CASE WHEN (pd.PCP_Status=1) THEN ('Hold') ELSE (CASE WHEN (pd.PCP_Status=2) THEN ('Pending') ELSE (CASE WHEN (pd.PCP_Status=3) THEN ('Done') END) END) END) END AS [STATUS]
, pd.Task_UOM AS [UOM], pd.Task_Quota AS [QUOTA], pd.PCP_StartDate AS [JOB CREATED DATE]/*, pd.PCP_EndDate AS [JOB ENDED DATE] */, pd.PCP_CreatorUID [DCD UID], pd.PC_ProcessCode AS [ITEM CODE], pd.Task_ID AS [TASK CODE], td.Task_Description AS [DESCRIPTION]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_TaskDetail td ON pd.PC_ProcessCode=td.PC_ProcessCode AND pd.PCP_Project=td.PIC_Project AND td.Task_ID=pd.Task_ID
WHERE PCP_Status=2 AND pch.PIC_UID=@mPIC
GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_PendingTitlesDataSetByCreatedDate]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_PendingTitlesDataSetByCreatedDate] @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime

AS 
/* Pending titles Data Set*/
SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], pd.PCP_FileSize AS [FILE SIZE], 
 CASE WHEN (pd.PCP_Status=0) THEN ('Fresh') ELSE (CASE WHEN (pd.PCP_Status=1) THEN ('Hold') ELSE (CASE WHEN (pd.PCP_Status=2) THEN ('Pending') ELSE (CASE WHEN (pd.PCP_Status=3) THEN ('Done') END) END) END) END AS [STATUS]
, pd.Task_UOM AS [UOM], pd.Task_Quota AS [QUOTA], pd.PCP_StartDate AS [JOB CREATED DATE]/*, pd.PCP_EndDate AS [JOB ENDED DATE] */, pd.PCP_CreatorUID [DCD UID], pd.PC_ProcessCode AS [ITEM CODE], pd.Task_ID AS [TASK CODE], td.Task_Description AS [DESCRIPTION]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_TaskDetail td ON pd.PC_ProcessCode=td.PC_ProcessCode AND pd.PCP_Project=td.PIC_Project AND td.Task_ID=pd.Task_ID
WHERE PCP_Status=2 AND pch.PIC_UID=@mPIC AND pd.PCP_StartDate BETWEEN @mFrom AND @mTo

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_PendingTitlesDataSetByItemCode]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_PendingTitlesDataSetByItemCode] @mPIC nvarchar(30), @mItemCode nvarchar(150)

AS 
/* Pending titles Data Set*/
SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], pd.PCP_FileSize AS [FILE SIZE], 
 CASE WHEN (pd.PCP_Status=0) THEN ('Fresh') ELSE (CASE WHEN (pd.PCP_Status=1) THEN ('Hold') ELSE (CASE WHEN (pd.PCP_Status=2) THEN ('Pending') ELSE (CASE WHEN (pd.PCP_Status=3) THEN ('Done') END) END) END) END AS [STATUS]
, pd.Task_UOM AS [UOM], pd.Task_Quota AS [QUOTA], pd.PCP_StartDate AS [JOB CREATED DATE]/*, pd.PCP_EndDate AS [JOB ENDED DATE] */, pd.PCP_CreatorUID [DCD UID], pd.PC_ProcessCode AS [ITEM CODE], pd.Task_ID AS [TASK CODE], td.Task_Description AS [DESCRIPTION]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_TaskDetail td ON pd.PC_ProcessCode=td.PC_ProcessCode AND pd.PCP_Project=td.PIC_Project AND td.Task_ID=pd.Task_ID
WHERE PCP_Status=2 AND pch.PIC_UID=@mPIC AND pd.PC_ProcessCode=@mItemCode

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_PendingTitlesDataSetByProject]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_PendingTitlesDataSetByProject] @mPIC nvarchar(30), @mProject nvarchar(150)

AS 
/* Pending titles Data Set*/
SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], pd.PCP_FileSize AS [FILE SIZE], 
 CASE WHEN (pd.PCP_Status=0) THEN ('Fresh') ELSE (CASE WHEN (pd.PCP_Status=1) THEN ('Hold') ELSE (CASE WHEN (pd.PCP_Status=2) THEN ('Pending') ELSE (CASE WHEN (pd.PCP_Status=3) THEN ('Done') END) END) END) END AS [STATUS]
, pd.Task_UOM AS [UOM], pd.Task_Quota AS [QUOTA], pd.PCP_StartDate AS [JOB CREATED DATE]/*, pd.PCP_EndDate AS [JOB ENDED DATE] */, pd.PCP_CreatorUID [DCD UID], pd.PC_ProcessCode AS [ITEM CODE], pd.Task_ID AS [TASK CODE], td.Task_Description AS [DESCRIPTION]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_TaskDetail td ON pd.PC_ProcessCode=td.PC_ProcessCode AND pd.PCP_Project=td.PIC_Project AND td.Task_ID=pd.Task_ID
WHERE PCP_Status=2 AND pch.PIC_UID=@mPIC AND pd.PCP_Project=@mProject

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_PendingTitlesDetails]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Dboard_WorkLoad_PendingTitlesDetails] @mPIC nvarchar(30), @mProject nvarchar(100), @mJobCode nvarchar(200), @mShipment nvarchar(1000)

AS 
/* Pending title details */ 
SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], pd.PCP_FileSize AS [FILE SIZE], pd.PCP_Status AS [STATUS], pd.Task_UOM AS [UOM], pd.Task_Quota AS [QUOTA]/*, pd.PCP_StartDate AS [JOB CREATED DATE], pd.PCP_EndDate AS [JOB ENDED DATE] */, pd.PCP_CreatorUID [DCD UID], pd.PC_ProcessCode AS [ITEM CODE], pd.Task_ID AS [TASK CODE], td.Task_Description AS [DESCRIPTION]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_TaskDetail td ON pd.PC_ProcessCode=td.PC_ProcessCode AND pd.PCP_Project=td.PIC_Project AND td.Task_ID=pd.Task_ID
WHERE PCP_Status=2 AND pch.PIC_UID=@mPIC AND pd.PCP_Project=@mProject AND  pd.PCP_ID=@mJobCode AND ph.PCP_Shipment=@mShipment
GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_ViewDoneTitlesByProjectAndPCPCode]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Dboard_WorkLoad_ViewDoneTitlesByProjectAndPCPCode] @mPIC nvarchar(30), @mProject nvarchar(150), @mPCPCode nvarchar(300)
AS
/* View Record Done*/
SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], pd.PCP_FileSize AS [FILE SIZE],
 CASE WHEN (pd.PCP_Status=0) THEN ('Fresh') ELSE (CASE WHEN (pd.PCP_Status=1) THEN ('Hold') ELSE (CASE WHEN (pd.PCP_Status=2) THEN ('Pending') ELSE (CASE WHEN (pd.PCP_Status=3) THEN ('Done') END) END) END) END AS [STATUS]
 , pd.Task_UOM AS [UOM], pd.Task_Quota AS [QUOTA], pd.PCP_StartDate AS [JOB CREATED DATE]/*, pd.PCP_EndDate AS [JOB ENDED DATE] */, pd.PCP_CreatorUID [DCD UID], pd.PC_ProcessCode AS [ITEM CODE], pd.Task_ID AS [TASK CODE], td.Task_Description AS [DESCRIPTION]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_TaskDetail td ON pd.PC_ProcessCode=td.PC_ProcessCode AND pd.PCP_Project=td.PIC_Project AND td.Task_ID=pd.Task_ID
WHERE PCP_Status=3 AND pch.PIC_UID=@mPIC AND pch.PIC_Project=@mProject AND pd.PCP_ID=@mPCPCode

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_ViewFreshTitlesByProjectAndPCPCode]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_ViewFreshTitlesByProjectAndPCPCode] @mPIC nvarchar(30), @mProject nvarchar(150), @mPCPCode nvarchar(300)
AS
/* View Record Fresh*/
SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], pd.PCP_FileSize AS [FILE SIZE],
  CASE WHEN (pd.PCP_Status=0) THEN ('Fresh') ELSE (CASE WHEN (pd.PCP_Status=1) THEN ('Hold') ELSE (CASE WHEN (pd.PCP_Status=2) THEN ('Pending') ELSE (CASE WHEN (pd.PCP_Status=3) THEN ('Done') END) END) END) END AS [STATUS]
 , pd.Task_UOM AS [UOM], pd.Task_Quota AS [QUOTA], pd.PCP_StartDate AS [JOB CREATED DATE]/*, pd.PCP_EndDate AS [JOB ENDED DATE] */, pd.PCP_CreatorUID [DCD UID], pd.PC_ProcessCode AS [ITEM CODE], pd.Task_ID AS [TASK CODE], td.Task_Description AS [DESCRIPTION]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_TaskDetail td ON pd.PC_ProcessCode=td.PC_ProcessCode AND pd.PCP_Project=td.PIC_Project AND td.Task_ID=pd.Task_ID
WHERE PCP_Status=0 AND pch.PIC_UID=@mPIC AND pch.PIC_Project=@mProject AND pd.PCP_ID=@mPCPCode

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_ViewHoldTitlesByProjectAndPCPCode]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoad_ViewHoldTitlesByProjectAndPCPCode] @mPIC nvarchar(30), @mProject nvarchar(150), @mPCPCode nvarchar(300)
AS
/* View Record Hold*/
SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], pd.PCP_FileSize AS [FILE SIZE], 
 CASE WHEN (pd.PCP_Status=0) THEN ('Fresh') ELSE (CASE WHEN (pd.PCP_Status=1) THEN ('Hold') ELSE (CASE WHEN (pd.PCP_Status=2) THEN ('Pending') ELSE (CASE WHEN (pd.PCP_Status=3) THEN ('Done') END) END) END) END AS [STATUS]
, pd.Task_UOM AS [UOM], pd.Task_Quota AS [QUOTA], pd.PCP_StartDate AS [JOB CREATED DATE]/*, pd.PCP_EndDate AS [JOB ENDED DATE] */, pd.PCP_CreatorUID [DCD UID], pd.PC_ProcessCode AS [ITEM CODE], pd.Task_ID AS [TASK CODE], td.Task_Description AS [DESCRIPTION]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_TaskDetail td ON pd.PC_ProcessCode=td.PC_ProcessCode AND pd.PCP_Project=td.PIC_Project AND td.Task_ID=pd.Task_ID
WHERE PCP_Status=1 AND pch.PIC_UID=@mPIC AND pch.PIC_Project=@mProject AND pd.PCP_ID=@mPCPCode

GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoad_ViewPendingTitlesByProjectAndPCPCode]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Dboard_WorkLoad_ViewPendingTitlesByProjectAndPCPCode] @mPIC nvarchar(30), @mProject nvarchar(150), @mPCPCode nvarchar(300)
AS
/* View Record Pending*/
SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], pd.PCP_FileSize AS [FILE SIZE], 
 CASE WHEN (pd.PCP_Status=0) THEN ('Fresh') ELSE (CASE WHEN (pd.PCP_Status=1) THEN ('Hold') ELSE (CASE WHEN (pd.PCP_Status=2) THEN ('Pending') ELSE (CASE WHEN (pd.PCP_Status=3) THEN ('Done') END) END) END) END AS [STATUS]
, pd.Task_UOM AS [UOM], pd.Task_Quota AS [QUOTA], pd.PCP_StartDate AS [JOB CREATED DATE]/*, pd.PCP_EndDate AS [JOB ENDED DATE] */, pd.PCP_CreatorUID [DCD UID], pd.PC_ProcessCode AS [ITEM CODE], pd.Task_ID AS [TASK CODE], td.Task_Description AS [DESCRIPTION]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_TaskDetail td ON pd.PC_ProcessCode=td.PC_ProcessCode AND pd.PCP_Project=td.PIC_Project AND td.Task_ID=pd.Task_ID
WHERE PCP_Status=2 AND pch.PIC_UID=@mPIC AND pch.PIC_Project=@mProject AND pd.PCP_ID=@mPCPCode
GO
/****** Object:  StoredProcedure [dbo].[Dboard_WorkLoadMID]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Dboard_WorkLoadMID] @mPIC nvarchar(30), @mMUID nvarchar(30)

AS


SELECT   
  tblPivot.Property, tblPivot.Value 
FROM   
(	
	SELECT 
		SUM(CASE WHEN [STATUS]='In-Process' THEN 1 ELSE 0 END) AS  [IN-PROCESS],
		SUM(CASE WHEN [STATUS]='Fresh' THEN 1 ELSE 0 END) AS  [FRESH],
		SUM(CASE WHEN [STATUS]='Hold' THEN 1 ELSE 0 END) AS  [HOLD]
	FROM(
		SELECT PROJECT, [JOB CODE], [FILE NAME],
		CASE WHEN ([IN-PROCESS COUNT]>=1 AND [HOLD COUNT]=0) THEN ('In-Process') ELSE (CASE WHEN ([HOLD COUNT]>=1 AND [IN-PROCESS COUNT]=0) THEN ('Hold') ELSE (CASE WHEN ([TASK COUNT]=[DONE COUNT]) THEN ('Done') ELSE (CASE WHEN ([DONE COUNT] != 0 AND [TASK COUNT]=([DONE COUNT]+[FRESH COUNT])) THEN ('In-Process') ELSE (CASE WHEN ([TASK COUNT]=[FRESH COUNT]) THEN ('Fresh') END) END) END) END) END AS  [STATUS]
		FROM(
			SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], pd.PCP_File AS [FILE NAME], COUNT(pd.PCP_Status) AS [TASK COUNT], 
			(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=0 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [FRESH COUNT],
			(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=2 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [IN-PROCESS COUNT],
			(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=3 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [DONE COUNT],
			(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=1 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [HOLD COUNT]
			FROM tbl_PCPDetail pd
			INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
			INNER JOIN tbl_ManagerDetail md ON pd.PCP_Project=md.M_Project AND md.M_Project_Availability='Active'
			WHERE pch.PIC_UID=@mPIC AND md.M_UID=@mMUID
			GROUP BY pd.PCP_Project, pd.PCP_ID, pd.PCP_File
		) WLResource
	) WorkLoadGraph
) Person
UNPIVOT (Value For Property In (/*[DONE], */[IN-PROCESS], [FRESH],[HOLD])) as tblPivot
ORDER BY tblPivot.Value DESC


--SELECT   
--  tblPivot.Property, tblPivot.Value 
--FROM   
--(	SELECT 
--	--SUM(CASE WHEN pd.PCP_Status=3 THEN 1 ELSE 0 END) AS  [DONE],
--	SUM(CASE WHEN pd.PCP_Status=2 THEN 1 ELSE 0 END) AS  [IN-PROCESS],
--	SUM(CASE WHEN pd.PCP_Status=0 THEN 1 ELSE 0 END) AS  [FRESH],
--	SUM(CASE WHEN pd.PCP_Status=1 THEN 1 ELSE 0 END) AS  [HOLD]
--	FROM tbl_PCPDetail pd
--	INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
--	WHERE pch.PIC_UID=@mPIC 
--) Person
--  UNPIVOT (Value For Property In (/*[DONE], */[IN-PROCESS], [FRESH],[HOLD])) as tblPivot
--ORDER BY tblPivot.Value DESC



--DECLARE @WorkLoad TABLE(
--    InProcess varchar(50),
--    IDLE varchar(50),
--	Hold varchar(50)
--);
--DECLARE @WorkLoadFinal TABLE(
--    TDetail varchar(50),
--    Tcount varchar(50)
--);



----//PCP_Status        int             Unchecked /* 0-Fresh, 1-Hold, 2-Pending, 3-Done */

--/*Fresh Titles*/
--INSERT INTO @WorkLoad (InProcess)

--SELECT PCP_ID AS [In-Process]
--FROM
--	(
--	SELECT PCP_ID
--	FROM tbl_PCPDetail pd
--	INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
--	WHERE PCP_Status=0 AND pch.PIC_UID=@mPIC
--	GROUP BY PCP_ID
--	) FreshTitles

--/*Pending Titles*/
--INSERT INTO @WorkLoad (IDLE)
--SELECT PCP_ID AS [IDLE]
--FROM
--	(
--	SELECT PCP_ID
--	FROM tbl_PCPDetail pd
--	INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
--	WHERE PCP_Status=2 AND pch.PIC_UID=@mPIC
--	GROUP BY PCP_ID
--	) PendingTitles


--/*On Hold Titles*/
--INSERT INTO @WorkLoad (Hold)
--SELECT PCP_ID AS [Hold]
--FROM
--	(
--	SELECT PCP_ID
--	FROM tbl_PCPDetail pd
--	INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
--	WHERE PCP_Status=1 AND pch.PIC_UID=@mPIC
--	GROUP BY PCP_ID
--	) HoldTitles

--INSERT INTO @WorkLoadFinal (TDetail, Tcount)
--SELECT 'IN-PROCESS', COUNT(InProcess)
--FROM @WorkLoad
--WHERE InProcess!='NULL'

--INSERT INTO @WorkLoadFinal (TDetail, Tcount)
--SELECT 'IDLE', COUNT(IDLE)
--FROM @WorkLoad
--WHERE IDLE!='NULL'

--INSERT INTO @WorkLoadFinal (TDetail, Tcount)
--SELECT 'HOLD', COUNT(Hold)
--FROM @WorkLoad
--WHERE Hold!='NULL'

--SELECT *
--FROM @WorkLoadFinal

GO
/****** Object:  StoredProcedure [dbo].[DBoard_WorkLoadSummary]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_WorkLoadSummary] @mPIC varchar(30)

AS

/*WORKLOAD SUMMARY*/
SELECT [PROJECT] AS [PROJECT],
COUNT([STATUS]) AS [REGISTERED VOLUME],
SUM(CASE WHEN [STATUS]='Done' THEN 1 ELSE 0 END) AS  [COMPLETED VOLUME],
SUM(CASE WHEN [STATUS]='In-Process' THEN 1 ELSE 0 END) AS  [IN PROCESS],
SUM(CASE WHEN [STATUS]='Fresh' THEN 1 ELSE 0 END) AS  [FRESH],
SUM(CASE WHEN [STATUS]='Hold' THEN 1 ELSE 0 END) AS  [HOLD]
FROM (

	SELECT PROJECT, [JOB CODE], [FILE NAME],
	CASE WHEN ([IN-PROCESS COUNT]>=1 AND [HOLD COUNT]=0) THEN ('In-Process') ELSE (CASE WHEN ([HOLD COUNT]>=1 AND [IN-PROCESS COUNT]=0) THEN ('Hold') ELSE (CASE WHEN ([TASK COUNT]=[DONE COUNT]) THEN ('Done') ELSE (CASE WHEN ([DONE COUNT] != 0 AND [TASK COUNT]=([DONE COUNT]+[FRESH COUNT])) THEN ('In-Process') ELSE (CASE WHEN ([TASK COUNT]=[FRESH COUNT]) THEN ('Fresh') END) END) END) END) END AS  [STATUS]
	FROM(
		SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], pd.PCP_File AS [FILE NAME], COUNT(pd.PCP_Status) AS [TASK COUNT], 
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=0 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [FRESH COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=2 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [IN-PROCESS COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=3 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [DONE COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=1 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [HOLD COUNT]
		FROM tbl_PCPDetail pd
		INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
		WHERE pch.PIC_UID=@mPIC
		GROUP BY pd.PCP_Project, pd.PCP_ID, pd.PCP_File
	) WLResource

)WLSummary
GROUP BY [PROJECT];


--SELECT pch.PIC_Project AS [PROJECT],
--COUNT(pd.PCP_Status) AS [REGISTERED VOLUME],
--SUM(CASE WHEN pd.PCP_Status=3 THEN 1 ELSE 0 END) AS  [COMPLETED VOLUME],
--SUM(CASE WHEN pd.PCP_Status=2 THEN 1 ELSE 0 END) AS  [IN PROCESS],
--SUM(CASE WHEN pd.PCP_Status=0 THEN 1 ELSE 0 END) AS  [FRESH],
--SUM(CASE WHEN pd.PCP_Status=1 THEN 1 ELSE 0 END) AS  [HOLD]
--FROM tbl_PCPDetail pd
--INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
--WHERE pch.PIC_UID=@mPIC
--GROUP BY pch.PIC_Project;

GO
/****** Object:  StoredProcedure [dbo].[DBoard_WorkLoadSummary_FilterByProject]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_WorkLoadSummary_FilterByProject] @mPIC varchar(30), @mProject varchar(150)

AS

/*WORKLOAD SUMMARY BY PROJECT*/
SELECT [PROJECT] AS [PROJECT],
COUNT([STATUS]) AS [REGISTERED VOLUME],
SUM(CASE WHEN [STATUS]='Done' THEN 1 ELSE 0 END) AS  [COMPLETED VOLUME],
SUM(CASE WHEN [STATUS]='In-Process' THEN 1 ELSE 0 END) AS  [IN PROCESS],
SUM(CASE WHEN [STATUS]='Fresh' THEN 1 ELSE 0 END) AS  [FRESH],
SUM(CASE WHEN [STATUS]='Hold' THEN 1 ELSE 0 END) AS  [HOLD]
FROM (

	SELECT PROJECT, [JOB CODE], [FILE NAME],
	CASE WHEN ([IN-PROCESS COUNT]>=1 AND [HOLD COUNT]=0) THEN ('In-Process') ELSE (CASE WHEN ([HOLD COUNT]>=1 AND [IN-PROCESS COUNT]=0) THEN ('Hold') ELSE (CASE WHEN ([TASK COUNT]=[DONE COUNT]) THEN ('Done') ELSE (CASE WHEN ([DONE COUNT] != 0 AND [TASK COUNT]=([DONE COUNT]+[FRESH COUNT])) THEN ('In-Process') ELSE (CASE WHEN ([TASK COUNT]=[FRESH COUNT]) THEN ('Fresh') END) END) END) END) END AS  [STATUS]
	FROM(
		SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], pd.PCP_File AS [FILE NAME], COUNT(pd.PCP_Status) AS [TASK COUNT], 
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=0 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [FRESH COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=2 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [IN-PROCESS COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=3 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [DONE COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=1 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [HOLD COUNT]
		FROM tbl_PCPDetail pd
		INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
		WHERE pch.PIC_UID=@mPIC AND pch.PIC_Project=@mProject
		GROUP BY pd.PCP_Project, pd.PCP_ID, pd.PCP_File
	) WLResource

)WLSummary
GROUP BY [PROJECT];

--SELECT pch.PIC_Project AS [PROJECT],
--COUNT(pd.PCP_Status) AS [REGISTERED VOLUME],
--SUM(CASE WHEN pd.PCP_Status=3 THEN 1 ELSE 0 END) AS  [COMPLETED VOLUME],
--SUM(CASE WHEN pd.PCP_Status=2 THEN 1 ELSE 0 END) AS  [IN PROCESS],
--SUM(CASE WHEN pd.PCP_Status=0 THEN 1 ELSE 0 END) AS  [FRESH],
--SUM(CASE WHEN pd.PCP_Status=1 THEN 1 ELSE 0 END) AS  [HOLD]
--FROM tbl_PCPDetail pd
--INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
--WHERE pch.PIC_UID=@mPIC AND pch.PIC_Project=@mProject
--GROUP BY pch.PIC_Project;

GO
/****** Object:  StoredProcedure [dbo].[DBoard_WorkLoadSummary_FilterByProjectAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_WorkLoadSummary_FilterByProjectAndManager] @mPIC varchar(30), @mProject varchar(150), @mMUID varchar(30)

AS

/*WORKLOAD SUMMARY BY PROJECT*/
SELECT [PROJECT] AS [PROJECT],
COUNT([STATUS]) AS [REGISTERED VOLUME],
SUM(CASE WHEN [STATUS]='Done' THEN 1 ELSE 0 END) AS  [COMPLETED VOLUME],
SUM(CASE WHEN [STATUS]='In-Process' THEN 1 ELSE 0 END) AS  [IN PROCESS],
SUM(CASE WHEN [STATUS]='Fresh' THEN 1 ELSE 0 END) AS  [FRESH],
SUM(CASE WHEN [STATUS]='Hold' THEN 1 ELSE 0 END) AS  [HOLD]
FROM (

	SELECT PROJECT, [JOB CODE], [FILE NAME],
	CASE WHEN ([IN-PROCESS COUNT]>=1 AND [HOLD COUNT]=0) THEN ('In-Process') ELSE (CASE WHEN ([HOLD COUNT]>=1 AND [IN-PROCESS COUNT]=0) THEN ('Hold') ELSE (CASE WHEN ([TASK COUNT]=[DONE COUNT]) THEN ('Done') ELSE (CASE WHEN ([DONE COUNT] != 0 AND [TASK COUNT]=([DONE COUNT]+[FRESH COUNT])) THEN ('In-Process') ELSE (CASE WHEN ([TASK COUNT]=[FRESH COUNT]) THEN ('Fresh') END) END) END) END) END AS  [STATUS]
	FROM(
		SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], pd.PCP_File AS [FILE NAME], COUNT(pd.PCP_Status) AS [TASK COUNT], 
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=0 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [FRESH COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=2 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [IN-PROCESS COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=3 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [DONE COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=1 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [HOLD COUNT]
		FROM tbl_PCPDetail pd
		INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
		INNER JOIN tbl_ManagerDetail md ON pd.PCP_Project=md.M_Project AND md.M_Project_Availability='Active'
		WHERE pch.PIC_UID=@mPIC AND md.M_UID=@mMUID AND pch.PIC_Project=@mProject
		GROUP BY pd.PCP_Project, pd.PCP_ID, pd.PCP_File
	) WLResource

)WLSummary
GROUP BY [PROJECT];

GO
/****** Object:  StoredProcedure [dbo].[DBoard_WorkLoadSummaryByManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_WorkLoadSummaryByManager] @mPIC varchar(30), @mMUID varchar(30)

AS

/*WORKLOAD SUMMARY*/
SELECT [PROJECT] AS [PROJECT],
COUNT([STATUS]) AS [REGISTERED VOLUME],
SUM(CASE WHEN [STATUS]='Done' THEN 1 ELSE 0 END) AS  [COMPLETED VOLUME],
SUM(CASE WHEN [STATUS]='In-Process' THEN 1 ELSE 0 END) AS  [IN PROCESS],
SUM(CASE WHEN [STATUS]='Fresh' THEN 1 ELSE 0 END) AS  [FRESH],
SUM(CASE WHEN [STATUS]='Hold' THEN 1 ELSE 0 END) AS  [HOLD]
FROM (

	SELECT PROJECT, [JOB CODE], [FILE NAME],
	CASE WHEN ([IN-PROCESS COUNT]>=1 AND [HOLD COUNT]=0) THEN ('In-Process') ELSE (CASE WHEN ([HOLD COUNT]>=1 AND [IN-PROCESS COUNT]=0) THEN ('Hold') ELSE (CASE WHEN ([TASK COUNT]=[DONE COUNT]) THEN ('Done') ELSE (CASE WHEN ([DONE COUNT] != 0 AND [TASK COUNT]=([DONE COUNT]+[FRESH COUNT])) THEN ('In-Process') ELSE (CASE WHEN ([TASK COUNT]=[FRESH COUNT]) THEN ('Fresh') END) END) END) END) END AS  [STATUS]
	FROM(
		SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], pd.PCP_File AS [FILE NAME], COUNT(pd.PCP_Status) AS [TASK COUNT], 
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=0 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [FRESH COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=2 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [IN-PROCESS COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=3 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [DONE COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=1 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [HOLD COUNT]
		FROM tbl_PCPDetail pd
		INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
		INNER JOIN tbl_ManagerDetail md ON pd.PCP_Project=md.M_Project AND md.M_Project_Availability='Active'
		WHERE pch.PIC_UID=@mPIC AND md.M_UID=@mMUID
		GROUP BY pd.PCP_Project, pd.PCP_ID, pd.PCP_File
	) WLResource

)WLSummary
GROUP BY [PROJECT];

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byProject_Ranked]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[DBoard_X3byProject_Ranked] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime

AS

/* MONTHLY X3 PROJECT */
SELECT [PCP_Project] AS [PROJECT]
	--,SUM([USER_OUTPUT]) AS [USER OUTPUT]
    --,SUM([ACTUAL_OUTPUT]) AS [OUTPUT]
	--,ROUND(SUM([WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([ACTUAL_WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([APPROVED_IDLE]),2) AS [APPROVED IDLE]
      ,ROUND(SUM([SUM_OF_X1]),2) AS [X1]
      ,ROUND(SUM([Y]),2) AS [Y]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
	  ,RANK() OVER (ORDER BY ((SUM([SUM_OF_X1])/SUM([Y])) * 100) DESC) AS [RANK]
FROM tbl_Report_TempDailyX3Project
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC
GROUP BY [PCP_Project]
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

--/* Wokred Shift for 9 hours */
--DECLARE @K int;

--SET @K= 32400;

--DECLARE @TemptblDifference_@mPIC TABLE(
--RowNumber bigint,
--TR_Index bigint,
--WORKDATE Date,
--TR_ID nvarchar(100),
--TR_UID nvarchar(50), 
--TR_InDate DateTime,
--TR_OutDate DateTime,
--TR_Status int,
--TR_Apporval int,
--TR_MID nvarchar(50),
--TR_PIC nvarchar(50),
--TR_Shipment nvarchar(100),
--TR_File nvarchar(100),
--ACTUAL_OUTPUT float,
--WORKED_HOURS float,
--QUOTA float, 
--TR_UOM nvarchar(50), 
--PCP_ID nvarchar(50),
--Task_ID nvarchar(50),
--PC_ProcessCode nvarchar(50), 
--PCP_Project nvarchar(50)
--); 

--DECLARE @TemptaskDetails_@mPIC TABLE(
--RowNumber bigint,
--TR_Index bigint,
--WORKDATE Date,
--TR_ID nvarchar(100),
--TR_UID nvarchar(50), 
--TR_InDate DateTime,
--TR_OutDate DateTime,
--WORKED_HOURS float, 
--WASTE_HOURS float,
--X1 float,
--HRS_WASTE float,
--TR_Status int,
--TR_Apporval int,
--TR_MID nvarchar(50),
--TR_PIC nvarchar(50),
--TR_Shipment nvarchar(100),
--TR_File nvarchar(100),
--ACTUAL_OUTPUT float,
--QUOTA float, 
--TR_UOM nvarchar(50), 
--PCP_ID nvarchar(50),
--Task_ID nvarchar(50),
--PC_ProcessCode nvarchar(50), 
--PCP_Project nvarchar(50)
--); 

--DECLARE @TempidleDetails_@mPIC TABLE(
--IDLE_Index bigint,
--WORKDATE Date,
--IDLE_ID nvarchar(100),
--IDLE_UID nvarchar(50), 
--IDLE_InDate DateTime,
--IDLE_OutDate DateTime,
--IDLE_TIME float, 
--IDLE_Reason nvarchar(200),
--IDLE_MID nvarchar(50), 
--IDLE_PIC nvarchar(50), 
--IDLE_Project nvarchar(50)
--);

--INSERT INTO @TemptblDifference_@mPIC 
--	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ISNULL(CAST(d.TR_FileSize AS float),0) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ISNULL(CAST(d.TR_Quota AS float),0) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
--    FROM tbl_TaskRecordDetail d
--	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
--	WHERE d.TR_InDate BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC
--	ORDER BY d.TR_UID

--INSERT INTO @TemptaskDetails_@mPIC 
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST((cur.TR_InDate - previous.TR_OutDate) AS float),0) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + ISNULL(CAST((cur.TR_OutDate - cur.TR_InDate) AS float),0)) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)

--INSERT INTO @TempidleDetails_@mPIC 
--	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
--	FROM tbl_IDLEDetail i
--	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
--	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC
--;
--WITH approveDoneRecords AS(
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.[WORKED_HOURS], cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--),
--sumOfTapproveDoneRecords AS(
--	SELECT TOP (999999999999999999) CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.PCP_Project, SUM(cur.WORKED_HOURS) AS [WORKED_HOURS]
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.PCP_Project
--	ORDER BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.PCP_Project
--),
--sumOfTaskGap_WasteOurs AS(
--	SELECT CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.PCP_Project, ISNULL(SUM(CAST(cur.TR_InDate - previous.TR_OutDate AS float)), 0) AS [WASTE_HOURS]
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.PCP_Project
--),
--sumOfidleDetails AS (
--	SELECT TOP (999999999999999999) [WORKDATE], IDLE_UID, IDLE_Project, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
--	FROM @TempidleDetails_@mPIC 
--	GROUP BY [WORKDATE], IDLE_UID, IDLE_Project
--	ORDER BY [WORKDATE], IDLE_UID, IDLE_Project
--),

--X1 AS (
--	SELECT TOP (999999999999999999) WORKDATE, TR_UID, PCP_Project, SUM(ACTUAL_OUTPUT) AS [OUTPUT], SUM(X1) AS [X1]
--	FROM @TemptaskDetails_@mPIC
--	GROUP BY WORKDATE, TR_UID, PCP_Project
--	ORDER BY WORKDATE, TR_UID, PCP_Project
--),

--Y AS (
--	SELECT TOP (999999999999999999) WK.WORKDATE, WK.TR_UID, WK.PCP_Project,(ISNULL(WK.WORKED_HOURS,0)) AS [WORK_HOURS],(ISNULL(WK.WORKED_HOURS,0) + ISNULL(WHGAP.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
--	FROM sumOfTapproveDoneRecords WK
--	LEFT JOIN sumOfidleDetails IDLE ON WK.TR_UID =IDLE.IDLE_UID AND WK.WORKDATE = IDLE.WORKDATE AND WK.PCP_Project=IDLE.IDLE_Project
--	LEFT JOIN sumOfTaskGap_WasteOurs WHGAP ON  WK.TR_UID = WHGAP.TR_UID AND WK.WORKDATE = WHGAP.WORKDATE AND WHGAP.PCP_Project=WK.PCP_Project
--),
--X3 AS (
--	SELECT TOP (999999999999999999) X.TR_UID, X.PCP_Project, X.WORKDATE, [OUTPUT], X1, [WORK_HOURS], (X.X1/CASE SIGN(ISNULL(Y1.Y,1)) WHEN -1 THEN 1 ELSE (ISNULL(Y1.Y,1)) END)*100 AS [X3]
--	FROM Y Y1
--	LEFT JOIN X1 X ON X.TR_UID =Y1.TR_UID AND X.WORKDATE = Y1.WORKDATE AND X.PCP_Project= Y1.PCP_Project
--)

--SELECT PCP_Project AS [POJECT],  ROUND(SUM(X3),3) AS [X3] 
--FROM X3 WITH (NOLOCK)
--GROUP BY PCP_Project
--ORDER BY X3 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byProject_Ranked_Chart]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byProject_Ranked_Chart] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime

AS

SELECT PCP_Project AS [PROJECT]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
FROM tbl_Report_TempDailyX3Project
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC
GROUP BY PCP_Project
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byProject_Ranked_FilterByProject]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byProject_Ranked_FilterByProject] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mProject nvarchar(50)

AS

/* MONTHLY X3 PROJECT */
SELECT [PCP_Project] AS [PROJECT]
	--,SUM([USER_OUTPUT]) AS [USER OUTPUT]
    --,SUM([ACTUAL_OUTPUT]) AS [OUTPUT]
	--,ROUND(SUM([WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([ACTUAL_WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([APPROVED_IDLE]),2) AS [APPROVED IDLE]
      ,ROUND(SUM([SUM_OF_X1]),2) AS [X1]
      ,ROUND(SUM([Y]),2) AS [Y]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
	  ,RANK() OVER (ORDER BY ((SUM([SUM_OF_X1])/SUM([Y])) * 100) DESC) AS [RANK]
FROM tbl_Report_TempDailyX3Project
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND PCP_Project=@mProject
GROUP BY [PCP_Project]
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byProject_Ranked_FilterByProjectAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byProject_Ranked_FilterByProjectAndManager] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mProject nvarchar(50), @mMUID nvarchar(20)

AS

/* MONTHLY X3 PROJECT */
SELECT [PCP_Project] AS [PROJECT]
	--,SUM([USER_OUTPUT]) AS [USER OUTPUT]
    --,SUM([ACTUAL_OUTPUT]) AS [OUTPUT]
	--,ROUND(SUM([WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([ACTUAL_WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([APPROVED_IDLE]),2) AS [APPROVED IDLE]
      ,ROUND(SUM([SUM_OF_X1]),2) AS [X1]
      ,ROUND(SUM([Y]),2) AS [Y]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
	  ,RANK() OVER (ORDER BY ((SUM([SUM_OF_X1])/SUM([Y])) * 100) DESC) AS [RANK]
FROM tbl_Report_TempDailyX3Project
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND TR_MID=@mMUID AND PCP_Project=@mProject
GROUP BY [PCP_Project]
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byProject_RankedAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byProject_RankedAndManager] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mMUID nvarchar(20)

AS

/* MONTHLY X3 PROJECT */
SELECT [PCP_Project] AS [PROJECT]
	--,SUM([USER_OUTPUT]) AS [USER OUTPUT]
    --,SUM([ACTUAL_OUTPUT]) AS [OUTPUT]
	--,ROUND(SUM([WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([ACTUAL_WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([APPROVED_IDLE]),2) AS [APPROVED IDLE]
      ,ROUND(SUM([SUM_OF_X1]),2) AS [X1]
      ,ROUND(SUM([Y]),2) AS [Y]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
	  ,RANK() OVER (ORDER BY ((SUM([SUM_OF_X1])/SUM([Y])) * 100) DESC) AS [RANK]
FROM tbl_Report_TempDailyX3Project
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND TR_MID=@mMUID
GROUP BY [PCP_Project]
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byProject_RankedByManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byProject_RankedByManager] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mMID nvarchar(20)

AS

SELECT PCP_Project AS [PROJECT]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
FROM tbl_Report_TempDailyX3Project
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND TR_MID=@mMID
GROUP BY PCP_Project
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

--/* Wokred Shift for 9 hours */
--DECLARE @K int;

--SET @K= 32400;

--DECLARE @TemptblDifference_@mPIC TABLE(
--RowNumber bigint,
--TR_Index bigint,
--WORKDATE Date,
--TR_ID nvarchar(100),
--TR_UID nvarchar(50), 
--TR_InDate DateTime,
--TR_OutDate DateTime,
--TR_Status int,
--TR_Apporval int,
--TR_MID nvarchar(50),
--TR_PIC nvarchar(50),
--TR_Shipment nvarchar(100),
--TR_File nvarchar(100),
--ACTUAL_OUTPUT float,
--WORKED_HOURS float,
--QUOTA float, 
--TR_UOM nvarchar(50), 
--PCP_ID nvarchar(50),
--Task_ID nvarchar(50),
--PC_ProcessCode nvarchar(50), 
--PCP_Project nvarchar(50)
--); 

--DECLARE @TemptaskDetails_@mPIC TABLE(
--RowNumber bigint,
--TR_Index bigint,
--WORKDATE Date,
--TR_ID nvarchar(100),
--TR_UID nvarchar(50), 
--TR_InDate DateTime,
--TR_OutDate DateTime,
--WORKED_HOURS float, 
--WASTE_HOURS float,
--X1 float,
--HRS_WASTE float,
--TR_Status int,
--TR_Apporval int,
--TR_MID nvarchar(50),
--TR_PIC nvarchar(50),
--TR_Shipment nvarchar(100),
--TR_File nvarchar(100),
--ACTUAL_OUTPUT float,
--QUOTA float, 
--TR_UOM nvarchar(50), 
--PCP_ID nvarchar(50),
--Task_ID nvarchar(50),
--PC_ProcessCode nvarchar(50), 
--PCP_Project nvarchar(50)
--); 

--DECLARE @TempidleDetails_@mPIC TABLE(
--IDLE_Index bigint,
--WORKDATE Date,
--IDLE_ID nvarchar(100),
--IDLE_UID nvarchar(50), 
--IDLE_InDate DateTime,
--IDLE_OutDate DateTime,
--IDLE_TIME float, 
--IDLE_Reason nvarchar(200),
--IDLE_MID nvarchar(50), 
--IDLE_PIC nvarchar(50), 
--IDLE_Project nvarchar(50)
--);

--INSERT INTO @TemptblDifference_@mPIC 
--	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ISNULL(CAST(d.TR_FileSize AS float),0) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ISNULL(CAST(d.TR_Quota AS float),0) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
--    FROM tbl_TaskRecordDetail d
--	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
--	WHERE d.TR_InDate BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC
--	ORDER BY d.TR_UID

--INSERT INTO @TemptaskDetails_@mPIC 
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST((cur.TR_InDate - previous.TR_OutDate) AS float),0) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + ISNULL(CAST((cur.TR_OutDate - cur.TR_InDate) AS float),0)) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)

--INSERT INTO @TempidleDetails_@mPIC 
--	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
--	FROM tbl_IDLEDetail i
--	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
--	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC
--;
--WITH approveDoneRecords AS(
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.[WORKED_HOURS], cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--),
--sumOfTapproveDoneRecords AS(
--	SELECT TOP (999999999999999999) CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID, cur.PCP_Project, SUM(cur.WORKED_HOURS) AS [WORKED_HOURS]
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID, cur.PCP_Project
--	ORDER BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID, cur.PCP_Project
--),
--sumOfTaskGap_WasteOurs AS(
--	SELECT CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID, cur.PCP_Project, ISNULL(SUM(CAST(cur.TR_InDate - previous.TR_OutDate AS float)), 0) AS [WASTE_HOURS]
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID, cur.PCP_Project
--),
--sumOfidleDetails AS (
--	SELECT TOP (999999999999999999) [WORKDATE], IDLE_UID, IDLE_MID, IDLE_Project, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
--	FROM @TempidleDetails_@mPIC 
--	GROUP BY [WORKDATE], IDLE_UID, IDLE_MID, IDLE_Project
--	ORDER BY [WORKDATE], IDLE_UID, IDLE_MID, IDLE_Project
--),

--X1 AS (
--	SELECT TOP (999999999999999999) WORKDATE, TR_UID, TR_MID, PCP_Project, SUM(ACTUAL_OUTPUT) AS [OUTPUT], SUM(X1) AS [X1]
--	FROM @TemptaskDetails_@mPIC
--	GROUP BY WORKDATE, TR_UID, TR_MID, PCP_Project
--	ORDER BY WORKDATE, TR_UID, TR_MID, PCP_Project
--),

--Y AS (
--	SELECT TOP (999999999999999999) WK.WORKDATE, WK.TR_UID, WK.TR_MID, WK.PCP_Project,(ISNULL(WK.WORKED_HOURS,0)) AS [WORK_HOURS],(ISNULL(WK.WORKED_HOURS,0) + ISNULL(WHGAP.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
--	FROM sumOfTapproveDoneRecords WK
--	LEFT JOIN sumOfidleDetails IDLE ON WK.TR_UID =IDLE.IDLE_UID AND WK.WORKDATE = IDLE.WORKDATE AND WK.PCP_Project=IDLE.IDLE_Project
--	LEFT JOIN sumOfTaskGap_WasteOurs WHGAP ON  WK.TR_UID = WHGAP.TR_UID AND WK.WORKDATE = WHGAP.WORKDATE AND WHGAP.PCP_Project=WK.PCP_Project
--),
--X3 AS (
--	SELECT TOP (999999999999999999) X.TR_UID, X.TR_MID, X.PCP_Project, X.WORKDATE, [OUTPUT], X1, [WORK_HOURS], (X.X1/CASE SIGN(ISNULL(Y1.Y,1)) WHEN -1 THEN 1 ELSE (ISNULL(Y1.Y,1)) END )*100 AS [X3]
--	FROM Y Y1
--	LEFT JOIN X1 X ON X.TR_UID =Y1.TR_UID AND X.WORKDATE = Y1.WORKDATE AND X.PCP_Project= Y1.PCP_Project
--)

--SELECT PCP_Project AS [POJECT],  ROUND(SUM(X3),3) AS [X3] 
--FROM X3 WITH (NOLOCK)
--WHERE TR_MID=@mMID
--GROUP BY PCP_Project
--ORDER BY X3 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byProject_RankedBYProject]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byProject_RankedBYProject] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mProject nvarchar(20)

AS

SELECT PCP_Project AS [PROJECT]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
FROM tbl_Report_TempDailyX3Project
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND PCP_Project=@mProject
GROUP BY PCP_Project
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

--/* Wokred Shift for 9 hours */
--DECLARE @K int;

--SET @K= 32400;

--DECLARE @TemptblDifference_@mPIC TABLE(
--RowNumber bigint,
--TR_Index bigint,
--WORKDATE Date,
--TR_ID nvarchar(100),
--TR_UID nvarchar(50), 
--TR_InDate DateTime,
--TR_OutDate DateTime,
--TR_Status int,
--TR_Apporval int,
--TR_MID nvarchar(50),
--TR_PIC nvarchar(50),
--TR_Shipment nvarchar(100),
--TR_File nvarchar(100),
--ACTUAL_OUTPUT float,
--WORKED_HOURS float,
--QUOTA float, 
--TR_UOM nvarchar(50), 
--PCP_ID nvarchar(50),
--Task_ID nvarchar(50),
--PC_ProcessCode nvarchar(50), 
--PCP_Project nvarchar(50)
--); 

--DECLARE @TemptaskDetails_@mPIC TABLE(
--RowNumber bigint,
--TR_Index bigint,
--WORKDATE Date,
--TR_ID nvarchar(100),
--TR_UID nvarchar(50), 
--TR_InDate DateTime,
--TR_OutDate DateTime,
--WORKED_HOURS float, 
--WASTE_HOURS float,
--X1 float,
--HRS_WASTE float,
--TR_Status int,
--TR_Apporval int,
--TR_MID nvarchar(50),
--TR_PIC nvarchar(50),
--TR_Shipment nvarchar(100),
--TR_File nvarchar(100),
--ACTUAL_OUTPUT float,
--QUOTA float, 
--TR_UOM nvarchar(50), 
--PCP_ID nvarchar(50),
--Task_ID nvarchar(50),
--PC_ProcessCode nvarchar(50), 
--PCP_Project nvarchar(50)
--); 

--DECLARE @TempidleDetails_@mPIC TABLE(
--IDLE_Index bigint,
--WORKDATE Date,
--IDLE_ID nvarchar(100),
--IDLE_UID nvarchar(50), 
--IDLE_InDate DateTime,
--IDLE_OutDate DateTime,
--IDLE_TIME float, 
--IDLE_Reason nvarchar(200),
--IDLE_MID nvarchar(50), 
--IDLE_PIC nvarchar(50), 
--IDLE_Project nvarchar(50)
--);

--INSERT INTO @TemptblDifference_@mPIC 
--	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ISNULL(CAST(d.TR_FileSize AS float),0) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ISNULL(CAST(d.TR_Quota AS float),0) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
--    FROM tbl_TaskRecordDetail d
--	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
--	WHERE d.TR_InDate BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC
--	ORDER BY d.TR_UID

--INSERT INTO @TemptaskDetails_@mPIC 
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST((cur.TR_InDate - previous.TR_OutDate) AS float),0) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + ISNULL(CAST((cur.TR_OutDate - cur.TR_InDate) AS float),0)) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)

--INSERT INTO @TempidleDetails_@mPIC 
--	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
--	FROM tbl_IDLEDetail i
--	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
--	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC
--;
--WITH approveDoneRecords AS(
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.[WORKED_HOURS], cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--),
--sumOfTapproveDoneRecords AS(
--	SELECT TOP (999999999999999999) CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.PCP_Project, SUM(cur.WORKED_HOURS) AS [WORKED_HOURS]
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.PCP_Project
--	ORDER BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.PCP_Project
--),
--sumOfTaskGap_WasteOurs AS(
--	SELECT CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.PCP_Project, ISNULL(SUM(CAST(cur.TR_InDate - previous.TR_OutDate AS float)), 0) AS [WASTE_HOURS]
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.PCP_Project
--),
--sumOfidleDetails AS (
--	SELECT TOP (999999999999999999) [WORKDATE], IDLE_UID, IDLE_Project, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
--	FROM @TempidleDetails_@mPIC 
--	GROUP BY [WORKDATE], IDLE_UID, IDLE_Project
--	ORDER BY [WORKDATE], IDLE_UID, IDLE_Project
--),

--X1 AS (
--	SELECT TOP (999999999999999999) WORKDATE, TR_UID, PCP_Project, SUM(ACTUAL_OUTPUT) AS [OUTPUT], SUM(X1) AS [X1]
--	FROM @TemptaskDetails_@mPIC
--	GROUP BY WORKDATE, TR_UID, PCP_Project
--	ORDER BY WORKDATE, TR_UID, PCP_Project
--),

--Y AS (
--	SELECT TOP (999999999999999999) WK.WORKDATE, WK.TR_UID, WK.PCP_Project,(ISNULL(WK.WORKED_HOURS,0)) AS [WORK_HOURS],(ISNULL(WK.WORKED_HOURS,0) + ISNULL(WHGAP.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
--	FROM sumOfTapproveDoneRecords WK
--	LEFT JOIN sumOfidleDetails IDLE ON WK.TR_UID =IDLE.IDLE_UID AND WK.WORKDATE = IDLE.WORKDATE AND WK.PCP_Project=IDLE.IDLE_Project
--	LEFT JOIN sumOfTaskGap_WasteOurs WHGAP ON  WK.TR_UID = WHGAP.TR_UID AND WK.WORKDATE = WHGAP.WORKDATE AND WHGAP.PCP_Project=WK.PCP_Project
--),
--X3 AS (
--	SELECT TOP (999999999999999999) X.TR_UID, X.PCP_Project, X.WORKDATE, [OUTPUT], X1, [WORK_HOURS], (X.X1/CASE SIGN(ISNULL(Y1.Y,1)) WHEN -1 THEN 1 ELSE (ISNULL(Y1.Y,1)) END)*100 AS [X3]
--	FROM Y Y1
--	LEFT JOIN X1 X ON X.TR_UID =Y1.TR_UID AND X.WORKDATE = Y1.WORKDATE AND X.PCP_Project= Y1.PCP_Project
--)

--SELECT PCP_Project AS [POJECT],  ROUND(SUM(X3),3) AS [X3] 
--FROM X3 WITH (NOLOCK)
--WHERE PCP_Project=@mProject
--GROUP BY PCP_Project
--ORDER BY X3 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byProject_RankedByProjectAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byProject_RankedByProjectAndManager] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mProject nvarchar(20), @mMUID nvarchar(20)

AS

SELECT PCP_Project AS [PROJECT]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
FROM tbl_Report_TempDailyX3Project
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND PCP_Project=@mProject AND TR_MID=@mMUID
GROUP BY PCP_Project
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byProject_RankedByUID]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byProject_RankedByUID] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mUID nvarchar(20)

AS

SELECT PCP_Project AS [PROJECT]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
FROM tbl_Report_TempDailyX3Project
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND TR_UID=@mUID
GROUP BY PCP_Project
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

--/* Wokred Shift for 9 hours */
--DECLARE @K int;

--SET @K= 32400;

--DECLARE @TemptblDifference_@mPIC TABLE(
--RowNumber bigint,
--TR_Index bigint,
--WORKDATE Date,
--TR_ID nvarchar(100),
--TR_UID nvarchar(50), 
--TR_InDate DateTime,
--TR_OutDate DateTime,
--TR_Status int,
--TR_Apporval int,
--TR_MID nvarchar(50),
--TR_PIC nvarchar(50),
--TR_Shipment nvarchar(100),
--TR_File nvarchar(100),
--ACTUAL_OUTPUT float,
--WORKED_HOURS float,
--QUOTA float, 
--TR_UOM nvarchar(50), 
--PCP_ID nvarchar(50),
--Task_ID nvarchar(50),
--PC_ProcessCode nvarchar(50), 
--PCP_Project nvarchar(50)
--); 

--DECLARE @TemptaskDetails_@mPIC TABLE(
--RowNumber bigint,
--TR_Index bigint,
--WORKDATE Date,
--TR_ID nvarchar(100),
--TR_UID nvarchar(50), 
--TR_InDate DateTime,
--TR_OutDate DateTime,
--WORKED_HOURS float, 
--WASTE_HOURS float,
--X1 float,
--HRS_WASTE float,
--TR_Status int,
--TR_Apporval int,
--TR_MID nvarchar(50),
--TR_PIC nvarchar(50),
--TR_Shipment nvarchar(100),
--TR_File nvarchar(100),
--ACTUAL_OUTPUT float,
--QUOTA float, 
--TR_UOM nvarchar(50), 
--PCP_ID nvarchar(50),
--Task_ID nvarchar(50),
--PC_ProcessCode nvarchar(50), 
--PCP_Project nvarchar(50)
--); 

--DECLARE @TempidleDetails_@mPIC TABLE(
--IDLE_Index bigint,
--WORKDATE Date,
--IDLE_ID nvarchar(100),
--IDLE_UID nvarchar(50), 
--IDLE_InDate DateTime,
--IDLE_OutDate DateTime,
--IDLE_TIME float, 
--IDLE_Reason nvarchar(200),
--IDLE_MID nvarchar(50), 
--IDLE_PIC nvarchar(50), 
--IDLE_Project nvarchar(50)
--);

--INSERT INTO @TemptblDifference_@mPIC 
--	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ISNULL(CAST(d.TR_FileSize AS float),0) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ISNULL(CAST(d.TR_Quota AS float),0) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
--    FROM tbl_TaskRecordDetail d
--	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
--	WHERE d.TR_InDate BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC
--	ORDER BY d.TR_UID

--INSERT INTO @TemptaskDetails_@mPIC 
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST((cur.TR_InDate - previous.TR_OutDate) AS float),0) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + ISNULL(CAST((cur.TR_OutDate - cur.TR_InDate) AS float),0)) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)

--INSERT INTO @TempidleDetails_@mPIC 
--	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
--	FROM tbl_IDLEDetail i
--	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
--	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC
--;
--WITH approveDoneRecords AS(
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.[WORKED_HOURS], cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--),
--sumOfTapproveDoneRecords AS(
--	SELECT TOP (999999999999999999) CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.PCP_Project, SUM(cur.WORKED_HOURS) AS [WORKED_HOURS]
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.PCP_Project
--	ORDER BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.PCP_Project
--),
--sumOfTaskGap_WasteOurs AS(
--	SELECT CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.PCP_Project, ISNULL(SUM(CAST(cur.TR_InDate - previous.TR_OutDate AS float)), 0) AS [WASTE_HOURS]
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.PCP_Project
--),
--sumOfidleDetails AS (
--	SELECT TOP (999999999999999999) [WORKDATE], IDLE_UID, IDLE_Project, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
--	FROM @TempidleDetails_@mPIC 
--	GROUP BY [WORKDATE], IDLE_UID, IDLE_Project
--	ORDER BY [WORKDATE], IDLE_UID, IDLE_Project
--),

--X1 AS (
--	SELECT TOP (999999999999999999) WORKDATE, TR_UID, PCP_Project, SUM(ACTUAL_OUTPUT) AS [OUTPUT], SUM(X1) AS [X1]
--	FROM @TemptaskDetails_@mPIC
--	GROUP BY WORKDATE, TR_UID, PCP_Project
--	ORDER BY WORKDATE, TR_UID, PCP_Project
--),

--Y AS (
--	SELECT TOP (999999999999999999) WK.WORKDATE, WK.TR_UID, WK.PCP_Project,(ISNULL(WK.WORKED_HOURS,0)) AS [WORK_HOURS],(ISNULL(WK.WORKED_HOURS,0) + ISNULL(WHGAP.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
--	FROM sumOfTapproveDoneRecords WK
--	LEFT JOIN sumOfidleDetails IDLE ON WK.TR_UID =IDLE.IDLE_UID AND WK.WORKDATE = IDLE.WORKDATE AND WK.PCP_Project=IDLE.IDLE_Project
--	LEFT JOIN sumOfTaskGap_WasteOurs WHGAP ON  WK.TR_UID = WHGAP.TR_UID AND WK.WORKDATE = WHGAP.WORKDATE AND WHGAP.PCP_Project=WK.PCP_Project
--),
--X3 AS (
--	SELECT TOP (999999999999999999) X.TR_UID, X.PCP_Project, X.WORKDATE, [OUTPUT], X1, [WORK_HOURS], (X.X1/CASE SIGN(ISNULL(Y1.Y,1)) WHEN -1 THEN 1 ELSE (ISNULL(Y1.Y,1)) END)*100 AS [X3]
--	FROM Y Y1
--	LEFT JOIN X1 X ON X.TR_UID =Y1.TR_UID AND X.WORKDATE = Y1.WORKDATE AND X.PCP_Project= Y1.PCP_Project
--)

--SELECT PCP_Project AS [POJECT],  ROUND(SUM(X3),3) AS [X3] 
--FROM X3 WITH (NOLOCK)
--WHERE TR_UID=@mUID
--GROUP BY PCP_Project
--ORDER BY X3 DESC
GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byProject_RankedByUIDAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byProject_RankedByUIDAndManager] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mUID nvarchar(20), @mMUID nvarchar(20)

AS

SELECT PCP_Project AS [PROJECT]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
FROM tbl_Report_TempDailyX3Project
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND TR_UID=@mUID AND TR_MID=@mMUID
GROUP BY PCP_Project
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byProject_User]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byProject_User] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime
WITH RECOMPILE
AS
/* Wokred Shift for 9 hours */
DECLARE @K int;

SET @K= 32400;


WITH tblDifference_by_Project AS
(
	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ISNULL(CAST(d.TR_FileSize AS float),0) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ISNULL(CAST(d.TR_Quota AS float),0) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
    FROM tbl_TaskRecordDetail d
	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
	WHERE d.TR_InDate BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC
	ORDER BY d.TR_UID
),
taskDetails_by_Project AS(
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST((cur.TR_InDate - previous.TR_OutDate) AS float),0) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + ISNULL(CAST((cur.TR_OutDate - cur.TR_InDate) AS float),0)) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
	FROM tblDifference_by_Project cur
	LEFT OUTER JOIN tblDifference_by_Project previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
),
idleDetails_by_Project AS (
	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
	FROM tbl_IDLEDetail i
	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC
),
approveDoneRecords_by_Project AS(
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.[WORKED_HOURS], cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project
	FROM tblDifference_by_Project cur
	LEFT OUTER JOIN tblDifference_by_Project previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
),
sumOfTapproveDoneRecords_by_Project AS(
	SELECT TOP (999999999999999999) CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project, cur.TR_UID, SUM(cur.WORKED_HOURS) AS [WORKED_HOURS]
	FROM tblDifference_by_Project cur
	LEFT OUTER JOIN tblDifference_by_Project previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
	GROUP BY CONVERT(date, cur.TR_OutDate), cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project, cur.TR_UID
	ORDER BY CONVERT(date, cur.TR_OutDate), cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project, cur.TR_UID
),
sumOfTaskGap_WasteOurs_by_Project AS(
	SELECT CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project, cur.TR_UID, ISNULL(SUM(CAST(cur.TR_InDate - previous.TR_OutDate AS float)), 0) AS [WASTE_HOURS]
	FROM tblDifference_by_Project cur
	LEFT OUTER JOIN tblDifference_by_Project previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	GROUP BY CONVERT(date, cur.TR_OutDate), cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project, cur.TR_UID
),
sumOfidleDetails_by_Project AS (
	SELECT TOP (999999999999999999) [WORKDATE], IDLE_Project, IDLE_UID, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
	FROM idleDetails_by_Project 
	GROUP BY [WORKDATE], IDLE_Project, IDLE_UID
	ORDER BY [WORKDATE], IDLE_Project, IDLE_UID
),

X1_by_Project AS (
	SELECT TOP (999999999999999999) WORKDATE, Task_ID, PC_ProcessCode, PCP_Project, TR_UID, SUM(ACTUAL_OUTPUT) AS [OUTPUT], SUM(X1) AS [X1]
	FROM taskDetails_by_Project
	GROUP BY WORKDATE,Task_ID, PC_ProcessCode, PCP_Project, TR_UID
	ORDER BY WORKDATE,Task_ID, PC_ProcessCode, PCP_Project, TR_UID
),

Y_by_Project AS (
	SELECT TOP (999999999999999999) WK.WORKDATE, WK.Task_ID, WK.PC_ProcessCode, WK.PCP_Project, WK.TR_UID,(ISNULL(WK.WORKED_HOURS,0)) AS [WORK_HOURS],(ISNULL(WK.WORKED_HOURS,0) + ISNULL(WHGAP.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
	FROM sumOfTapproveDoneRecords_by_Project WK
	LEFT JOIN sumOfidleDetails_by_Project IDLE ON WK.TR_UID =IDLE.IDLE_UID AND WK.WORKDATE = IDLE.WORKDATE AND WK.PCP_Project=IDLE.IDLE_Project
	LEFT JOIN sumOfTaskGap_WasteOurs_by_Project WHGAP ON  WK.TR_UID = WHGAP.TR_UID AND WK.WORKDATE = WHGAP.WORKDATE 
	AND WK.PC_ProcessCode=WHGAP.PC_ProcessCode AND WHGAP.PCP_Project=WK.PCP_Project AND WHGAP.Task_ID=WK.Task_ID
),
X3_by_Project AS (
	SELECT TOP (999999999999999999) X.WORKDATE, X.PCP_Project, X.PC_ProcessCode, X.Task_ID, X.TR_UID,  [OUTPUT], X1, [WORK_HOURS], (X.X1/CASE SIGN(ISNULL(Y1.Y,1)) WHEN -1 THEN 1 ELSE (ISNULL(Y1.Y,1)) END )*100 AS [X3]
	FROM Y_by_Project Y1
	LEFT JOIN X1_by_Project X ON X.TR_UID =Y1.TR_UID AND X.WORKDATE = Y1.WORKDATE AND Y1.PC_ProcessCode=X.PC_ProcessCode AND Y1.PCP_Project=X.PCP_Project AND Y1.Task_ID=X.Task_ID
)


/*Weekly X3 for cluster*/
SELECT X3.PCP_Project AS [PROJECT], X3.PC_ProcessCode AS [ITEM_CODE], X3.Task_ID AS [TASK_ID], T.Task_Description AS [DESCRIPTION], SUM(X3.[OUTPUT]) AS [OUTPUT], ROUND(SUM(X3.X1),2) AS [SUM X1], ROUND(SUM(X3.[WORK_HOURS]),2) AS [WORK HOURS], ROUND(SUM(X3.X3),2) AS [X3]
FROM X3_by_Project X3
INNER JOIN tbl_TaskDetail T ON T.PC_ProcessCode=X3.PC_ProcessCode AND X3.PCP_Project=T.PIC_Project AND X3.Task_ID=T.Task_ID
GROUP BY X3.PCP_Project, X3.PC_ProcessCode, X3.Task_ID, T.Task_Description
ORDER BY X3.PCP_Project, X3.PC_ProcessCode, X3.Task_ID, T.Task_Description DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byProject_User_FilterByManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byProject_User_FilterByManager] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mMID nvarchar(20)
WITH RECOMPILE
AS
/* Wokred Shift for 9 hours */
DECLARE @K int;

SET @K= 32400;


WITH tblDifference_by_Project AS
(
	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ISNULL(CAST(d.TR_FileSize AS float),0) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ISNULL(CAST(d.TR_Quota AS float),0) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
    FROM tbl_TaskRecordDetail d
	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
	WHERE d.TR_InDate BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC AND d.TR_MID=@mMID
	ORDER BY d.TR_UID
),
taskDetails_by_Project AS(
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST((cur.TR_InDate - previous.TR_OutDate) AS float),0) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + ISNULL(CAST((cur.TR_OutDate - cur.TR_InDate) AS float),0)) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
	FROM tblDifference_by_Project cur
	LEFT OUTER JOIN tblDifference_by_Project previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
),
idleDetails_by_Project AS (
	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
	FROM tbl_IDLEDetail i
	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC AND h.IDLE_MID=@mMID
),
approveDoneRecords_by_Project AS(
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.[WORKED_HOURS], cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project
	FROM tblDifference_by_Project cur
	LEFT OUTER JOIN tblDifference_by_Project previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
),
sumOfTapproveDoneRecords_by_Project AS(
	SELECT TOP (999999999999999999) CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project, cur.TR_UID, SUM(cur.WORKED_HOURS) AS [WORKED_HOURS]
	FROM tblDifference_by_Project cur
	LEFT OUTER JOIN tblDifference_by_Project previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
	GROUP BY CONVERT(date, cur.TR_OutDate), cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project, cur.TR_UID
	ORDER BY CONVERT(date, cur.TR_OutDate), cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project, cur.TR_UID
),
sumOfTaskGap_WasteOurs_by_Project AS(
	SELECT CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project, cur.TR_UID, ISNULL(SUM(CAST(cur.TR_InDate - previous.TR_OutDate AS float)), 0) AS [WASTE_HOURS]
	FROM tblDifference_by_Project cur
	LEFT OUTER JOIN tblDifference_by_Project previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	GROUP BY CONVERT(date, cur.TR_OutDate), cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project, cur.TR_UID
),
sumOfidleDetails_by_Project AS (
	SELECT TOP (999999999999999999) [WORKDATE], IDLE_Project, IDLE_UID, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
	FROM idleDetails_by_Project 
	GROUP BY [WORKDATE], IDLE_Project, IDLE_UID
	ORDER BY [WORKDATE], IDLE_Project, IDLE_UID
),

X1_by_Project AS (
	SELECT TOP (999999999999999999) WORKDATE, Task_ID, PC_ProcessCode, PCP_Project, TR_UID, SUM(ACTUAL_OUTPUT) AS [OUTPUT], SUM(X1) AS [X1]
	FROM taskDetails_by_Project
	GROUP BY WORKDATE,Task_ID, PC_ProcessCode, PCP_Project, TR_UID
	ORDER BY WORKDATE,Task_ID, PC_ProcessCode, PCP_Project, TR_UID
),

Y_by_Project AS (
	SELECT TOP (999999999999999999) WK.WORKDATE, WK.Task_ID, WK.PC_ProcessCode, WK.PCP_Project, WK.TR_UID,(ISNULL(WK.WORKED_HOURS,0)) AS [WORK_HOURS],(ISNULL(WK.WORKED_HOURS,0) + ISNULL(WHGAP.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
	FROM sumOfTapproveDoneRecords_by_Project WK
	LEFT JOIN sumOfidleDetails_by_Project IDLE ON WK.TR_UID =IDLE.IDLE_UID AND WK.WORKDATE = IDLE.WORKDATE AND WK.PCP_Project=IDLE.IDLE_Project
	LEFT JOIN sumOfTaskGap_WasteOurs_by_Project WHGAP ON  WK.TR_UID = WHGAP.TR_UID AND WK.WORKDATE = WHGAP.WORKDATE 
	AND WK.PC_ProcessCode=WHGAP.PC_ProcessCode AND WHGAP.PCP_Project=WK.PCP_Project AND WHGAP.Task_ID=WK.Task_ID
),
X3_by_Project AS (
	SELECT TOP (999999999999999999) X.WORKDATE, X.PCP_Project, X.PC_ProcessCode, X.Task_ID, X.TR_UID,  [OUTPUT], X1, [WORK_HOURS], (X.X1/CASE SIGN(ISNULL(Y1.Y,1)) WHEN -1 THEN 1 ELSE (ISNULL(Y1.Y,1)) END)*100 AS [X3]
	FROM Y_by_Project Y1
	LEFT JOIN X1_by_Project X ON X.TR_UID =Y1.TR_UID AND X.WORKDATE = Y1.WORKDATE AND Y1.PC_ProcessCode=X.PC_ProcessCode AND Y1.PCP_Project=X.PCP_Project AND Y1.Task_ID=X.Task_ID
)


/*Weekly X3 for cluster*/
SELECT X3.PCP_Project AS [PROJECT], X3.PC_ProcessCode AS [ITEM_CODE], X3.Task_ID AS [TASK_ID], T.Task_Description AS [DESCRIPTION], SUM(X3.[OUTPUT]) AS [OUTPUT], ROUND(SUM(X3.X1),2) AS [SUM X1], ROUND(SUM(X3.[WORK_HOURS]),2) AS [WORK HOURS], ROUND(SUM(X3.X3),2) AS [X3]
FROM X3_by_Project X3
INNER JOIN tbl_TaskDetail T ON T.PC_ProcessCode=X3.PC_ProcessCode AND X3.PCP_Project=T.PIC_Project AND X3.Task_ID=T.Task_ID
GROUP BY X3.PCP_Project, X3.PC_ProcessCode, X3.Task_ID, T.Task_Description
ORDER BY X3.PCP_Project, X3.PC_ProcessCode, X3.Task_ID, T.Task_Description DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byProject_User_FilterByProject]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byProject_User_FilterByProject] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mProject nvarchar(30)
WITH RECOMPILE
AS
/* Wokred Shift for 9 hours */
DECLARE @K int;

SET @K= 32400;


WITH tblDifference_by_Project AS
(
	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ISNULL(CAST(d.TR_FileSize AS float),0) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ISNULL(CAST(d.TR_Quota AS float),0) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
    FROM tbl_TaskRecordDetail d
	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
	WHERE d.TR_InDate BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC AND p.PCP_Project=@mProject
	ORDER BY d.TR_UID
),
taskDetails_by_Project AS(
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST((cur.TR_InDate - previous.TR_OutDate) AS float),0) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + ISNULL(CAST((cur.TR_OutDate - cur.TR_InDate) AS float),0)) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
	FROM tblDifference_by_Project cur
	LEFT OUTER JOIN tblDifference_by_Project previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
),
idleDetails_by_Project AS (
	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
	FROM tbl_IDLEDetail i
	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC AND h.IDLE_Project=@mProject
),
approveDoneRecords_by_Project AS(
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.[WORKED_HOURS], cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project
	FROM tblDifference_by_Project cur
	LEFT OUTER JOIN tblDifference_by_Project previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
),
sumOfTapproveDoneRecords_by_Project AS(
	SELECT TOP (999999999999999999) CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project, cur.TR_UID, SUM(cur.WORKED_HOURS) AS [WORKED_HOURS]
	FROM tblDifference_by_Project cur
	LEFT OUTER JOIN tblDifference_by_Project previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
	GROUP BY CONVERT(date, cur.TR_OutDate), cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project, cur.TR_UID
	ORDER BY CONVERT(date, cur.TR_OutDate), cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project, cur.TR_UID
),
sumOfTaskGap_WasteOurs_by_Project AS(
	SELECT CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project, cur.TR_UID, ISNULL(SUM(CAST(cur.TR_InDate - previous.TR_OutDate AS float)), 0) AS [WASTE_HOURS]
	FROM tblDifference_by_Project cur
	LEFT OUTER JOIN tblDifference_by_Project previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	GROUP BY CONVERT(date, cur.TR_OutDate), cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project, cur.TR_UID
),
sumOfidleDetails_by_Project AS (
	SELECT TOP (999999999999999999) [WORKDATE], IDLE_Project, IDLE_UID, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
	FROM idleDetails_by_Project 
	GROUP BY [WORKDATE], IDLE_Project, IDLE_UID
	ORDER BY [WORKDATE], IDLE_Project, IDLE_UID
),

X1_by_Project AS (
	SELECT TOP (999999999999999999) WORKDATE, Task_ID, PC_ProcessCode, PCP_Project, TR_UID, SUM(ACTUAL_OUTPUT) AS [OUTPUT], SUM(X1) AS [X1]
	FROM taskDetails_by_Project
	GROUP BY WORKDATE,Task_ID, PC_ProcessCode, PCP_Project, TR_UID
	ORDER BY WORKDATE,Task_ID, PC_ProcessCode, PCP_Project, TR_UID
),

Y_by_Project AS (
	SELECT TOP (999999999999999999) WK.WORKDATE, WK.Task_ID, WK.PC_ProcessCode, WK.PCP_Project, WK.TR_UID,(ISNULL(WK.WORKED_HOURS,0)) AS [WORK_HOURS],(ISNULL(WK.WORKED_HOURS,0) + ISNULL(WHGAP.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
	FROM sumOfTapproveDoneRecords_by_Project WK
	LEFT JOIN sumOfidleDetails_by_Project IDLE ON WK.TR_UID =IDLE.IDLE_UID AND WK.WORKDATE = IDLE.WORKDATE AND WK.PCP_Project=IDLE.IDLE_Project
	LEFT JOIN sumOfTaskGap_WasteOurs_by_Project WHGAP ON  WK.TR_UID = WHGAP.TR_UID AND WK.WORKDATE = WHGAP.WORKDATE 
	AND WK.PC_ProcessCode=WHGAP.PC_ProcessCode AND WHGAP.PCP_Project=WK.PCP_Project AND WHGAP.Task_ID=WK.Task_ID
),
X3_by_Project AS (
	SELECT TOP (999999999999999999) X.WORKDATE, X.PCP_Project, X.PC_ProcessCode, X.Task_ID, X.TR_UID,  [OUTPUT], X1, [WORK_HOURS], (X.X1/CASE SIGN(ISNULL(Y1.Y,1)) WHEN -1 THEN 1 ELSE (ISNULL(Y1.Y,1)) END)*100 AS [X3]
	FROM Y_by_Project Y1
	LEFT JOIN X1_by_Project X ON X.TR_UID =Y1.TR_UID AND X.WORKDATE = Y1.WORKDATE AND Y1.PC_ProcessCode=X.PC_ProcessCode AND Y1.PCP_Project=X.PCP_Project AND Y1.Task_ID=X.Task_ID
)


/*Weekly X3 for cluster*/
SELECT X3.PCP_Project AS [PROJECT], X3.PC_ProcessCode AS [ITEM_CODE], X3.Task_ID AS [TASK_ID], T.Task_Description AS [DESCRIPTION], SUM(X3.[OUTPUT]) AS [OUTPUT], ROUND(SUM(X3.X1),2) AS [SUM X1], ROUND(SUM(X3.[WORK_HOURS]),2) AS [WORK HOURS], ROUND(SUM(X3.X3),2) AS [X3]
FROM X3_by_Project X3
INNER JOIN tbl_TaskDetail T ON T.PC_ProcessCode=X3.PC_ProcessCode AND X3.PCP_Project=T.PIC_Project AND X3.Task_ID=T.Task_ID
GROUP BY X3.PCP_Project, X3.PC_ProcessCode, X3.Task_ID, T.Task_Description
ORDER BY X3.PCP_Project, X3.PC_ProcessCode, X3.Task_ID, T.Task_Description DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byProject_User_FilterByUser]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byProject_User_FilterByUser] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mUID nvarchar(20)
WITH RECOMPILE
AS
/* Wokred Shift for 9 hours */
DECLARE @K int;

SET @K= 32400;


WITH tblDifference_by_Project AS
(
	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ISNULL(CAST(d.TR_FileSize AS float),0) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ISNULL(CAST(d.TR_Quota AS float),0) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
    FROM tbl_TaskRecordDetail d
	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
	WHERE d.TR_InDate BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC AND d.TR_UID=@mUID
	ORDER BY d.TR_UID
),
taskDetails_by_Project AS(
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST((cur.TR_InDate - previous.TR_OutDate) AS float),0) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + ISNULL(CAST((cur.TR_OutDate - cur.TR_InDate) AS float),0)) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
	FROM tblDifference_by_Project cur
	LEFT OUTER JOIN tblDifference_by_Project previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
),
idleDetails_by_Project AS (
	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
	FROM tbl_IDLEDetail i
	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC AND h.IDLE_UID=@mUID
),
approveDoneRecords_by_Project AS(
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.[WORKED_HOURS], cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project
	FROM tblDifference_by_Project cur
	LEFT OUTER JOIN tblDifference_by_Project previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
),
sumOfTapproveDoneRecords_by_Project AS(
	SELECT TOP (999999999999999999) CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project, cur.TR_UID, SUM(cur.WORKED_HOURS) AS [WORKED_HOURS]
	FROM tblDifference_by_Project cur
	LEFT OUTER JOIN tblDifference_by_Project previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
	GROUP BY CONVERT(date, cur.TR_OutDate), cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project, cur.TR_UID
	ORDER BY CONVERT(date, cur.TR_OutDate), cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project, cur.TR_UID
),
sumOfTaskGap_WasteOurs_by_Project AS(
	SELECT CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project, cur.TR_UID, ISNULL(SUM(CAST(cur.TR_InDate - previous.TR_OutDate AS float)), 0) AS [WASTE_HOURS]
	FROM tblDifference_by_Project cur
	LEFT OUTER JOIN tblDifference_by_Project previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	GROUP BY CONVERT(date, cur.TR_OutDate), cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project, cur.TR_UID
),
sumOfidleDetails_by_Project AS (
	SELECT TOP (999999999999999999) [WORKDATE], IDLE_Project, IDLE_UID, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
	FROM idleDetails_by_Project 
	GROUP BY [WORKDATE], IDLE_Project, IDLE_UID
	ORDER BY [WORKDATE], IDLE_Project, IDLE_UID
),

X1_by_Project AS (
	SELECT TOP (999999999999999999) WORKDATE, Task_ID, PC_ProcessCode, PCP_Project, TR_UID, SUM(ACTUAL_OUTPUT) AS [OUTPUT], SUM(X1) AS [X1]
	FROM taskDetails_by_Project
	GROUP BY WORKDATE,Task_ID, PC_ProcessCode, PCP_Project, TR_UID
	ORDER BY WORKDATE,Task_ID, PC_ProcessCode, PCP_Project, TR_UID
),

Y_by_Project AS (
	SELECT TOP (999999999999999999) WK.WORKDATE, WK.Task_ID, WK.PC_ProcessCode, WK.PCP_Project, WK.TR_UID,(ISNULL(WK.WORKED_HOURS,0)) AS [WORK_HOURS],(ISNULL(WK.WORKED_HOURS,0) + ISNULL(WHGAP.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
	FROM sumOfTapproveDoneRecords_by_Project WK
	LEFT JOIN sumOfidleDetails_by_Project IDLE ON WK.TR_UID =IDLE.IDLE_UID AND WK.WORKDATE = IDLE.WORKDATE AND WK.PCP_Project=IDLE.IDLE_Project
	LEFT JOIN sumOfTaskGap_WasteOurs_by_Project WHGAP ON  WK.TR_UID = WHGAP.TR_UID AND WK.WORKDATE = WHGAP.WORKDATE 
	AND WK.PC_ProcessCode=WHGAP.PC_ProcessCode AND WHGAP.PCP_Project=WK.PCP_Project AND WHGAP.Task_ID=WK.Task_ID
),
X3_by_Project AS (
	SELECT TOP (999999999999999999) X.WORKDATE, X.PCP_Project, X.PC_ProcessCode, X.Task_ID, X.TR_UID,  [OUTPUT], X1, [WORK_HOURS], (X.X1/CASE SIGN(ISNULL(Y1.Y,1)) WHEN -1 THEN 1 ELSE (ISNULL(Y1.Y,1)) END)*100 AS [X3]
	FROM Y_by_Project Y1
	LEFT JOIN X1_by_Project X ON X.TR_UID =Y1.TR_UID AND X.WORKDATE = Y1.WORKDATE AND Y1.PC_ProcessCode=X.PC_ProcessCode AND Y1.PCP_Project=X.PCP_Project AND Y1.Task_ID=X.Task_ID
)


/*Weekly X3 for cluster*/
SELECT X3.PCP_Project AS [PROJECT], X3.PC_ProcessCode AS [ITEM_CODE], X3.Task_ID AS [TASK_ID], T.Task_Description AS [DESCRIPTION], SUM(X3.[OUTPUT]) AS [OUTPUT], ROUND(SUM(X3.X1),2) AS [SUM X1], ROUND(SUM(X3.[WORK_HOURS]),2) AS [WORK HOURS], ROUND(SUM(X3.X3),2) AS [X3]
FROM X3_by_Project X3
INNER JOIN tbl_TaskDetail T ON T.PC_ProcessCode=X3.PC_ProcessCode AND X3.PCP_Project=T.PIC_Project AND X3.Task_ID=T.Task_ID
GROUP BY X3.PCP_Project, X3.PC_ProcessCode, X3.Task_ID, T.Task_Description
ORDER BY X3.PCP_Project, X3.PC_ProcessCode, X3.Task_ID, T.Task_Description DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byTask_Ranked]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byTask_Ranked] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime

AS

/* MONTHLY X3 TASK */
SELECT [PCP_Project] AS [PROJECT]
	  ,PC_ProcessCode AS [ITEM CODE]
	  ,Task_ID AS [TASK ID]
	  ,Task_Description AS [DESCRIPTION]
	--,SUM([USER_OUTPUT]) AS [USER OUTPUT]
    --,SUM([ACTUAL_OUTPUT]) AS [OUTPUT]
	--,ROUND(SUM([WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([ACTUAL_WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([APPROVED_IDLE]),2) AS [APPROVED IDLE]
      ,ROUND(SUM([SUM_OF_X1]),2) AS [X1]
      ,ROUND(SUM([Y]),2) AS [Y]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
	  ,RANK() OVER (ORDER BY ((SUM([SUM_OF_X1])/SUM([Y])) * 100) DESC) AS [RANK]
FROM tbl_Report_TempDailyX3Task
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC
GROUP BY [PCP_Project],PC_ProcessCode,Task_ID,Task_Description
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byTask_RankedAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byTask_RankedAndManager] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mMUID nvarchar(20)

AS

/* MONTHLY X3 TASK */
SELECT [PCP_Project] AS [PROJECT]
	  ,PC_ProcessCode AS [ITEM CODE]
	  ,Task_ID AS [TASK ID]
	  ,Task_Description AS [DESCRIPTION]
	--,SUM([USER_OUTPUT]) AS [USER OUTPUT]
    --,SUM([ACTUAL_OUTPUT]) AS [OUTPUT]
	--,ROUND(SUM([WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([ACTUAL_WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([APPROVED_IDLE]),2) AS [APPROVED IDLE]
      ,ROUND(SUM([SUM_OF_X1]),2) AS [X1]
      ,ROUND(SUM([Y]),2) AS [Y]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
	  ,RANK() OVER (ORDER BY ((SUM([SUM_OF_X1])/SUM([Y])) * 100) DESC) AS [RANK]
FROM tbl_Report_TempDailyX3Task
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND TR_MID=@mMUID
GROUP BY [PCP_Project],PC_ProcessCode,Task_ID,Task_Description
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byTask_User]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byTask_User] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime

AS
/* Wokred Shift for 9 hours */
DECLARE @K int;

SET @K=32400;

DECLARE @TemptblDifference_@mPIC TABLE(
RowNumber bigint,
TR_Index bigint,
WORKDATE Date,
TR_ID nvarchar(100),
TR_UID nvarchar(50), 
TR_InDate DateTime,
TR_OutDate DateTime,
TR_Status int,
TR_Apporval int,
TR_MID nvarchar(50),
TR_PIC nvarchar(50),
TR_Shipment nvarchar(100),
TR_File nvarchar(100),
ACTUAL_OUTPUT float,
WORKED_HOURS float,
QUOTA float, 
TR_UOM nvarchar(50), 
PCP_ID nvarchar(50),
Task_ID nvarchar(50),
PC_ProcessCode nvarchar(50), 
PCP_Project nvarchar(50)
); 

DECLARE @TemptaskDetails_@mPIC TABLE(
RowNumber bigint,
TR_Index bigint,
WORKDATE Date,
TR_ID nvarchar(100),
TR_UID nvarchar(50), 
TR_InDate DateTime,
TR_OutDate DateTime,
WORKED_HOURS float, 
WASTE_HOURS float,
X1 float,
HRS_WASTE float,
TR_Status int,
TR_Apporval int,
TR_MID nvarchar(50),
TR_PIC nvarchar(50),
TR_Shipment nvarchar(100),
TR_File nvarchar(100),
ACTUAL_OUTPUT float,
QUOTA float, 
TR_UOM nvarchar(50), 
PCP_ID nvarchar(50),
Task_ID nvarchar(50),
PC_ProcessCode nvarchar(50), 
PCP_Project nvarchar(50)
); 

DECLARE @TempidleDetails_@mPIC TABLE(
IDLE_Index bigint,
WORKDATE Date,
IDLE_ID nvarchar(100),
IDLE_UID nvarchar(50), 
IDLE_InDate DateTime,
IDLE_OutDate DateTime,
IDLE_TIME float, 
IDLE_Reason nvarchar(200),
IDLE_MID nvarchar(50), 
IDLE_PIC nvarchar(50), 
IDLE_Project nvarchar(50)
);

INSERT INTO @TemptblDifference_@mPIC 
	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ISNULL(CAST(d.TR_FileSize AS float),0) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ISNULL(CAST(d.TR_Quota AS float),0) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
    FROM tbl_TaskRecordDetail d
	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
	WHERE d.TR_InDate BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC
	ORDER BY d.TR_UID

INSERT INTO @TemptaskDetails_@mPIC 
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST((cur.TR_InDate - previous.TR_OutDate) AS float),0) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + ISNULL(CAST((cur.TR_OutDate - cur.TR_InDate) AS float),0)) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)

INSERT INTO @TempidleDetails_@mPIC 
	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
	FROM tbl_IDLEDetail i
	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC
;
WITH approveDoneRecords AS(
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_MID, cur.[WORKED_HOURS], cur.TR_Status, cur.TR_Apporval,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
),
sumOfTapproveDoneRecords AS(
	SELECT TOP (999999999999999999) CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID, cur.PC_ProcessCode, cur.Task_ID, SUM(cur.WORKED_HOURS) AS [WORKED_HOURS]
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID, cur.PC_ProcessCode, cur.Task_ID
	ORDER BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID, cur.PC_ProcessCode, cur.Task_ID
),
sumOfTaskGap_WasteOurs AS(
	SELECT CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID,cur.PC_ProcessCode, cur.Task_ID, ISNULL(SUM(CAST(cur.TR_InDate - previous.TR_OutDate AS float)), 0) AS [WASTE_HOURS]
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID, cur.PC_ProcessCode, cur.Task_ID
),
sumOfidleDetails AS (
	SELECT TOP (999999999999999999) [WORKDATE], IDLE_UID, IDLE_MID, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
	FROM @TempidleDetails_@mPIC 
	GROUP BY [WORKDATE], IDLE_UID, IDLE_MID, IDLE_Project
	ORDER BY [WORKDATE], IDLE_UID, IDLE_MID, IDLE_Project
),

X1 AS (
	SELECT TOP (999999999999999999) WORKDATE, TR_UID, TR_MID, PC_ProcessCode, Task_ID, SUM(ACTUAL_OUTPUT) AS [OUTPUT], SUM(X1) AS [X1]
	FROM @TemptaskDetails_@mPIC
	GROUP BY WORKDATE, TR_UID, TR_MID, PC_ProcessCode, Task_ID
	ORDER BY WORKDATE, TR_UID, TR_MID, PC_ProcessCode, Task_ID
),

Y AS (
	SELECT TOP (999999999999999999) WK.WORKDATE, WK.TR_UID, WK.TR_MID, WK.PC_ProcessCode, WK.Task_ID, (ISNULL(WK.WORKED_HOURS,0)) AS [WORK_HOURS],(ISNULL(WK.WORKED_HOURS,0) + ISNULL(WHGAP.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
	FROM sumOfTapproveDoneRecords WK
	LEFT JOIN sumOfidleDetails IDLE ON WK.TR_UID =IDLE.IDLE_UID AND WK.WORKDATE = IDLE.WORKDATE AND WK.TR_MID=IDLE.IDLE_MID
	LEFT JOIN sumOfTaskGap_WasteOurs WHGAP ON  WK.TR_UID = WHGAP.TR_UID AND WK.WORKDATE = WHGAP.WORKDATE AND WHGAP.TR_MID=WK.TR_MID
),
X3 AS (
	SELECT TOP (999999999999999999) X.TR_UID, X.TR_MID, X.PC_ProcessCode, X.Task_ID, X.WORKDATE, [OUTPUT], X1, [WORK_HOURS], (X.X1/CASE SIGN(ISNULL(Y1.Y,1)) WHEN -1 THEN 1 ELSE (ISNULL(Y1.Y,1)) END )*100 AS [X3]
	FROM Y Y1
	LEFT JOIN X1 X ON X.TR_UID =Y1.TR_UID AND X.WORKDATE = Y1.WORKDATE AND X.TR_MID= Y1.TR_MID
)

SELECT X.WORKDATE, X.TR_UID AS [UID], X.TR_MID AS [TEAM], td.PIC_Project AS [PROJECT], X.PC_ProcessCode AS [ITEM CODE], X.Task_ID AS [TASK CODE], td.Task_Description AS [DESC.],  ROUND(SUM(X.[OUTPUT]),2) AS [OUTPUT], ROUND(SUM(X.[WORK_HOURS]),2) AS [WORK HOURS], ROUND(SUM(X.X1),2) AS [X1], ROUND(SUM(X.X3),2) AS [X3] 
FROM X3 X WITH (NOLOCK)
INNER JOIN tbl_TaskDetail td ON  X.PC_ProcessCode=td.PC_ProcessCode AND X.Task_ID=td.Task_ID
GROUP BY X.WORKDATE, X.TR_UID, X.TR_MID, X.PC_ProcessCode, X.Task_ID, td.Task_Description, td.PIC_Project, td.PIC_Project
ORDER BY WORKDATE DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byTask_User_FilterByManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byTask_User_FilterByManager] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mMID nvarchar(20)

AS
/* Wokred Shift for 9 hours */
DECLARE @K int;

SET @K=32400;

DECLARE @TemptblDifference_@mPIC TABLE(
RowNumber bigint,
TR_Index bigint,
WORKDATE Date,
TR_ID nvarchar(100),
TR_UID nvarchar(50), 
TR_InDate DateTime,
TR_OutDate DateTime,
TR_Status int,
TR_Apporval int,
TR_MID nvarchar(50),
TR_PIC nvarchar(50),
TR_Shipment nvarchar(100),
TR_File nvarchar(100),
ACTUAL_OUTPUT float,
WORKED_HOURS float,
QUOTA float, 
TR_UOM nvarchar(50), 
PCP_ID nvarchar(50),
Task_ID nvarchar(50),
PC_ProcessCode nvarchar(50), 
PCP_Project nvarchar(50)
); 

DECLARE @TemptaskDetails_@mPIC TABLE(
RowNumber bigint,
TR_Index bigint,
WORKDATE Date,
TR_ID nvarchar(100),
TR_UID nvarchar(50), 
TR_InDate DateTime,
TR_OutDate DateTime,
WORKED_HOURS float, 
WASTE_HOURS float,
X1 float,
HRS_WASTE float,
TR_Status int,
TR_Apporval int,
TR_MID nvarchar(50),
TR_PIC nvarchar(50),
TR_Shipment nvarchar(100),
TR_File nvarchar(100),
ACTUAL_OUTPUT float,
QUOTA float, 
TR_UOM nvarchar(50), 
PCP_ID nvarchar(50),
Task_ID nvarchar(50),
PC_ProcessCode nvarchar(50), 
PCP_Project nvarchar(50)
); 

DECLARE @TempidleDetails_@mPIC TABLE(
IDLE_Index bigint,
WORKDATE Date,
IDLE_ID nvarchar(100),
IDLE_UID nvarchar(50), 
IDLE_InDate DateTime,
IDLE_OutDate DateTime,
IDLE_TIME float, 
IDLE_Reason nvarchar(200),
IDLE_MID nvarchar(50), 
IDLE_PIC nvarchar(50), 
IDLE_Project nvarchar(50)
);

INSERT INTO @TemptblDifference_@mPIC 
	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ISNULL(CAST(d.TR_FileSize AS float),0) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ISNULL(CAST(d.TR_Quota AS float),0) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
    FROM tbl_TaskRecordDetail d
	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
	WHERE d.TR_InDate BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC AND d.TR_MID=@mMID
	ORDER BY d.TR_UID

INSERT INTO @TemptaskDetails_@mPIC 
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST((cur.TR_InDate - previous.TR_OutDate) AS float),0) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + ISNULL(CAST((cur.TR_OutDate - cur.TR_InDate) AS float),0)) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)

INSERT INTO @TempidleDetails_@mPIC 
	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
	FROM tbl_IDLEDetail i
	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC AND h.IDLE_MID=@mMID
;
WITH approveDoneRecords AS(
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_MID, cur.[WORKED_HOURS], cur.TR_Status, cur.TR_Apporval,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
),
sumOfTapproveDoneRecords AS(
	SELECT TOP (999999999999999999) CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID, cur.PC_ProcessCode, cur.Task_ID, SUM(cur.WORKED_HOURS) AS [WORKED_HOURS]
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID, cur.PC_ProcessCode, cur.Task_ID
	ORDER BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID, cur.PC_ProcessCode, cur.Task_ID
),
sumOfTaskGap_WasteOurs AS(
	SELECT CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID,cur.PC_ProcessCode, cur.Task_ID, ISNULL(SUM(CAST(cur.TR_InDate - previous.TR_OutDate AS float)), 0) AS [WASTE_HOURS]
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID, cur.PC_ProcessCode, cur.Task_ID
),
sumOfidleDetails AS (
	SELECT TOP (999999999999999999) [WORKDATE], IDLE_UID, IDLE_MID, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
	FROM @TempidleDetails_@mPIC 
	GROUP BY [WORKDATE], IDLE_UID, IDLE_MID, IDLE_Project
	ORDER BY [WORKDATE], IDLE_UID, IDLE_MID, IDLE_Project
),

X1 AS (
	SELECT TOP (999999999999999999) WORKDATE, TR_UID, TR_MID, PC_ProcessCode, Task_ID, SUM(ACTUAL_OUTPUT) AS [OUTPUT], SUM(X1) AS [X1]
	FROM @TemptaskDetails_@mPIC
	GROUP BY WORKDATE, TR_UID, TR_MID, PC_ProcessCode, Task_ID
	ORDER BY WORKDATE, TR_UID, TR_MID, PC_ProcessCode, Task_ID
),

Y AS (
	SELECT TOP (999999999999999999) WK.WORKDATE, WK.TR_UID, WK.TR_MID, WK.PC_ProcessCode, WK.Task_ID, (ISNULL(WK.WORKED_HOURS,0)) AS [WORK_HOURS],(ISNULL(WK.WORKED_HOURS,0) + ISNULL(WHGAP.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
	FROM sumOfTapproveDoneRecords WK
	LEFT JOIN sumOfidleDetails IDLE ON WK.TR_UID =IDLE.IDLE_UID AND WK.WORKDATE = IDLE.WORKDATE AND WK.TR_MID=IDLE.IDLE_MID
	LEFT JOIN sumOfTaskGap_WasteOurs WHGAP ON  WK.TR_UID = WHGAP.TR_UID AND WK.WORKDATE = WHGAP.WORKDATE AND WHGAP.TR_MID=WK.TR_MID
),
X3 AS (
	SELECT TOP (999999999999999999) X.TR_UID, X.TR_MID, X.PC_ProcessCode, X.Task_ID, X.WORKDATE, [OUTPUT], X1, [WORK_HOURS], (X.X1/CASE SIGN(ISNULL(Y1.Y,1)) WHEN -1 THEN 1 ELSE (ISNULL(Y1.Y,1)) END )*100 AS [X3]
	FROM Y Y1
	LEFT JOIN X1 X ON X.TR_UID =Y1.TR_UID AND X.WORKDATE = Y1.WORKDATE AND X.TR_MID= Y1.TR_MID
)

SELECT X.WORKDATE, X.TR_UID AS [UID], X.TR_MID AS [TEAM], td.PIC_Project AS [PROJECT], X.PC_ProcessCode AS [ITEM CODE], X.Task_ID AS [TASK CODE], td.Task_Description AS [DESC.],  ROUND(SUM(X.[OUTPUT]),2) AS [OUTPUT], ROUND(SUM(X.[WORK_HOURS]),2) AS [WORK HOURS], ROUND(SUM(X.X1),2) AS [X1], ROUND(SUM(X.X3),2) AS [X3] 
FROM X3 X WITH (NOLOCK)
INNER JOIN tbl_TaskDetail td ON  X.PC_ProcessCode=td.PC_ProcessCode AND X.Task_ID=td.Task_ID
GROUP BY X.WORKDATE, X.TR_UID, X.TR_MID, X.PC_ProcessCode, X.Task_ID, td.Task_Description, td.PIC_Project, td.PIC_Project
ORDER BY WORKDATE DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byTask_User_FilterByProject]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byTask_User_FilterByProject] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mProject nvarchar(30)

AS
/* Wokred Shift for 9 hours */
DECLARE @K int;

SET @K=32400;

DECLARE @TemptblDifference_@mPIC TABLE(
RowNumber bigint,
TR_Index bigint,
WORKDATE Date,
TR_ID nvarchar(100),
TR_UID nvarchar(50), 
TR_InDate DateTime,
TR_OutDate DateTime,
TR_Status int,
TR_Apporval int,
TR_MID nvarchar(50),
TR_PIC nvarchar(50),
TR_Shipment nvarchar(100),
TR_File nvarchar(100),
ACTUAL_OUTPUT float,
WORKED_HOURS float,
QUOTA float, 
TR_UOM nvarchar(50), 
PCP_ID nvarchar(50),
Task_ID nvarchar(50),
PC_ProcessCode nvarchar(50), 
PCP_Project nvarchar(50)
); 

DECLARE @TemptaskDetails_@mPIC TABLE(
RowNumber bigint,
TR_Index bigint,
WORKDATE Date,
TR_ID nvarchar(100),
TR_UID nvarchar(50), 
TR_InDate DateTime,
TR_OutDate DateTime,
WORKED_HOURS float, 
WASTE_HOURS float,
X1 float,
HRS_WASTE float,
TR_Status int,
TR_Apporval int,
TR_MID nvarchar(50),
TR_PIC nvarchar(50),
TR_Shipment nvarchar(100),
TR_File nvarchar(100),
ACTUAL_OUTPUT float,
QUOTA float, 
TR_UOM nvarchar(50), 
PCP_ID nvarchar(50),
Task_ID nvarchar(50),
PC_ProcessCode nvarchar(50), 
PCP_Project nvarchar(50)
); 

DECLARE @TempidleDetails_@mPIC TABLE(
IDLE_Index bigint,
WORKDATE Date,
IDLE_ID nvarchar(100),
IDLE_UID nvarchar(50), 
IDLE_InDate DateTime,
IDLE_OutDate DateTime,
IDLE_TIME float, 
IDLE_Reason nvarchar(200),
IDLE_MID nvarchar(50), 
IDLE_PIC nvarchar(50), 
IDLE_Project nvarchar(50)
);

INSERT INTO @TemptblDifference_@mPIC 
	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ISNULL(CAST(d.TR_FileSize AS float),0) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ISNULL(CAST(d.TR_Quota AS float),0) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
    FROM tbl_TaskRecordDetail d
	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
	WHERE d.TR_InDate BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC AND p.PCP_Project=@mProject
	ORDER BY d.TR_UID

INSERT INTO @TemptaskDetails_@mPIC 
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST((cur.TR_InDate - previous.TR_OutDate) AS float),0) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + ISNULL(CAST((cur.TR_OutDate - cur.TR_InDate) AS float),0)) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)

INSERT INTO @TempidleDetails_@mPIC 
	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
	FROM tbl_IDLEDetail i
	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC AND h.IDLE_Project=@mProject
;
WITH approveDoneRecords AS(
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_MID, cur.[WORKED_HOURS], cur.TR_Status, cur.TR_Apporval,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
),
sumOfTapproveDoneRecords AS(
	SELECT TOP (999999999999999999) CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID, cur.PC_ProcessCode, cur.Task_ID, SUM(cur.WORKED_HOURS) AS [WORKED_HOURS]
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID, cur.PC_ProcessCode, cur.Task_ID
	ORDER BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID, cur.PC_ProcessCode, cur.Task_ID
),
sumOfTaskGap_WasteOurs AS(
	SELECT CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID,cur.PC_ProcessCode, cur.Task_ID, ISNULL(SUM(CAST(cur.TR_InDate - previous.TR_OutDate AS float)), 0) AS [WASTE_HOURS]
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID, cur.PC_ProcessCode, cur.Task_ID
),
sumOfidleDetails AS (
	SELECT TOP (999999999999999999) [WORKDATE], IDLE_UID, IDLE_MID, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
	FROM @TempidleDetails_@mPIC 
	GROUP BY [WORKDATE], IDLE_UID, IDLE_MID, IDLE_Project
	ORDER BY [WORKDATE], IDLE_UID, IDLE_MID, IDLE_Project
),

X1 AS (
	SELECT TOP (999999999999999999) WORKDATE, TR_UID, TR_MID, PC_ProcessCode, Task_ID, SUM(ACTUAL_OUTPUT) AS [OUTPUT], SUM(X1) AS [X1]
	FROM @TemptaskDetails_@mPIC
	GROUP BY WORKDATE, TR_UID, TR_MID, PC_ProcessCode, Task_ID
	ORDER BY WORKDATE, TR_UID, TR_MID, PC_ProcessCode, Task_ID
),

Y AS (
	SELECT TOP (999999999999999999) WK.WORKDATE, WK.TR_UID, WK.TR_MID, WK.PC_ProcessCode, WK.Task_ID, (ISNULL(WK.WORKED_HOURS,0)) AS [WORK_HOURS],(ISNULL(WK.WORKED_HOURS,0) + ISNULL(WHGAP.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
	FROM sumOfTapproveDoneRecords WK
	LEFT JOIN sumOfidleDetails IDLE ON WK.TR_UID =IDLE.IDLE_UID AND WK.WORKDATE = IDLE.WORKDATE AND WK.TR_MID=IDLE.IDLE_MID
	LEFT JOIN sumOfTaskGap_WasteOurs WHGAP ON  WK.TR_UID = WHGAP.TR_UID AND WK.WORKDATE = WHGAP.WORKDATE AND WHGAP.TR_MID=WK.TR_MID
),
X3 AS (
	SELECT TOP (999999999999999999) X.TR_UID, X.TR_MID, X.PC_ProcessCode, X.Task_ID, X.WORKDATE, [OUTPUT], X1, [WORK_HOURS], (X.X1/CASE SIGN(ISNULL(Y1.Y,1)) WHEN -1 THEN 1 ELSE (ISNULL(Y1.Y,1)) END )*100 AS [X3]
	FROM Y Y1
	LEFT JOIN X1 X ON X.TR_UID =Y1.TR_UID AND X.WORKDATE = Y1.WORKDATE AND X.TR_MID= Y1.TR_MID
)

SELECT X.WORKDATE, X.TR_UID AS [UID], X.TR_MID AS [TEAM], td.PIC_Project AS [PROJECT], X.PC_ProcessCode AS [ITEM CODE], X.Task_ID AS [TASK CODE], td.Task_Description AS [DESC.],  ROUND(SUM(X.[OUTPUT]),2) AS [OUTPUT], ROUND(SUM(X.[WORK_HOURS]),2) AS [WORK HOURS], ROUND(SUM(X.X1),2) AS [X1], ROUND(SUM(X.X3),2) AS [X3] 
FROM X3 X WITH (NOLOCK)
INNER JOIN tbl_TaskDetail td ON  X.PC_ProcessCode=td.PC_ProcessCode AND X.Task_ID=td.Task_ID
GROUP BY X.WORKDATE, X.TR_UID, X.TR_MID, X.PC_ProcessCode, X.Task_ID, td.Task_Description, td.PIC_Project, td.PIC_Project
ORDER BY WORKDATE DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byTask_User_FilterByUser]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byTask_User_FilterByUser] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mUID nvarchar(20)

AS
/* Wokred Shift for 9 hours */
DECLARE @K int;

SET @K=32400;

DECLARE @TemptblDifference_@mPIC TABLE(
RowNumber bigint,
TR_Index bigint,
WORKDATE Date,
TR_ID nvarchar(100),
TR_UID nvarchar(50), 
TR_InDate DateTime,
TR_OutDate DateTime,
TR_Status int,
TR_Apporval int,
TR_MID nvarchar(50),
TR_PIC nvarchar(50),
TR_Shipment nvarchar(100),
TR_File nvarchar(100),
ACTUAL_OUTPUT float,
WORKED_HOURS float,
QUOTA float, 
TR_UOM nvarchar(50), 
PCP_ID nvarchar(50),
Task_ID nvarchar(50),
PC_ProcessCode nvarchar(50), 
PCP_Project nvarchar(50)
); 

DECLARE @TemptaskDetails_@mPIC TABLE(
RowNumber bigint,
TR_Index bigint,
WORKDATE Date,
TR_ID nvarchar(100),
TR_UID nvarchar(50), 
TR_InDate DateTime,
TR_OutDate DateTime,
WORKED_HOURS float, 
WASTE_HOURS float,
X1 float,
HRS_WASTE float,
TR_Status int,
TR_Apporval int,
TR_MID nvarchar(50),
TR_PIC nvarchar(50),
TR_Shipment nvarchar(100),
TR_File nvarchar(100),
ACTUAL_OUTPUT float,
QUOTA float, 
TR_UOM nvarchar(50), 
PCP_ID nvarchar(50),
Task_ID nvarchar(50),
PC_ProcessCode nvarchar(50), 
PCP_Project nvarchar(50)
); 

DECLARE @TempidleDetails_@mPIC TABLE(
IDLE_Index bigint,
WORKDATE Date,
IDLE_ID nvarchar(100),
IDLE_UID nvarchar(50), 
IDLE_InDate DateTime,
IDLE_OutDate DateTime,
IDLE_TIME float, 
IDLE_Reason nvarchar(200),
IDLE_MID nvarchar(50), 
IDLE_PIC nvarchar(50), 
IDLE_Project nvarchar(50)
);

INSERT INTO @TemptblDifference_@mPIC 
	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ISNULL(CAST(d.TR_FileSize AS float),0) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ISNULL(CAST(d.TR_Quota AS float),0) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
    FROM tbl_TaskRecordDetail d
	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
	WHERE d.TR_InDate BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC AND d.TR_UID=@mUID
	ORDER BY d.TR_UID

INSERT INTO @TemptaskDetails_@mPIC 
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST((cur.TR_InDate - previous.TR_OutDate) AS float),0) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + ISNULL(CAST((cur.TR_OutDate - cur.TR_InDate) AS float),0)) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)

INSERT INTO @TempidleDetails_@mPIC 
	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
	FROM tbl_IDLEDetail i
	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC AND h.IDLE_UID=@mUID
;
WITH approveDoneRecords AS(
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_MID, cur.[WORKED_HOURS], cur.TR_Status, cur.TR_Apporval,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
),
sumOfTapproveDoneRecords AS(
	SELECT TOP (999999999999999999) CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID, cur.PC_ProcessCode, cur.Task_ID, SUM(cur.WORKED_HOURS) AS [WORKED_HOURS]
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID, cur.PC_ProcessCode, cur.Task_ID
	ORDER BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID, cur.PC_ProcessCode, cur.Task_ID
),
sumOfTaskGap_WasteOurs AS(
	SELECT CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID,cur.PC_ProcessCode, cur.Task_ID, ISNULL(SUM(CAST(cur.TR_InDate - previous.TR_OutDate AS float)), 0) AS [WASTE_HOURS]
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID, cur.PC_ProcessCode, cur.Task_ID
),
sumOfidleDetails AS (
	SELECT TOP (999999999999999999) [WORKDATE], IDLE_UID, IDLE_MID, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
	FROM @TempidleDetails_@mPIC 
	GROUP BY [WORKDATE], IDLE_UID, IDLE_MID, IDLE_Project
	ORDER BY [WORKDATE], IDLE_UID, IDLE_MID, IDLE_Project
),

X1 AS (
	SELECT TOP (999999999999999999) WORKDATE, TR_UID, TR_MID, PC_ProcessCode, Task_ID, SUM(ACTUAL_OUTPUT) AS [OUTPUT], SUM(X1) AS [X1]
	FROM @TemptaskDetails_@mPIC
	GROUP BY WORKDATE, TR_UID, TR_MID, PC_ProcessCode, Task_ID
	ORDER BY WORKDATE, TR_UID, TR_MID, PC_ProcessCode, Task_ID
),

Y AS (
	SELECT TOP (999999999999999999) WK.WORKDATE, WK.TR_UID, WK.TR_MID, WK.PC_ProcessCode, WK.Task_ID, (ISNULL(WK.WORKED_HOURS,0)) AS [WORK_HOURS],(ISNULL(WK.WORKED_HOURS,0) + ISNULL(WHGAP.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
	FROM sumOfTapproveDoneRecords WK
	LEFT JOIN sumOfidleDetails IDLE ON WK.TR_UID =IDLE.IDLE_UID AND WK.WORKDATE = IDLE.WORKDATE AND WK.TR_MID=IDLE.IDLE_MID
	LEFT JOIN sumOfTaskGap_WasteOurs WHGAP ON  WK.TR_UID = WHGAP.TR_UID AND WK.WORKDATE = WHGAP.WORKDATE AND WHGAP.TR_MID=WK.TR_MID
),
X3 AS (
	SELECT TOP (999999999999999999) X.TR_UID, X.TR_MID, X.PC_ProcessCode, X.Task_ID, X.WORKDATE, [OUTPUT], X1, [WORK_HOURS], (X.X1/CASE SIGN(ISNULL(Y1.Y,1)) WHEN -1 THEN 1 ELSE (ISNULL(Y1.Y,1)) END )*100 AS [X3]
	FROM Y Y1
	LEFT JOIN X1 X ON X.TR_UID =Y1.TR_UID AND X.WORKDATE = Y1.WORKDATE AND X.TR_MID= Y1.TR_MID
)

SELECT X.WORKDATE, X.TR_UID AS [UID], X.TR_MID AS [TEAM], td.PIC_Project AS [PROJECT], X.PC_ProcessCode AS [ITEM CODE], X.Task_ID AS [TASK CODE], td.Task_Description AS [DESC.],  ROUND(SUM(X.[OUTPUT]),2) AS [OUTPUT], ROUND(SUM(X.[WORK_HOURS]),2) AS [WORK HOURS], ROUND(SUM(X.X1),2) AS [X1], ROUND(SUM(X.X3),2) AS [X3] 
FROM X3 X WITH (NOLOCK)
INNER JOIN tbl_TaskDetail td ON  X.PC_ProcessCode=td.PC_ProcessCode AND X.Task_ID=td.Task_ID
GROUP BY X.WORKDATE, X.TR_UID, X.TR_MID, X.PC_ProcessCode, X.Task_ID, td.Task_Description, td.PIC_Project, td.PIC_Project
ORDER BY WORKDATE DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byTeam_Ranked]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[DBoard_X3byTeam_Ranked] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime

AS

/* MONTHLY X3 USER */
SELECT [TR_MID] AS [TEAM]
	--,SUM([USER_OUTPUT]) AS [USER OUTPUT]
    --,SUM([ACTUAL_OUTPUT]) AS [OUTPUT]
	--,ROUND(SUM([WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([ACTUAL_WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([APPROVED_IDLE]),2) AS [APPROVED IDLE]
      ,ROUND(SUM([SUM_OF_X1]),2) AS [X1]
      ,ROUND(SUM([Y]),2) AS [Y]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
	  ,RANK() OVER (ORDER BY ((SUM([SUM_OF_X1])/SUM([Y])) * 100) DESC) AS [RANK]
FROM tbl_Report_TempDailyX3Users
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC
GROUP BY [TR_MID]
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

--/* Wokred Shift for 9 hours */
--DECLARE @K int;

--SET @K= 32400;

--DECLARE @TemptblDifference_@mPIC TABLE(
--RowNumber bigint,
--TR_Index bigint,
--WORKDATE Date,
--TR_ID nvarchar(100),
--TR_UID nvarchar(50), 
--TR_InDate DateTime,
--TR_OutDate DateTime,
--TR_Status int,
--TR_Apporval int,
--TR_MID nvarchar(50),
--TR_PIC nvarchar(50),
--TR_Shipment nvarchar(100),
--TR_File nvarchar(100),
--ACTUAL_OUTPUT float,
--WORKED_HOURS float,
--QUOTA float, 
--TR_UOM nvarchar(50), 
--PCP_ID nvarchar(50),
--Task_ID nvarchar(50),
--PC_ProcessCode nvarchar(50), 
--PCP_Project nvarchar(50)
--); 

--DECLARE @TemptaskDetails_@mPIC TABLE(
--RowNumber bigint,
--TR_Index bigint,
--WORKDATE Date,
--TR_ID nvarchar(100),
--TR_UID nvarchar(50), 
--TR_InDate DateTime,
--TR_OutDate DateTime,
--WORKED_HOURS float, 
--WASTE_HOURS float,
--X1 float,
--HRS_WASTE float,
--TR_Status int,
--TR_Apporval int,
--TR_MID nvarchar(50),
--TR_PIC nvarchar(50),
--TR_Shipment nvarchar(100),
--TR_File nvarchar(100),
--ACTUAL_OUTPUT float,
--QUOTA float, 
--TR_UOM nvarchar(50), 
--PCP_ID nvarchar(50),
--Task_ID nvarchar(50),
--PC_ProcessCode nvarchar(50), 
--PCP_Project nvarchar(50)
--); 

--DECLARE @TempidleDetails_@mPIC TABLE(
--IDLE_Index bigint,
--WORKDATE Date,
--IDLE_ID nvarchar(100),
--IDLE_UID nvarchar(50), 
--IDLE_InDate DateTime,
--IDLE_OutDate DateTime,
--IDLE_TIME float, 
--IDLE_Reason nvarchar(200),
--IDLE_MID nvarchar(50), 
--IDLE_PIC nvarchar(50), 
--IDLE_Project nvarchar(50)
--);

--INSERT INTO @TemptblDifference_@mPIC 
--	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ISNULL(CAST(d.TR_FileSize AS float),0) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ISNULL(CAST(d.TR_Quota AS float),0) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
--    FROM tbl_TaskRecordDetail d
--	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
--	WHERE d.TR_InDate BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC
--	ORDER BY d.TR_UID

--INSERT INTO @TemptaskDetails_@mPIC 
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST((cur.TR_InDate - previous.TR_OutDate) AS float),0) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + ISNULL(CAST((cur.TR_OutDate - cur.TR_InDate) AS float),0)) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)

--INSERT INTO @TempidleDetails_@mPIC 
--	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
--	FROM tbl_IDLEDetail i
--	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
--	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC
--;
--WITH approveDoneRecords AS(
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.[WORKED_HOURS], cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--),
--sumOfTapproveDoneRecords AS(
--	SELECT TOP (999999999999999999) CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID, SUM(cur.WORKED_HOURS) AS [WORKED_HOURS]
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID
--	ORDER BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID
--),
--sumOfTaskGap_WasteOurs AS(
--	SELECT CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID, ISNULL(SUM(CAST(cur.TR_InDate - previous.TR_OutDate AS float)), 0) AS [WASTE_HOURS]
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID
--),
--sumOfidleDetails AS (
--	SELECT TOP (999999999999999999) [WORKDATE], IDLE_UID, IDLE_MID, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
--	FROM @TempidleDetails_@mPIC 
--	GROUP BY [WORKDATE], IDLE_UID, IDLE_MID
--	ORDER BY [WORKDATE], IDLE_UID, IDLE_MID
--),

--X1 AS (
--	SELECT TOP (999999999999999999) WORKDATE, TR_UID, TR_MID, SUM(ACTUAL_OUTPUT) AS [OUTPUT], SUM(X1) AS [X1]
--	FROM @TemptaskDetails_@mPIC
--	GROUP BY WORKDATE, TR_UID, TR_MID
--	ORDER BY WORKDATE, TR_UID, TR_MID
--),

--Y AS (
--	SELECT TOP (999999999999999999) WK.WORKDATE, WK.TR_UID, WK.TR_MID,(ISNULL(WK.WORKED_HOURS,0)) AS [WORK_HOURS],(ISNULL(WK.WORKED_HOURS,0) + ISNULL(WHGAP.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
--	FROM sumOfTapproveDoneRecords WK
--	LEFT JOIN sumOfidleDetails IDLE ON WK.TR_UID =IDLE.IDLE_UID AND WK.WORKDATE = IDLE.WORKDATE AND WK.TR_MID=IDLE.IDLE_MID
--	LEFT JOIN sumOfTaskGap_WasteOurs WHGAP ON  WK.TR_UID = WHGAP.TR_UID AND WK.WORKDATE = WHGAP.WORKDATE AND WHGAP.TR_MID=WK.TR_MID
--),
--X3 AS (
--	SELECT TOP (999999999999999999) X.TR_MID,(SUM(X.X1)/CASE SIGN(ISNULL(SUM(Y1.Y),1)) WHEN -1 THEN 1 ELSE (ISNULL(SUM(Y1.Y),1)) END )*100 AS [X3]
--	FROM Y Y1
--	LEFT JOIN X1 X ON X.TR_UID =Y1.TR_UID AND X.WORKDATE = Y1.WORKDATE AND X.TR_MID = Y1.TR_MID
--	GROUP BY  X.TR_MID
--)


--SELECT TR_MID AS [TEAM],  ROUND(SUM(X3),3) AS [X3] 
--FROM X3 WITH (NOLOCK)
--GROUP BY TR_MID
--ORDER BY X3 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byTeam_Ranked_Chart]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byTeam_Ranked_Chart] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime

AS

/* MONTHLY X3 USER */
SELECT [TR_MID] AS [TEAM]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
FROM tbl_Report_TempDailyX3Users
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC
GROUP BY [TR_MID]
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byTeam_RankedByManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byTeam_RankedByManager] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mMID nvarchar(20)

AS


/* MONTHLY X3 USER */
SELECT [TR_MID] AS [TEAM]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
FROM tbl_Report_TempDailyX3Users
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND TR_MID=@mMID
GROUP BY [TR_MID]
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC


--/* Wokred Shift for 9 hours */
--DECLARE @K int;

--SET @K= 32400;

--DECLARE @TemptblDifference_@mPIC TABLE(
--RowNumber bigint,
--TR_Index bigint,
--WORKDATE Date,
--TR_ID nvarchar(100),
--TR_UID nvarchar(50), 
--TR_InDate DateTime,
--TR_OutDate DateTime,
--TR_Status int,
--TR_Apporval int,
--TR_MID nvarchar(50),
--TR_PIC nvarchar(50),
--TR_Shipment nvarchar(100),
--TR_File nvarchar(100),
--ACTUAL_OUTPUT float,
--WORKED_HOURS float,
--QUOTA float, 
--TR_UOM nvarchar(50), 
--PCP_ID nvarchar(50),
--Task_ID nvarchar(50),
--PC_ProcessCode nvarchar(50), 
--PCP_Project nvarchar(50)
--); 

--DECLARE @TemptaskDetails_@mPIC TABLE(
--RowNumber bigint,
--TR_Index bigint,
--WORKDATE Date,
--TR_ID nvarchar(100),
--TR_UID nvarchar(50), 
--TR_InDate DateTime,
--TR_OutDate DateTime,
--WORKED_HOURS float, 
--WASTE_HOURS float,
--X1 float,
--HRS_WASTE float,
--TR_Status int,
--TR_Apporval int,
--TR_MID nvarchar(50),
--TR_PIC nvarchar(50),
--TR_Shipment nvarchar(100),
--TR_File nvarchar(100),
--ACTUAL_OUTPUT float,
--QUOTA float, 
--TR_UOM nvarchar(50), 
--PCP_ID nvarchar(50),
--Task_ID nvarchar(50),
--PC_ProcessCode nvarchar(50), 
--PCP_Project nvarchar(50)
--); 

--DECLARE @TempidleDetails_@mPIC TABLE(
--IDLE_Index bigint,
--WORKDATE Date,
--IDLE_ID nvarchar(100),
--IDLE_UID nvarchar(50), 
--IDLE_InDate DateTime,
--IDLE_OutDate DateTime,
--IDLE_TIME float, 
--IDLE_Reason nvarchar(200),
--IDLE_MID nvarchar(50), 
--IDLE_PIC nvarchar(50), 
--IDLE_Project nvarchar(50)
--);

--INSERT INTO @TemptblDifference_@mPIC 
--	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ISNULL(CAST(d.TR_FileSize AS float),0) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ISNULL(CAST(d.TR_Quota AS float),0) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
--    FROM tbl_TaskRecordDetail d
--	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
--	WHERE d.TR_InDate BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC
--	ORDER BY d.TR_UID

--INSERT INTO @TemptaskDetails_@mPIC 
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST((cur.TR_InDate - previous.TR_OutDate) AS float),0) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + ISNULL(CAST((cur.TR_OutDate - cur.TR_InDate) AS float),0)) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)

--INSERT INTO @TempidleDetails_@mPIC 
--	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
--	FROM tbl_IDLEDetail i
--	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
--	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC
--;
--WITH approveDoneRecords AS(
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.[WORKED_HOURS], cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--),
--sumOfTapproveDoneRecords AS(
--	SELECT TOP (999999999999999999) CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID, SUM(cur.WORKED_HOURS) AS [WORKED_HOURS]
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID
--	ORDER BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID
--),
--sumOfTaskGap_WasteOurs AS(
--	SELECT CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID, ISNULL(SUM(CAST(cur.TR_InDate - previous.TR_OutDate AS float)), 0) AS [WASTE_HOURS]
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID
--),
--sumOfidleDetails AS (
--	SELECT TOP (999999999999999999) [WORKDATE], IDLE_UID, IDLE_MID, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
--	FROM @TempidleDetails_@mPIC 
--	GROUP BY [WORKDATE], IDLE_UID, IDLE_MID
--	ORDER BY [WORKDATE], IDLE_UID, IDLE_MID
--),

--X1 AS (
--	SELECT TOP (999999999999999999) WORKDATE, TR_UID, TR_MID, SUM(ACTUAL_OUTPUT) AS [OUTPUT], SUM(X1) AS [X1]
--	FROM @TemptaskDetails_@mPIC
--	GROUP BY WORKDATE, TR_UID, TR_MID
--	ORDER BY WORKDATE, TR_UID, TR_MID
--),

--Y AS (
--	SELECT TOP (999999999999999999) WK.WORKDATE, WK.TR_UID, WK.TR_MID,(ISNULL(WK.WORKED_HOURS,0)) AS [WORK_HOURS],(ISNULL(WK.WORKED_HOURS,0) + ISNULL(WHGAP.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
--	FROM sumOfTapproveDoneRecords WK
--	LEFT JOIN sumOfidleDetails IDLE ON WK.TR_UID =IDLE.IDLE_UID AND WK.WORKDATE = IDLE.WORKDATE AND WK.TR_MID=IDLE.IDLE_MID
--	LEFT JOIN sumOfTaskGap_WasteOurs WHGAP ON  WK.TR_UID = WHGAP.TR_UID AND WK.WORKDATE = WHGAP.WORKDATE AND WHGAP.TR_MID=WK.TR_MID
--),
--X3 AS (
--	SELECT TOP (999999999999999999) X.TR_UID, X.TR_MID, X.WORKDATE, [OUTPUT], X1, [WORK_HOURS], (X.X1/CASE SIGN(ISNULL(Y1.Y,1)) WHEN -1 THEN 1 ELSE (ISNULL(Y1.Y,1)) END )*100 AS [X3]
--	FROM Y Y1
--	LEFT JOIN X1 X ON X.TR_UID =Y1.TR_UID AND X.WORKDATE = Y1.WORKDATE AND X.TR_MID= Y1.TR_MID
--)

--SELECT TR_MID AS [TEAM],  ROUND(SUM(X3),3) AS [X3] 
--FROM X3 WITH (NOLOCK)
--WHERE TR_MID=@mMID
--GROUP BY TR_MID
--ORDER BY X3 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byTeam_RankedByProject]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byTeam_RankedByProject] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mProject nvarchar(20)

AS

/* MONTHLY X3 USER */
SELECT [TR_MID] AS [TEAM]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
FROM tbl_Report_TempDailyX3Project
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND PCP_Project=@mProject
GROUP BY [TR_MID]
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

--/* Wokred Shift for 9 hours */
--DECLARE @K int;

--SET @K= 32400;

--DECLARE @TemptblDifference_@mPIC TABLE(
--RowNumber bigint,
--TR_Index bigint,
--WORKDATE Date,
--TR_ID nvarchar(100),
--TR_UID nvarchar(50), 
--TR_InDate DateTime,
--TR_OutDate DateTime,
--TR_Status int,
--TR_Apporval int,
--TR_MID nvarchar(50),
--TR_PIC nvarchar(50),
--TR_Shipment nvarchar(100),
--TR_File nvarchar(100),
--ACTUAL_OUTPUT float,
--WORKED_HOURS float,
--QUOTA float, 
--TR_UOM nvarchar(50), 
--PCP_ID nvarchar(50),
--Task_ID nvarchar(50),
--PC_ProcessCode nvarchar(50), 
--PCP_Project nvarchar(50)
--); 

--DECLARE @TemptaskDetails_@mPIC TABLE(
--RowNumber bigint,
--TR_Index bigint,
--WORKDATE Date,
--TR_ID nvarchar(100),
--TR_UID nvarchar(50), 
--TR_InDate DateTime,
--TR_OutDate DateTime,
--WORKED_HOURS float, 
--WASTE_HOURS float,
--X1 float,
--HRS_WASTE float,
--TR_Status int,
--TR_Apporval int,
--TR_MID nvarchar(50),
--TR_PIC nvarchar(50),
--TR_Shipment nvarchar(100),
--TR_File nvarchar(100),
--ACTUAL_OUTPUT float,
--QUOTA float, 
--TR_UOM nvarchar(50), 
--PCP_ID nvarchar(50),
--Task_ID nvarchar(50),
--PC_ProcessCode nvarchar(50), 
--PCP_Project nvarchar(50)
--); 

--DECLARE @TempidleDetails_@mPIC TABLE(
--IDLE_Index bigint,
--WORKDATE Date,
--IDLE_ID nvarchar(100),
--IDLE_UID nvarchar(50), 
--IDLE_InDate DateTime,
--IDLE_OutDate DateTime,
--IDLE_TIME float, 
--IDLE_Reason nvarchar(200),
--IDLE_MID nvarchar(50), 
--IDLE_PIC nvarchar(50), 
--IDLE_Project nvarchar(50)
--);

--INSERT INTO @TemptblDifference_@mPIC 
--	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ISNULL(CAST(d.TR_FileSize AS float),0) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ISNULL(CAST(d.TR_Quota AS float),0) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
--    FROM tbl_TaskRecordDetail d
--	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
--	WHERE d.TR_InDate BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC
--	ORDER BY d.TR_UID

--INSERT INTO @TemptaskDetails_@mPIC 
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST((cur.TR_InDate - previous.TR_OutDate) AS float),0) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + ISNULL(CAST((cur.TR_OutDate - cur.TR_InDate) AS float),0)) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)

--INSERT INTO @TempidleDetails_@mPIC 
--	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
--	FROM tbl_IDLEDetail i
--	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
--	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC
--;
--WITH approveDoneRecords AS(
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.[WORKED_HOURS], cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--),
--sumOfTapproveDoneRecords AS(
--	SELECT TOP (999999999999999999) CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID, cur.PCP_Project, SUM(cur.WORKED_HOURS) AS [WORKED_HOURS]
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID, cur.PCP_Project
--	ORDER BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID, cur.PCP_Project
--),
--sumOfTaskGap_WasteOurs AS(
--	SELECT CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID, cur.PCP_Project, ISNULL(SUM(CAST(cur.TR_InDate - previous.TR_OutDate AS float)), 0) AS [WASTE_HOURS]
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID, cur.PCP_Project
--),
--sumOfidleDetails AS (
--	SELECT TOP (999999999999999999) [WORKDATE], IDLE_UID, IDLE_MID, IDLE_Project, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
--	FROM @TempidleDetails_@mPIC 
--	GROUP BY [WORKDATE], IDLE_UID, IDLE_MID, IDLE_Project
--	ORDER BY [WORKDATE], IDLE_UID, IDLE_MID, IDLE_Project
--),

--X1 AS (
--	SELECT TOP (999999999999999999) WORKDATE, TR_UID, TR_MID, PCP_Project, SUM(ACTUAL_OUTPUT) AS [OUTPUT], SUM(X1) AS [X1]
--	FROM @TemptaskDetails_@mPIC
--	GROUP BY WORKDATE, TR_UID, TR_MID, PCP_Project
--	ORDER BY WORKDATE, TR_UID, TR_MID, PCP_Project
--),

--Y AS (
--	SELECT TOP (999999999999999999) WK.WORKDATE, WK.TR_UID, WK.TR_MID, WK.PCP_Project, (ISNULL(WK.WORKED_HOURS,0)) AS [WORK_HOURS],(ISNULL(WK.WORKED_HOURS,0) + ISNULL(WHGAP.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
--	FROM sumOfTapproveDoneRecords WK
--	LEFT JOIN sumOfidleDetails IDLE ON WK.TR_UID =IDLE.IDLE_UID AND WK.WORKDATE = IDLE.WORKDATE AND WK.TR_MID=IDLE.IDLE_MID
--	LEFT JOIN sumOfTaskGap_WasteOurs WHGAP ON  WK.TR_UID = WHGAP.TR_UID AND WK.WORKDATE = WHGAP.WORKDATE AND WHGAP.TR_MID=WK.TR_MID
--),

--X3 AS (
--	SELECT TOP (999999999999999999) X.TR_UID, X.TR_MID, X.PCP_Project, X.WORKDATE, [OUTPUT], X1, [WORK_HOURS], (X.X1/CASE SIGN(ISNULL(Y1.Y,1)) WHEN -1 THEN 1 ELSE (ISNULL(Y1.Y,1)) END )*100 AS [X3]
--	FROM Y Y1
--	LEFT JOIN X1 X ON X.TR_UID =Y1.TR_UID AND X.WORKDATE = Y1.WORKDATE AND X.TR_MID= Y1.TR_MID
--)

--SELECT TR_MID AS [TEAM],  ROUND(SUM(X3),3) AS [X3] 
--FROM X3 WITH (NOLOCK)
--WHERE PCP_Project=@mProject
--GROUP BY TR_MID
--ORDER BY X3 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byTeam_RankedByProjectAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byTeam_RankedByProjectAndManager] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mProject nvarchar(20), @mMUID nvarchar(20)

AS

/* MONTHLY X3 USER */
SELECT [TR_MID] AS [TEAM]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
FROM tbl_Report_TempDailyX3Project
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND PCP_Project=@mProject AND TR_MID=@mMUID
GROUP BY [TR_MID]
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC
GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byTeam_RankedByUID]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byTeam_RankedByUID] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mUID nvarchar(20)

AS

/* MONTHLY X3 USER */
SELECT [TR_MID] AS [TEAM]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
FROM tbl_Report_TempDailyX3Users
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND TR_UID=@mUID
GROUP BY [TR_MID]
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC


--/* Wokred Shift for 9 hours */
--DECLARE @K int;

--SET @K= 32400;

--DECLARE @TemptblDifference_@mPIC TABLE(
--RowNumber bigint,
--TR_Index bigint,
--WORKDATE Date,
--TR_ID nvarchar(100),
--TR_UID nvarchar(50), 
--TR_InDate DateTime,
--TR_OutDate DateTime,
--TR_Status int,
--TR_Apporval int,
--TR_MID nvarchar(50),
--TR_PIC nvarchar(50),
--TR_Shipment nvarchar(100),
--TR_File nvarchar(100),
--ACTUAL_OUTPUT float,
--WORKED_HOURS float,
--QUOTA float, 
--TR_UOM nvarchar(50), 
--PCP_ID nvarchar(50),
--Task_ID nvarchar(50),
--PC_ProcessCode nvarchar(50), 
--PCP_Project nvarchar(50)
--); 

--DECLARE @TemptaskDetails_@mPIC TABLE(
--RowNumber bigint,
--TR_Index bigint,
--WORKDATE Date,
--TR_ID nvarchar(100),
--TR_UID nvarchar(50), 
--TR_InDate DateTime,
--TR_OutDate DateTime,
--WORKED_HOURS float, 
--WASTE_HOURS float,
--X1 float,
--HRS_WASTE float,
--TR_Status int,
--TR_Apporval int,
--TR_MID nvarchar(50),
--TR_PIC nvarchar(50),
--TR_Shipment nvarchar(100),
--TR_File nvarchar(100),
--ACTUAL_OUTPUT float,
--QUOTA float, 
--TR_UOM nvarchar(50), 
--PCP_ID nvarchar(50),
--Task_ID nvarchar(50),
--PC_ProcessCode nvarchar(50), 
--PCP_Project nvarchar(50)
--); 

--DECLARE @TempidleDetails_@mPIC TABLE(
--IDLE_Index bigint,
--WORKDATE Date,
--IDLE_ID nvarchar(100),
--IDLE_UID nvarchar(50), 
--IDLE_InDate DateTime,
--IDLE_OutDate DateTime,
--IDLE_TIME float, 
--IDLE_Reason nvarchar(200),
--IDLE_MID nvarchar(50), 
--IDLE_PIC nvarchar(50), 
--IDLE_Project nvarchar(50)
--);

--INSERT INTO @TemptblDifference_@mPIC 
--	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ISNULL(CAST(d.TR_FileSize AS float),0) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ISNULL(CAST(d.TR_Quota AS float),0) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
--    FROM tbl_TaskRecordDetail d
--	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
--	WHERE d.TR_InDate BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC
--	ORDER BY d.TR_UID

--INSERT INTO @TemptaskDetails_@mPIC 
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST((cur.TR_InDate - previous.TR_OutDate) AS float),0) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + ISNULL(CAST((cur.TR_OutDate - cur.TR_InDate) AS float),0)) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)

--INSERT INTO @TempidleDetails_@mPIC 
--	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
--	FROM tbl_IDLEDetail i
--	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
--	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC
--;
--WITH approveDoneRecords AS(
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.[WORKED_HOURS], cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--),
--sumOfTapproveDoneRecords AS(
--	SELECT TOP (999999999999999999) CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID, SUM(cur.WORKED_HOURS) AS [WORKED_HOURS]
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID
--	ORDER BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID
--),
--sumOfTaskGap_WasteOurs AS(
--	SELECT CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID, ISNULL(SUM(CAST(cur.TR_InDate - previous.TR_OutDate AS float)), 0) AS [WASTE_HOURS]
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID
--),
--sumOfidleDetails AS (
--	SELECT TOP (999999999999999999) [WORKDATE], IDLE_UID, IDLE_MID, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
--	FROM @TempidleDetails_@mPIC 
--	GROUP BY [WORKDATE], IDLE_UID, IDLE_MID
--	ORDER BY [WORKDATE], IDLE_UID, IDLE_MID
--),

--X1 AS (
--	SELECT TOP (999999999999999999) WORKDATE, TR_UID, TR_MID, SUM(ACTUAL_OUTPUT) AS [OUTPUT], SUM(X1) AS [X1]
--	FROM @TemptaskDetails_@mPIC
--	GROUP BY WORKDATE, TR_UID, TR_MID
--	ORDER BY WORKDATE, TR_UID, TR_MID
--),

--Y AS (
--	SELECT TOP (999999999999999999) WK.WORKDATE, WK.TR_UID, WK.TR_MID,(ISNULL(WK.WORKED_HOURS,0)) AS [WORK_HOURS],(ISNULL(WK.WORKED_HOURS,0) + ISNULL(WHGAP.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
--	FROM sumOfTapproveDoneRecords WK
--	LEFT JOIN sumOfidleDetails IDLE ON WK.TR_UID =IDLE.IDLE_UID AND WK.WORKDATE = IDLE.WORKDATE AND WK.TR_MID=IDLE.IDLE_MID
--	LEFT JOIN sumOfTaskGap_WasteOurs WHGAP ON  WK.TR_UID = WHGAP.TR_UID AND WK.WORKDATE = WHGAP.WORKDATE AND WHGAP.TR_MID=WK.TR_MID
--),

--X3 AS (
--	SELECT TOP (999999999999999999) X.TR_UID, X.TR_MID, X.WORKDATE, [OUTPUT], X1, [WORK_HOURS], (X.X1/CASE SIGN(ISNULL(Y1.Y,1)) WHEN -1 THEN 1 ELSE (ISNULL(Y1.Y,1)) END )*100 AS [X3]
--	FROM Y Y1
--	LEFT JOIN X1 X ON X.TR_UID =Y1.TR_UID AND X.WORKDATE = Y1.WORKDATE AND X.TR_MID= Y1.TR_MID
--)

--SELECT TR_MID AS [TEAM],  ROUND(SUM(X3),3) AS [X3] 
--FROM X3 WITH (NOLOCK)
--WHERE TR_UID=@mUID
--GROUP BY TR_MID
--ORDER BY X3 DESC


GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byTeam_RankedByUIDAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byTeam_RankedByUIDAndManager] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mUID nvarchar(20), @mMUID nvarchar(20)

AS

/* MONTHLY X3 USER */
SELECT [TR_MID] AS [TEAM]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
FROM tbl_Report_TempDailyX3Users
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND TR_UID=@mUID AND TR_MID=@mMUID
GROUP BY [TR_MID]
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byTeam_RankedPICByManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byTeam_RankedPICByManager] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mManager nvarchar(20)

AS

/* MONTHLY X3 USER */
SELECT [TR_MID] AS [TEAM]
	--,SUM([USER_OUTPUT]) AS [USER OUTPUT]
    --,SUM([ACTUAL_OUTPUT]) AS [OUTPUT]
	--,ROUND(SUM([WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([ACTUAL_WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([APPROVED_IDLE]),2) AS [APPROVED IDLE]
      ,ROUND(SUM([SUM_OF_X1]),2) AS [X1]
      ,ROUND(SUM([Y]),2) AS [Y]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
	  ,RANK() OVER (ORDER BY ((SUM([SUM_OF_X1])/SUM([Y])) * 100) DESC) AS [RANK]
FROM tbl_Report_TempDailyX3Users
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND TR_MID=@mManager
GROUP BY [TR_MID]
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC
GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byTeam_User]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byTeam_User] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime

AS

/* MONTHLY X3 USER */
SELECT [TR_MID] AS [TEAM]
	--,SUM([USER_OUTPUT]) AS [USER OUTPUT]
      ,SUM([ACTUAL_OUTPUT]) AS [OUTPUT]
	--,ROUND(SUM([WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([ACTUAL_WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([APPROVED_IDLE]),2) AS [APPROVED IDLE]
      ,ROUND(SUM([SUM_OF_X1]),2) AS [X1]
      ,ROUND(SUM([Y]),2) AS [Y]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
	  ,RANK() OVER (ORDER BY ((SUM([SUM_OF_X1])/SUM([Y])) * 100) DESC) AS [RANK]
FROM tbl_Report_TempDailyX3Users
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC
GROUP BY [TR_MID]
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

--/* Wokred Shift for 9 hours */
--DECLARE @K int;

--SET @K= 32400;

--DECLARE @TemptblDifference_@mPIC TABLE(
--RowNumber bigint,
--TR_Index bigint,
--WORKDATE Date,
--TR_ID nvarchar(100),
--TR_UID nvarchar(50), 
--TR_InDate DateTime,
--TR_OutDate DateTime,
--TR_Status int,
--TR_Apporval int,
--TR_MID nvarchar(50),
--TR_PIC nvarchar(50),
--TR_Shipment nvarchar(100),
--TR_File nvarchar(100),
--ACTUAL_OUTPUT float,
--WORKED_HOURS float,
--QUOTA float, 
--TR_UOM nvarchar(50), 
--PCP_ID nvarchar(50),
--Task_ID nvarchar(50),
--PC_ProcessCode nvarchar(50), 
--PCP_Project nvarchar(50)
--); 

--DECLARE @TemptaskDetails_@mPIC TABLE(
--RowNumber bigint,
--TR_Index bigint,
--WORKDATE Date,
--TR_ID nvarchar(100),
--TR_UID nvarchar(50), 
--TR_InDate DateTime,
--TR_OutDate DateTime,
--WORKED_HOURS float, 
--WASTE_HOURS float,
--X1 float,
--HRS_WASTE float,
--TR_Status int,
--TR_Apporval int,
--TR_MID nvarchar(50),
--TR_PIC nvarchar(50),
--TR_Shipment nvarchar(100),
--TR_File nvarchar(100),
--ACTUAL_OUTPUT float,
--QUOTA float, 
--TR_UOM nvarchar(50), 
--PCP_ID nvarchar(50),
--Task_ID nvarchar(50),
--PC_ProcessCode nvarchar(50), 
--PCP_Project nvarchar(50)
--); 

--DECLARE @TempidleDetails_@mPIC TABLE(
--IDLE_Index bigint,
--WORKDATE Date,
--IDLE_ID nvarchar(100),
--IDLE_UID nvarchar(50), 
--IDLE_InDate DateTime,
--IDLE_OutDate DateTime,
--IDLE_TIME float, 
--IDLE_Reason nvarchar(200),
--IDLE_MID nvarchar(50), 
--IDLE_PIC nvarchar(50), 
--IDLE_Project nvarchar(50)
--);

--INSERT INTO @TemptblDifference_@mPIC 
--	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ISNULL(CAST(d.TR_FileSize AS float),0) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ISNULL(CAST(d.TR_Quota AS float),0) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
--    FROM tbl_TaskRecordDetail d
--	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
--	WHERE d.TR_InDate BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC
--	ORDER BY d.TR_UID

--INSERT INTO @TemptaskDetails_@mPIC 
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST((cur.TR_InDate - previous.TR_OutDate) AS float),0) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + ISNULL(CAST((cur.TR_OutDate - cur.TR_InDate) AS float),0)) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)

--INSERT INTO @TempidleDetails_@mPIC 
--	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
--	FROM tbl_IDLEDetail i
--	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
--	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC
--;
--WITH approveDoneRecords AS(
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.[WORKED_HOURS], cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--),
--sumOfTapproveDoneRecords AS(
--	SELECT TOP (999999999999999999) CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID, SUM(cur.WORKED_HOURS) AS [WORKED_HOURS]
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID
--	ORDER BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID
--),
--sumOfTaskGap_WasteOurs AS(
--	SELECT CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID, ISNULL(SUM(CAST(cur.TR_InDate - previous.TR_OutDate AS float)), 0) AS [WASTE_HOURS]
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID
--),
--sumOfidleDetails AS (
--	SELECT TOP (999999999999999999) [WORKDATE], IDLE_UID, IDLE_MID, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
--	FROM @TempidleDetails_@mPIC 
--	GROUP BY [WORKDATE], IDLE_UID, IDLE_MID
--	ORDER BY [WORKDATE], IDLE_UID, IDLE_MID
--),

--X1 AS (
--	SELECT TOP (999999999999999999) WORKDATE, TR_UID, TR_MID, SUM(ACTUAL_OUTPUT) AS [OUTPUT], SUM(X1) AS [X1]
--	FROM @TemptaskDetails_@mPIC
--	GROUP BY WORKDATE, TR_UID, TR_MID
--	ORDER BY WORKDATE, TR_UID, TR_MID
--),

--Y AS (
--	SELECT TOP (999999999999999999) WK.WORKDATE, WK.TR_UID, WK.TR_MID,(ISNULL(WK.WORKED_HOURS,0)) AS [WORK_HOURS],(ISNULL(WK.WORKED_HOURS,0) + ISNULL(WHGAP.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
--	FROM sumOfTapproveDoneRecords WK
--	LEFT JOIN sumOfidleDetails IDLE ON WK.TR_UID =IDLE.IDLE_UID AND WK.WORKDATE = IDLE.WORKDATE AND WK.TR_MID=IDLE.IDLE_MID
--	LEFT JOIN sumOfTaskGap_WasteOurs WHGAP ON  WK.TR_UID = WHGAP.TR_UID AND WK.WORKDATE = WHGAP.WORKDATE AND WHGAP.TR_MID=WK.TR_MID
--),
--X3 AS (
--	SELECT TOP (999999999999999999) X.TR_UID, X.TR_MID, X.WORKDATE, [OUTPUT], X1, [WORK_HOURS], (X.X1/CASE SIGN(ISNULL(Y1.Y,1)) WHEN -1 THEN 1 ELSE (ISNULL(Y1.Y,1)) END )*100 AS [X3]
--	FROM Y Y1
--	LEFT JOIN X1 X ON X.TR_UID =Y1.TR_UID AND X.WORKDATE = Y1.WORKDATE AND X.TR_MID= Y1.TR_MID
--)

--SELECT WORKDATE, TR_UID AS [UID], TR_MID AS [TEAM],  ROUND(SUM([OUTPUT]),2) AS [OUTPUT], ROUND(SUM([WORK_HOURS]),2) AS [WORK HOURS], ROUND(SUM(X1),2) AS [X1], ROUND(SUM(X3),2) AS [X3] 
--FROM X3 WITH (NOLOCK)
--GROUP BY WORKDATE, TR_UID, TR_MID
--ORDER BY X3 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byTeam_User_FilterByManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byTeam_User_FilterByManager] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mMID nvarchar(20)

AS
/* Wokred Shift for 9 hours */
DECLARE @K int;

SET @K= 32400;

DECLARE @TemptblDifference_@mPIC TABLE(
RowNumber bigint,
TR_Index bigint,
WORKDATE Date,
TR_ID nvarchar(100),
TR_UID nvarchar(50), 
TR_InDate DateTime,
TR_OutDate DateTime,
TR_Status int,
TR_Apporval int,
TR_MID nvarchar(50),
TR_PIC nvarchar(50),
TR_Shipment nvarchar(100),
TR_File nvarchar(100),
ACTUAL_OUTPUT float,
WORKED_HOURS float,
QUOTA float, 
TR_UOM nvarchar(50), 
PCP_ID nvarchar(50),
Task_ID nvarchar(50),
PC_ProcessCode nvarchar(50), 
PCP_Project nvarchar(50)
); 

DECLARE @TemptaskDetails_@mPIC TABLE(
RowNumber bigint,
TR_Index bigint,
WORKDATE Date,
TR_ID nvarchar(100),
TR_UID nvarchar(50), 
TR_InDate DateTime,
TR_OutDate DateTime,
WORKED_HOURS float, 
WASTE_HOURS float,
X1 float,
HRS_WASTE float,
TR_Status int,
TR_Apporval int,
TR_MID nvarchar(50),
TR_PIC nvarchar(50),
TR_Shipment nvarchar(100),
TR_File nvarchar(100),
ACTUAL_OUTPUT float,
QUOTA float, 
TR_UOM nvarchar(50), 
PCP_ID nvarchar(50),
Task_ID nvarchar(50),
PC_ProcessCode nvarchar(50), 
PCP_Project nvarchar(50)
); 

DECLARE @TempidleDetails_@mPIC TABLE(
IDLE_Index bigint,
WORKDATE Date,
IDLE_ID nvarchar(100),
IDLE_UID nvarchar(50), 
IDLE_InDate DateTime,
IDLE_OutDate DateTime,
IDLE_TIME float, 
IDLE_Reason nvarchar(200),
IDLE_MID nvarchar(50), 
IDLE_PIC nvarchar(50), 
IDLE_Project nvarchar(50)
);

INSERT INTO @TemptblDifference_@mPIC 
	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ISNULL(CAST(d.TR_FileSize AS float),0) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ISNULL(CAST(d.TR_Quota AS float),0) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
    FROM tbl_TaskRecordDetail d
	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
	WHERE d.TR_InDate BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC AND d.TR_MID=@mMID
	ORDER BY d.TR_UID

INSERT INTO @TemptaskDetails_@mPIC 
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST((cur.TR_InDate - previous.TR_OutDate) AS float),0) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + ISNULL(CAST((cur.TR_OutDate - cur.TR_InDate) AS float),0)) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)

INSERT INTO @TempidleDetails_@mPIC 
	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
	FROM tbl_IDLEDetail i
	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC AND h.IDLE_MID=@mMID
;
WITH approveDoneRecords AS(
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.[WORKED_HOURS], cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
),
sumOfTapproveDoneRecords AS(
	SELECT TOP (999999999999999999) CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID, SUM(cur.WORKED_HOURS) AS [WORKED_HOURS]
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID
	ORDER BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID
),
sumOfTaskGap_WasteOurs AS(
	SELECT CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID, ISNULL(SUM(CAST(cur.TR_InDate - previous.TR_OutDate AS float)), 0) AS [WASTE_HOURS]
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID
),
sumOfidleDetails AS (
	SELECT TOP (999999999999999999) [WORKDATE], IDLE_UID, IDLE_MID, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
	FROM @TempidleDetails_@mPIC 
	GROUP BY [WORKDATE], IDLE_UID, IDLE_MID
	ORDER BY [WORKDATE], IDLE_UID, IDLE_MID
),

X1 AS (
	SELECT TOP (999999999999999999) WORKDATE, TR_UID, TR_MID, SUM(ACTUAL_OUTPUT) AS [OUTPUT], SUM(X1) AS [X1]
	FROM @TemptaskDetails_@mPIC
	GROUP BY WORKDATE, TR_UID, TR_MID
	ORDER BY WORKDATE, TR_UID, TR_MID
),

Y AS (
	SELECT TOP (999999999999999999) WK.WORKDATE, WK.TR_UID, WK.TR_MID,(ISNULL(WK.WORKED_HOURS,0)) AS [WORK_HOURS],(ISNULL(WK.WORKED_HOURS,0) + ISNULL(WHGAP.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
	FROM sumOfTapproveDoneRecords WK
	LEFT JOIN sumOfidleDetails IDLE ON WK.TR_UID =IDLE.IDLE_UID AND WK.WORKDATE = IDLE.WORKDATE AND WK.TR_MID=IDLE.IDLE_MID
	LEFT JOIN sumOfTaskGap_WasteOurs WHGAP ON  WK.TR_UID = WHGAP.TR_UID AND WK.WORKDATE = WHGAP.WORKDATE AND WHGAP.TR_MID=WK.TR_MID
),
X3 AS (
	SELECT TOP (999999999999999999) X.TR_UID, X.TR_MID, X.WORKDATE, [OUTPUT], X1, [WORK_HOURS], (X.X1/CASE SIGN(ISNULL(Y1.Y,1)) WHEN -1 THEN 1 ELSE (ISNULL(Y1.Y,1)) END )*100 AS [X3]
	FROM Y Y1
	LEFT JOIN X1 X ON X.TR_UID =Y1.TR_UID AND X.WORKDATE = Y1.WORKDATE AND X.TR_MID= Y1.TR_MID
)

SELECT WORKDATE, TR_UID AS [UID], TR_MID AS [TEAM],  ROUND(SUM([OUTPUT]),2) AS [OUTPUT], ROUND(SUM([WORK_HOURS]),2) AS [WORK HOURS], ROUND(SUM(X1),2) AS [X1], ROUND(SUM(X3),2) AS [X3] 
FROM X3 WITH (NOLOCK)
GROUP BY WORKDATE, TR_UID, TR_MID
ORDER BY X3 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byTeam_User_FilterByProject]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byTeam_User_FilterByProject] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mProject nvarchar(30)

AS
/* Wokred Shift for 9 hours */
DECLARE @K int;

SET @K= 32400;

DECLARE @TemptblDifference_@mPIC TABLE(
RowNumber bigint,
TR_Index bigint,
WORKDATE Date,
TR_ID nvarchar(100),
TR_UID nvarchar(50), 
TR_InDate DateTime,
TR_OutDate DateTime,
TR_Status int,
TR_Apporval int,
TR_MID nvarchar(50),
TR_PIC nvarchar(50),
TR_Shipment nvarchar(100),
TR_File nvarchar(100),
ACTUAL_OUTPUT float,
WORKED_HOURS float,
QUOTA float, 
TR_UOM nvarchar(50), 
PCP_ID nvarchar(50),
Task_ID nvarchar(50),
PC_ProcessCode nvarchar(50), 
PCP_Project nvarchar(50)
); 

DECLARE @TemptaskDetails_@mPIC TABLE(
RowNumber bigint,
TR_Index bigint,
WORKDATE Date,
TR_ID nvarchar(100),
TR_UID nvarchar(50), 
TR_InDate DateTime,
TR_OutDate DateTime,
WORKED_HOURS float, 
WASTE_HOURS float,
X1 float,
HRS_WASTE float,
TR_Status int,
TR_Apporval int,
TR_MID nvarchar(50),
TR_PIC nvarchar(50),
TR_Shipment nvarchar(100),
TR_File nvarchar(100),
ACTUAL_OUTPUT float,
QUOTA float, 
TR_UOM nvarchar(50), 
PCP_ID nvarchar(50),
Task_ID nvarchar(50),
PC_ProcessCode nvarchar(50), 
PCP_Project nvarchar(50)
); 

DECLARE @TempidleDetails_@mPIC TABLE(
IDLE_Index bigint,
WORKDATE Date,
IDLE_ID nvarchar(100),
IDLE_UID nvarchar(50), 
IDLE_InDate DateTime,
IDLE_OutDate DateTime,
IDLE_TIME float, 
IDLE_Reason nvarchar(200),
IDLE_MID nvarchar(50), 
IDLE_PIC nvarchar(50), 
IDLE_Project nvarchar(50)
);

INSERT INTO @TemptblDifference_@mPIC 
	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ISNULL(CAST(d.TR_FileSize AS float),0) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ISNULL(CAST(d.TR_Quota AS float),0) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
    FROM tbl_TaskRecordDetail d
	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
	WHERE d.TR_InDate BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC AND p.PCP_Project=@mProject
	ORDER BY d.TR_UID

INSERT INTO @TemptaskDetails_@mPIC 
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST((cur.TR_InDate - previous.TR_OutDate) AS float),0) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + ISNULL(CAST((cur.TR_OutDate - cur.TR_InDate) AS float),0)) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)

INSERT INTO @TempidleDetails_@mPIC 
	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
	FROM tbl_IDLEDetail i
	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC AND h.IDLE_Project=@mProject
;
WITH approveDoneRecords AS(
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.[WORKED_HOURS], cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
),
sumOfTapproveDoneRecords AS(
	SELECT TOP (999999999999999999) CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID, SUM(cur.WORKED_HOURS) AS [WORKED_HOURS]
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID
	ORDER BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID
),
sumOfTaskGap_WasteOurs AS(
	SELECT CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID, ISNULL(SUM(CAST(cur.TR_InDate - previous.TR_OutDate AS float)), 0) AS [WASTE_HOURS]
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID
),
sumOfidleDetails AS (
	SELECT TOP (999999999999999999) [WORKDATE], IDLE_UID, IDLE_MID, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
	FROM @TempidleDetails_@mPIC 
	GROUP BY [WORKDATE], IDLE_UID, IDLE_MID
	ORDER BY [WORKDATE], IDLE_UID, IDLE_MID
),

X1 AS (
	SELECT TOP (999999999999999999) WORKDATE, TR_UID, TR_MID, SUM(ACTUAL_OUTPUT) AS [OUTPUT], SUM(X1) AS [X1]
	FROM @TemptaskDetails_@mPIC
	GROUP BY WORKDATE, TR_UID, TR_MID
	ORDER BY WORKDATE, TR_UID, TR_MID
),

Y AS (
	SELECT TOP (999999999999999999) WK.WORKDATE, WK.TR_UID, WK.TR_MID,(ISNULL(WK.WORKED_HOURS,0)) AS [WORK_HOURS],(ISNULL(WK.WORKED_HOURS,0) + ISNULL(WHGAP.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
	FROM sumOfTapproveDoneRecords WK
	LEFT JOIN sumOfidleDetails IDLE ON WK.TR_UID =IDLE.IDLE_UID AND WK.WORKDATE = IDLE.WORKDATE AND WK.TR_MID=IDLE.IDLE_MID
	LEFT JOIN sumOfTaskGap_WasteOurs WHGAP ON  WK.TR_UID = WHGAP.TR_UID AND WK.WORKDATE = WHGAP.WORKDATE AND WHGAP.TR_MID=WK.TR_MID
),
X3 AS (
	SELECT TOP (999999999999999999) X.TR_UID, X.TR_MID, X.WORKDATE, [OUTPUT], X1, [WORK_HOURS], (X.X1/CASE SIGN(ISNULL(Y1.Y,1)) WHEN -1 THEN 1 ELSE (ISNULL(Y1.Y,1)) END )*100 AS [X3]
	FROM Y Y1
	LEFT JOIN X1 X ON X.TR_UID =Y1.TR_UID AND X.WORKDATE = Y1.WORKDATE AND X.TR_MID= Y1.TR_MID
)

SELECT WORKDATE, TR_UID AS [UID], TR_MID AS [TEAM],  ROUND(SUM([OUTPUT]),2) AS [OUTPUT], ROUND(SUM([WORK_HOURS]),2) AS [WORK HOURS], ROUND(SUM(X1),2) AS [X1], ROUND(SUM(X3),2) AS [X3] 
FROM X3 WITH (NOLOCK)
GROUP BY WORKDATE, TR_UID, TR_MID
ORDER BY X3 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byTeam_User_FilterByUser]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byTeam_User_FilterByUser] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mUID nvarchar(20)

AS
/* Wokred Shift for 9 hours */
DECLARE @K int;

SET @K= 32400;

DECLARE @TemptblDifference_@mPIC TABLE(
RowNumber bigint,
TR_Index bigint,
WORKDATE Date,
TR_ID nvarchar(100),
TR_UID nvarchar(50), 
TR_InDate DateTime,
TR_OutDate DateTime,
TR_Status int,
TR_Apporval int,
TR_MID nvarchar(50),
TR_PIC nvarchar(50),
TR_Shipment nvarchar(100),
TR_File nvarchar(100),
ACTUAL_OUTPUT float,
WORKED_HOURS float,
QUOTA float, 
TR_UOM nvarchar(50), 
PCP_ID nvarchar(50),
Task_ID nvarchar(50),
PC_ProcessCode nvarchar(50), 
PCP_Project nvarchar(50)
); 

DECLARE @TemptaskDetails_@mPIC TABLE(
RowNumber bigint,
TR_Index bigint,
WORKDATE Date,
TR_ID nvarchar(100),
TR_UID nvarchar(50), 
TR_InDate DateTime,
TR_OutDate DateTime,
WORKED_HOURS float, 
WASTE_HOURS float,
X1 float,
HRS_WASTE float,
TR_Status int,
TR_Apporval int,
TR_MID nvarchar(50),
TR_PIC nvarchar(50),
TR_Shipment nvarchar(100),
TR_File nvarchar(100),
ACTUAL_OUTPUT float,
QUOTA float, 
TR_UOM nvarchar(50), 
PCP_ID nvarchar(50),
Task_ID nvarchar(50),
PC_ProcessCode nvarchar(50), 
PCP_Project nvarchar(50)
); 

DECLARE @TempidleDetails_@mPIC TABLE(
IDLE_Index bigint,
WORKDATE Date,
IDLE_ID nvarchar(100),
IDLE_UID nvarchar(50), 
IDLE_InDate DateTime,
IDLE_OutDate DateTime,
IDLE_TIME float, 
IDLE_Reason nvarchar(200),
IDLE_MID nvarchar(50), 
IDLE_PIC nvarchar(50), 
IDLE_Project nvarchar(50)
);

INSERT INTO @TemptblDifference_@mPIC 
	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ISNULL(CAST(d.TR_FileSize AS float),0) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ISNULL(CAST(d.TR_Quota AS float),0) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
    FROM tbl_TaskRecordDetail d
	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
	WHERE d.TR_InDate BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC AND d.TR_UID=@mUID
	ORDER BY d.TR_UID

INSERT INTO @TemptaskDetails_@mPIC 
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST((cur.TR_InDate - previous.TR_OutDate) AS float),0) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + ISNULL(CAST((cur.TR_OutDate - cur.TR_InDate) AS float),0)) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)

INSERT INTO @TempidleDetails_@mPIC 
	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
	FROM tbl_IDLEDetail i
	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC AND h.IDLE_UID=@mUID
;
WITH approveDoneRecords AS(
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.[WORKED_HOURS], cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
),
sumOfTapproveDoneRecords AS(
	SELECT TOP (999999999999999999) CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID, SUM(cur.WORKED_HOURS) AS [WORKED_HOURS]
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID
	ORDER BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID
),
sumOfTaskGap_WasteOurs AS(
	SELECT CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID, ISNULL(SUM(CAST(cur.TR_InDate - previous.TR_OutDate AS float)), 0) AS [WASTE_HOURS]
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID
),
sumOfidleDetails AS (
	SELECT TOP (999999999999999999) [WORKDATE], IDLE_UID, IDLE_MID, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
	FROM @TempidleDetails_@mPIC 
	GROUP BY [WORKDATE], IDLE_UID, IDLE_MID
	ORDER BY [WORKDATE], IDLE_UID, IDLE_MID
),

X1 AS (
	SELECT TOP (999999999999999999) WORKDATE, TR_UID, TR_MID, SUM(ACTUAL_OUTPUT) AS [OUTPUT], SUM(X1) AS [X1]
	FROM @TemptaskDetails_@mPIC
	GROUP BY WORKDATE, TR_UID, TR_MID
	ORDER BY WORKDATE, TR_UID, TR_MID
),

Y AS (
	SELECT TOP (999999999999999999) WK.WORKDATE, WK.TR_UID, WK.TR_MID,(ISNULL(WK.WORKED_HOURS,0)) AS [WORK_HOURS],(ISNULL(WK.WORKED_HOURS,0) + ISNULL(WHGAP.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
	FROM sumOfTapproveDoneRecords WK
	LEFT JOIN sumOfidleDetails IDLE ON WK.TR_UID =IDLE.IDLE_UID AND WK.WORKDATE = IDLE.WORKDATE AND WK.TR_MID=IDLE.IDLE_MID
	LEFT JOIN sumOfTaskGap_WasteOurs WHGAP ON  WK.TR_UID = WHGAP.TR_UID AND WK.WORKDATE = WHGAP.WORKDATE AND WHGAP.TR_MID=WK.TR_MID
),
X3 AS (
	SELECT TOP (999999999999999999) X.TR_UID, X.TR_MID, X.WORKDATE, [OUTPUT], X1, [WORK_HOURS], (X.X1/CASE SIGN(ISNULL(Y1.Y,1)) WHEN -1 THEN 1 ELSE (ISNULL(Y1.Y,1)) END )*100 AS [X3]
	FROM Y Y1
	LEFT JOIN X1 X ON X.TR_UID =Y1.TR_UID AND X.WORKDATE = Y1.WORKDATE AND X.TR_MID= Y1.TR_MID
)

SELECT WORKDATE, TR_UID AS [UID], TR_MID AS [TEAM],  ROUND(SUM([OUTPUT]),2) AS [OUTPUT], ROUND(SUM([WORK_HOURS]),2) AS [WORK HOURS], ROUND(SUM(X1),2) AS [X1], ROUND(SUM(X3),2) AS [X3] 
FROM X3 WITH (NOLOCK)
GROUP BY WORKDATE, TR_UID, TR_MID
ORDER BY X3 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byUser_AllDataSet]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byUser_AllDataSet] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime

AS
/****** Script for SelectTopNRows command from SSMS  ******/

SELECT --[WORKDATE],
      [TR_ID] AS [RECORD ID]
      ,[TR_UID] AS [UID]
	  ,[PCP_Project] AS [PROJECT]
	  ,[TR_Shipment] AS [SHIPMENT/BATCH]
	  ,[TR_File] AS [FILE NAME]
	  ,[PCP_ID] AS [JOB CODE]
	  ,[PC_ProcessCode] AS [ITEM CODE]
	  ,[Task_ID] AS [TASK CODE]
	  ,[TR_InDate] AS [STARTED DATE TIME]
	  ,[TR_OutDate] AS [FINISHED DATE TIME]
	  ,ROUND([WORKED_HOURS],2) AS [TOTAL TITO TIME]
      --,[TR_ActualTaskIn] AS [TASKED-IN]
	  ,[TR_Status] AS [TASK STATUS]
      ,[TR_Apporval] AS [APPROVAL STATUS]
	  ,[TR_MID] AS [IMMEDIATE SUPERVISOR]
      ,[TR_PIC] AS [PIC]
	  ,[USER_OUTPUT] AS [OUTPUT]
	  ,[QUOTA] AS [QUOTA]
	  ,[TR_UOM] AS [UOM]
      ,ROUND([X1],2) AS [X1]
      ,ROUND([Y],2) AS [Y]
      ,ROUND([X3],2) AS [X3]
      --,[LOGIN]
      --,[LOGOUT]
      --,ROUND([ACTUAL_WORKED_HOURS],2) AS [ACTUAL WORKED HOURS]
      --,[ACTUAL_OUTPUT] AS [ACTUAL OUTPUT]      
  FROM [CITITO].[dbo].[tbl_Report_TemptaskDetailsQUOTA_Updated]
  WHERE WORKDATE BETWEEN @mFrom AND @mTo  AND TR_PIC=@mPIC

--SELECT [WORKDATE]
--      ,[TR_ID] AS [RECORD ID]
--      ,[TR_UID] AS [UID]
--      ,[TR_ActualTaskIn] AS [TASKED-IN]
--      ,[TR_OutDate] AS [TASKED-OUT]
--      ,ROUND([WORKED_HOURS],2) AS [TOTAL TITO HOURS]
--      ,[LOGIN]
--      ,[LOGOUT]
--      ,ROUND([ACTUAL_WORKED_HOURS],2) AS [ACTUAL WORKED HOURS]
--      ,[TR_Status] AS [TASK STATUS]
--      ,[TR_Apporval] AS [APPROVAL STATUS]
--      ,[TR_MID] AS [IMMEDIATE SUPERVISOR]
--      ,[TR_PIC] AS [PIC]
--      ,[TR_Shipment] AS [SHIPMENT/BATCH]
--      ,[TR_File] AS [FILE NAME]
--      ,[USER_OUTPUT] AS [OUTPUT]
--      ,[ACTUAL_OUTPUT] AS [ACTUAL OUTPUT]
--      ,[QUOTA] AS [QUOTA]
--      ,[TR_UOM] AS [UOM]
--      ,[PCP_ID] AS [JOB CODE]
--      ,[Task_ID] [TASK CODE]
--      ,[PC_ProcessCode] AS [ITEM CODE]
--      ,[PCP_Project] AS [PROJECT]
--      ,ROUND([X1],2) AS [X1]
--      ,ROUND([Y],2) AS [Y]
--      ,ROUND([X3],2) AS [X3]
--  FROM [CITITO].[dbo].[tbl_Report_TemptaskDetailsQUOTA_Updated]
--  WHERE WORKDATE BETWEEN @mFrom AND @mTo  AND TR_PIC=@mPIC
GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byUser_AllDataSetFilteredByItemCode]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byUser_AllDataSetFilteredByItemCode] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mItemCode nvarchar(50)

AS
/****** Script for SelectTopNRows command from SSMS  ******/


SELECT --[WORKDATE],
      [TR_ID] AS [RECORD ID]
      ,[TR_UID] AS [UID]
	  ,[PCP_Project] AS [PROJECT]
	  ,[TR_Shipment] AS [SHIPMENT/BATCH]
	  ,[TR_File] AS [FILE NAME]
	  ,[PCP_ID] AS [JOB CODE]
	  ,[PC_ProcessCode] AS [ITEM CODE]
	  ,[Task_ID] AS [TASK CODE]
	  ,[TR_InDate] AS [STARTED DATE TIME]
	  ,[TR_OutDate] AS [FINISHED DATE TIME]
	  ,ROUND([WORKED_HOURS],2) AS [TOTAL TITO TIME]
      --,[TR_ActualTaskIn] AS [TASKED-IN]
	  ,[TR_Status] AS [TASK STATUS]
      ,[TR_Apporval] AS [APPROVAL STATUS]
	  ,[TR_MID] AS [IMMEDIATE SUPERVISOR]
      ,[TR_PIC] AS [PIC]
	  ,[USER_OUTPUT] AS [OUTPUT]
	  ,[QUOTA] AS [QUOTA]
	  ,[TR_UOM] AS [UOM]
      ,ROUND([X1],2) AS [X1]
      ,ROUND([Y],2) AS [Y]
      ,ROUND([X3],2) AS [X3]
      --,[LOGIN]
      --,[LOGOUT]
      --,ROUND([ACTUAL_WORKED_HOURS],2) AS [ACTUAL WORKED HOURS]
      --,[ACTUAL_OUTPUT] AS [ACTUAL OUTPUT]      
  FROM [CITITO].[dbo].[tbl_Report_TemptaskDetailsQUOTA_Updated]
  WHERE WORKDATE BETWEEN @mFrom AND @mTo  AND TR_PIC=@mPIC AND PC_ProcessCode=@mItemCode


--SELECT [WORKDATE]
--      ,[TR_ID] AS [RECORD ID]
--      ,[TR_UID] AS [UID]
--      ,[TR_ActualTaskIn] AS [TASKED-IN]
--      ,[TR_OutDate] AS [TASKED-OUT]
--      ,ROUND([WORKED_HOURS],2) AS [TOTAL TITO HOURS]
--      ,[LOGIN]
--      ,[LOGOUT]
--      ,ROUND([ACTUAL_WORKED_HOURS],2) AS [ACTUAL WORKED HOURS]
--      ,[TR_Status] AS [TASK STATUS]
--      ,[TR_Apporval] AS [APPROVAL STATUS]
--      ,[TR_MID] AS [IMMEDIATE SUPERVISOR]
--      ,[TR_PIC] AS [PIC]
--      ,[TR_Shipment] AS [SHIPMENT/BATCH]
--      ,[TR_File] AS [FILE NAME]
--      ,[USER_OUTPUT] AS [OUTPUT]
--      ,[ACTUAL_OUTPUT] AS [ACTUAL OUTPUT]
--      ,[QUOTA] AS [QUOTA]
--      ,[TR_UOM] AS [UOM]
--      ,[PCP_ID] AS [JOB CODE]
--      ,[Task_ID] [TASK CODE]
--      ,[PC_ProcessCode] AS [ITEM CODE]
--      ,[PCP_Project] AS [PROJECT]
--      ,ROUND([X1],2) AS [X1]
--      ,ROUND([Y],2) AS [Y]
--      ,ROUND([X3],2) AS [X3]
--  FROM [CITITO].[dbo].[tbl_Report_TemptaskDetailsQUOTA_Updated]
--  WHERE WORKDATE BETWEEN @mFrom AND @mTo  AND TR_PIC=@mPIC AND PC_ProcessCode=@mItemCode

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byUser_AllDataSetFilteredByItemCodeAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byUser_AllDataSetFilteredByItemCodeAndManager] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mItemCode nvarchar(50), @mMUID nvarchar(20)

AS
/****** Script for SelectTopNRows command from SSMS  ******/


SELECT --[WORKDATE],
      [TR_ID] AS [RECORD ID]
      ,[TR_UID] AS [UID]
	  ,[PCP_Project] AS [PROJECT]
	  ,[TR_Shipment] AS [SHIPMENT/BATCH]
	  ,[TR_File] AS [FILE NAME]
	  ,[PCP_ID] AS [JOB CODE]
	  ,[PC_ProcessCode] AS [ITEM CODE]
	  ,[Task_ID] AS [TASK CODE]
	  ,[TR_InDate] AS [STARTED DATE TIME]
	  ,[TR_OutDate] AS [FINISHED DATE TIME]
	  ,ROUND([WORKED_HOURS],2) AS [TOTAL TITO TIME]
      --,[TR_ActualTaskIn] AS [TASKED-IN]
	  ,[TR_Status] AS [TASK STATUS]
      ,[TR_Apporval] AS [APPROVAL STATUS]
	  ,[TR_MID] AS [IMMEDIATE SUPERVISOR]
      ,[TR_PIC] AS [PIC]
	  ,[USER_OUTPUT] AS [OUTPUT]
	  ,[QUOTA] AS [QUOTA]
	  ,[TR_UOM] AS [UOM]
      ,ROUND([X1],2) AS [X1]
      ,ROUND([Y],2) AS [Y]
      ,ROUND([X3],2) AS [X3]
      --,[LOGIN]
      --,[LOGOUT]
      --,ROUND([ACTUAL_WORKED_HOURS],2) AS [ACTUAL WORKED HOURS]
      --,[ACTUAL_OUTPUT] AS [ACTUAL OUTPUT]      
  FROM [CITITO].[dbo].[tbl_Report_TemptaskDetailsQUOTA_Updated]
  WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND TR_MID=@mMUID AND PC_ProcessCode=@mItemCode

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byUser_AllDataSetFilteredByManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byUser_AllDataSetFilteredByManager] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mManager nvarchar(50)

AS
/****** Script for SelectTopNRows command from SSMS  ******/

SELECT --[WORKDATE],
      [TR_ID] AS [RECORD ID]
      ,[TR_UID] AS [UID]
	  ,[PCP_Project] AS [PROJECT]
	  ,[TR_Shipment] AS [SHIPMENT/BATCH]
	  ,[TR_File] AS [FILE NAME]
	  ,[PCP_ID] AS [JOB CODE]
	  ,[PC_ProcessCode] AS [ITEM CODE]
	  ,[Task_ID] AS [TASK CODE]
	  ,[TR_InDate] AS [STARTED DATE TIME]
	  ,[TR_OutDate] AS [FINISHED DATE TIME]
	  ,ROUND([WORKED_HOURS],2) AS [TOTAL TITO TIME]
      --,[TR_ActualTaskIn] AS [TASKED-IN]
	  ,[TR_Status] AS [TASK STATUS]
      ,[TR_Apporval] AS [APPROVAL STATUS]
	  ,[TR_MID] AS [IMMEDIATE SUPERVISOR]
      ,[TR_PIC] AS [PIC]
	  ,[USER_OUTPUT] AS [OUTPUT]
	  ,[QUOTA] AS [QUOTA]
	  ,[TR_UOM] AS [UOM]
      ,ROUND([X1],2) AS [X1]
      ,ROUND([Y],2) AS [Y]
      ,ROUND([X3],2) AS [X3]
      --,[LOGIN]
      --,[LOGOUT]
      --,ROUND([ACTUAL_WORKED_HOURS],2) AS [ACTUAL WORKED HOURS]
      --,[ACTUAL_OUTPUT] AS [ACTUAL OUTPUT]      
  FROM [CITITO].[dbo].[tbl_Report_TemptaskDetailsQUOTA_Updated]
	WHERE WORKDATE BETWEEN @mFrom AND @mTo  AND TR_PIC=@mPIC AND TR_MID=@mManager

--SELECT [WORKDATE]
--      ,[TR_ID] AS [RECORD ID]
--      ,[TR_UID] AS [UID]
--      ,[TR_ActualTaskIn] AS [TASKED-IN]
--      ,[TR_OutDate] AS [TASKED-OUT]
--      ,ROUND([WORKED_HOURS],2) AS [TOTAL TITO HOURS]
--      ,[LOGIN]
--      ,[LOGOUT]
--      ,ROUND([ACTUAL_WORKED_HOURS],2) AS [ACTUAL WORKED HOURS]
--      ,[TR_Status] AS [TASK STATUS]
--      ,[TR_Apporval] AS [APPROVAL STATUS]
--      ,[TR_MID] AS [IMMEDIATE SUPERVISOR]
--      ,[TR_PIC] AS [PIC]
--      ,[TR_Shipment] AS [SHIPMENT/BATCH]
--      ,[TR_File] AS [FILE NAME]
--      ,[USER_OUTPUT] AS [OUTPUT]
--      ,[ACTUAL_OUTPUT] AS [ACTUAL OUTPUT]
--      ,[QUOTA] AS [QUOTA]
--      ,[TR_UOM] AS [UOM]
--      ,[PCP_ID] AS [JOB CODE]
--      ,[Task_ID] [TASK CODE]
--      ,[PC_ProcessCode] AS [ITEM CODE]
--      ,[PCP_Project] AS [PROJECT]
--      ,ROUND([X1],2) AS [X1]
--      ,ROUND([Y],2) AS [Y]
--      ,ROUND([X3],2) AS [X3]
--  FROM [CITITO].[dbo].[tbl_Report_TemptaskDetailsQUOTA_Updated]
--  WHERE WORKDATE BETWEEN @mFrom AND @mTo  AND TR_PIC=@mPIC AND TR_MID=@mManager
GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byUser_AllDataSetFilteredByProject]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byUser_AllDataSetFilteredByProject] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mProject nvarchar(50)

AS
/****** Script for SelectTopNRows command from SSMS  ******/

SELECT --[WORKDATE],
      [TR_ID] AS [RECORD ID]
      ,[TR_UID] AS [UID]
	  ,[PCP_Project] AS [PROJECT]
	  ,[TR_Shipment] AS [SHIPMENT/BATCH]
	  ,[TR_File] AS [FILE NAME]
	  ,[PCP_ID] AS [JOB CODE]
	  ,[PC_ProcessCode] AS [ITEM CODE]
	  ,[Task_ID] AS [TASK CODE]
	  ,[TR_InDate] AS [STARTED DATE TIME]
	  ,[TR_OutDate] AS [FINISHED DATE TIME]
	  ,ROUND([WORKED_HOURS],2) AS [TOTAL TITO TIME]
      --,[TR_ActualTaskIn] AS [TASKED-IN]
	  ,[TR_Status] AS [TASK STATUS]
      ,[TR_Apporval] AS [APPROVAL STATUS]
	  ,[TR_MID] AS [IMMEDIATE SUPERVISOR]
      ,[TR_PIC] AS [PIC]
	  ,[USER_OUTPUT] AS [OUTPUT]
	  ,[QUOTA] AS [QUOTA]
	  ,[TR_UOM] AS [UOM]
      ,ROUND([X1],2) AS [X1]
      ,ROUND([Y],2) AS [Y]
      ,ROUND([X3],2) AS [X3]
      --,[LOGIN]
      --,[LOGOUT]
      --,ROUND([ACTUAL_WORKED_HOURS],2) AS [ACTUAL WORKED HOURS]
      --,[ACTUAL_OUTPUT] AS [ACTUAL OUTPUT]      
  FROM [CITITO].[dbo].[tbl_Report_TemptaskDetailsQUOTA_Updated]
  WHERE WORKDATE BETWEEN @mFrom AND @mTo  AND TR_PIC=@mPIC AND PCP_Project=@mProject


--SELECT [WORKDATE]
--      ,[TR_ID] AS [RECORD ID]
--      ,[TR_UID] AS [UID]
--      ,[TR_ActualTaskIn] AS [TASKED-IN]
--      ,[TR_OutDate] AS [TASKED-OUT]
--      ,ROUND([WORKED_HOURS],2) AS [TOTAL TITO HOURS]
--      ,[LOGIN]
--      ,[LOGOUT]
--      ,ROUND([ACTUAL_WORKED_HOURS],2) AS [ACTUAL WORKED HOURS]
--      ,[TR_Status] AS [TASK STATUS]
--      ,[TR_Apporval] AS [APPROVAL STATUS]
--      ,[TR_MID] AS [IMMEDIATE SUPERVISOR]
--      ,[TR_PIC] AS [PIC]
--      ,[TR_Shipment] AS [SHIPMENT/BATCH]
--      ,[TR_File] AS [FILE NAME]
--      ,[USER_OUTPUT] AS [OUTPUT]
--      ,[ACTUAL_OUTPUT] AS [ACTUAL OUTPUT]
--      ,[QUOTA] AS [QUOTA]
--      ,[TR_UOM] AS [UOM]
--      ,[PCP_ID] AS [JOB CODE]
--      ,[Task_ID] [TASK CODE]
--      ,[PC_ProcessCode] AS [ITEM CODE]
--      ,[PCP_Project] AS [PROJECT]
--      ,ROUND([X1],2) AS [X1]
--      ,ROUND([Y],2) AS [Y]
--      ,ROUND([X3],2) AS [X3]
--  FROM [CITITO].[dbo].[tbl_Report_TemptaskDetailsQUOTA_Updated]
--  WHERE WORKDATE BETWEEN @mFrom AND @mTo  AND TR_PIC=@mPIC AND PCP_Project=@mProject

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byUser_AllDataSetFilteredByProjectAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byUser_AllDataSetFilteredByProjectAndManager] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mProject nvarchar(50), @mMUID nvarchar(20)

AS
/****** Script for SelectTopNRows command from SSMS  ******/

SELECT --[WORKDATE],
      [TR_ID] AS [RECORD ID]
      ,[TR_UID] AS [UID]
	  ,[PCP_Project] AS [PROJECT]
	  ,[TR_Shipment] AS [SHIPMENT/BATCH]
	  ,[TR_File] AS [FILE NAME]
	  ,[PCP_ID] AS [JOB CODE]
	  ,[PC_ProcessCode] AS [ITEM CODE]
	  ,[Task_ID] AS [TASK CODE]
	  ,[TR_InDate] AS [STARTED DATE TIME]
	  ,[TR_OutDate] AS [FINISHED DATE TIME]
	  ,ROUND([WORKED_HOURS],2) AS [TOTAL TITO TIME]
      --,[TR_ActualTaskIn] AS [TASKED-IN]
	  ,[TR_Status] AS [TASK STATUS]
      ,[TR_Apporval] AS [APPROVAL STATUS]
	  ,[TR_MID] AS [IMMEDIATE SUPERVISOR]
      ,[TR_PIC] AS [PIC]
	  ,[USER_OUTPUT] AS [OUTPUT]
	  ,[QUOTA] AS [QUOTA]
	  ,[TR_UOM] AS [UOM]
      ,ROUND([X1],2) AS [X1]
      ,ROUND([Y],2) AS [Y]
      ,ROUND([X3],2) AS [X3]
      --,[LOGIN]
      --,[LOGOUT]
      --,ROUND([ACTUAL_WORKED_HOURS],2) AS [ACTUAL WORKED HOURS]
      --,[ACTUAL_OUTPUT] AS [ACTUAL OUTPUT]      
  FROM [CITITO].[dbo].[tbl_Report_TemptaskDetailsQUOTA_Updated]
  WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND TR_MID=@mMUID AND PCP_Project=@mProject

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byUser_AllDataSetFilteredByTaskCode]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byUser_AllDataSetFilteredByTaskCode] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mTaskCode nvarchar(50)

AS
/****** Script for SelectTopNRows command from SSMS  ******/

SELECT --[WORKDATE],
      [TR_ID] AS [RECORD ID]
      ,[TR_UID] AS [UID]
	  ,[PCP_Project] AS [PROJECT]
	  ,[TR_Shipment] AS [SHIPMENT/BATCH]
	  ,[TR_File] AS [FILE NAME]
	  ,[PCP_ID] AS [JOB CODE]
	  ,[PC_ProcessCode] AS [ITEM CODE]
	  ,[Task_ID] AS [TASK CODE]
	  ,[TR_InDate] AS [STARTED DATE TIME]
	  ,[TR_OutDate] AS [FINISHED DATE TIME]
	  ,ROUND([WORKED_HOURS],2) AS [TOTAL TITO TIME]
      --,[TR_ActualTaskIn] AS [TASKED-IN]
	  ,[TR_Status] AS [TASK STATUS]
      ,[TR_Apporval] AS [APPROVAL STATUS]
	  ,[TR_MID] AS [IMMEDIATE SUPERVISOR]
      ,[TR_PIC] AS [PIC]
	  ,[USER_OUTPUT] AS [OUTPUT]
	  ,[QUOTA] AS [QUOTA]
	  ,[TR_UOM] AS [UOM]
      ,ROUND([X1],2) AS [X1]
      ,ROUND([Y],2) AS [Y]
      ,ROUND([X3],2) AS [X3]
      --,[LOGIN]
      --,[LOGOUT]
      --,ROUND([ACTUAL_WORKED_HOURS],2) AS [ACTUAL WORKED HOURS]
      --,[ACTUAL_OUTPUT] AS [ACTUAL OUTPUT]      
  FROM [CITITO].[dbo].[tbl_Report_TemptaskDetailsQUOTA_Updated]
  WHERE WORKDATE BETWEEN @mFrom AND @mTo  AND TR_PIC=@mPIC AND Task_ID=@mTaskCode


--SELECT [WORKDATE]
--      ,[TR_ID] AS [RECORD ID]
--      ,[TR_UID] AS [UID]
--      ,[TR_ActualTaskIn] AS [TASKED-IN]
--      ,[TR_OutDate] AS [TASKED-OUT]
--      ,ROUND([WORKED_HOURS],2) AS [TOTAL TITO HOURS]
--      ,[LOGIN]
--      ,[LOGOUT]
--      ,ROUND([ACTUAL_WORKED_HOURS],2) AS [ACTUAL WORKED HOURS]
--      ,[TR_Status] AS [TASK STATUS]
--      ,[TR_Apporval] AS [APPROVAL STATUS]
--      ,[TR_MID] AS [IMMEDIATE SUPERVISOR]
--      ,[TR_PIC] AS [PIC]
--      ,[TR_Shipment] AS [SHIPMENT/BATCH]
--      ,[TR_File] AS [FILE NAME]
--      ,[USER_OUTPUT] AS [OUTPUT]
--      ,[ACTUAL_OUTPUT] AS [ACTUAL OUTPUT]
--      ,[QUOTA] AS [QUOTA]
--      ,[TR_UOM] AS [UOM]
--      ,[PCP_ID] AS [JOB CODE]
--      ,[Task_ID] [TASK CODE]
--      ,[PC_ProcessCode] AS [ITEM CODE]
--      ,[PCP_Project] AS [PROJECT]
--      ,ROUND([X1],2) AS [X1]
--      ,ROUND([Y],2) AS [Y]
--      ,ROUND([X3],2) AS [X3]
--  FROM [CITITO].[dbo].[tbl_Report_TemptaskDetailsQUOTA_Updated]
--  WHERE WORKDATE BETWEEN @mFrom AND @mTo  AND TR_PIC=@mPIC AND Task_ID=@mTaskCode

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byUser_AllDataSetFilteredByTaskCodeAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byUser_AllDataSetFilteredByTaskCodeAndManager] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mTaskCode nvarchar(50), @mMUID nvarchar(20)

AS
/****** Script for SelectTopNRows command from SSMS  ******/

SELECT --[WORKDATE],
      [TR_ID] AS [RECORD ID]
      ,[TR_UID] AS [UID]
	  ,[PCP_Project] AS [PROJECT]
	  ,[TR_Shipment] AS [SHIPMENT/BATCH]
	  ,[TR_File] AS [FILE NAME]
	  ,[PCP_ID] AS [JOB CODE]
	  ,[PC_ProcessCode] AS [ITEM CODE]
	  ,[Task_ID] AS [TASK CODE]
	  ,[TR_InDate] AS [STARTED DATE TIME]
	  ,[TR_OutDate] AS [FINISHED DATE TIME]
	  ,ROUND([WORKED_HOURS],2) AS [TOTAL TITO TIME]
      --,[TR_ActualTaskIn] AS [TASKED-IN]
	  ,[TR_Status] AS [TASK STATUS]
      ,[TR_Apporval] AS [APPROVAL STATUS]
	  ,[TR_MID] AS [IMMEDIATE SUPERVISOR]
      ,[TR_PIC] AS [PIC]
	  ,[USER_OUTPUT] AS [OUTPUT]
	  ,[QUOTA] AS [QUOTA]
	  ,[TR_UOM] AS [UOM]
      ,ROUND([X1],2) AS [X1]
      ,ROUND([Y],2) AS [Y]
      ,ROUND([X3],2) AS [X3]
      --,[LOGIN]
      --,[LOGOUT]
      --,ROUND([ACTUAL_WORKED_HOURS],2) AS [ACTUAL WORKED HOURS]
      --,[ACTUAL_OUTPUT] AS [ACTUAL OUTPUT]      
  FROM [CITITO].[dbo].[tbl_Report_TemptaskDetailsQUOTA_Updated]
  WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND TR_MID=@mMUID AND Task_ID=@mTaskCode

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byUser_AllDataSetFilteredByUser]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byUser_AllDataSetFilteredByUser] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mUser nvarchar(50)

AS
/****** Script for SelectTopNRows command from SSMS  ******/


SELECT --[WORKDATE],
      [TR_ID] AS [RECORD ID]
      ,[TR_UID] AS [UID]
	  ,[PCP_Project] AS [PROJECT]
	  ,[TR_Shipment] AS [SHIPMENT/BATCH]
	  ,[TR_File] AS [FILE NAME]
	  ,[PCP_ID] AS [JOB CODE]
	  ,[PC_ProcessCode] AS [ITEM CODE]
	  ,[Task_ID] AS [TASK CODE]
	  ,[TR_InDate] AS [STARTED DATE TIME]
	  ,[TR_OutDate] AS [FINISHED DATE TIME]
	  ,ROUND([WORKED_HOURS],2) AS [TOTAL TITO TIME]
      --,[TR_ActualTaskIn] AS [TASKED-IN]
	  ,[TR_Status] AS [TASK STATUS]
      ,[TR_Apporval] AS [APPROVAL STATUS]
	  ,[TR_MID] AS [IMMEDIATE SUPERVISOR]
      ,[TR_PIC] AS [PIC]
	  ,[USER_OUTPUT] AS [OUTPUT]
	  ,[QUOTA] AS [QUOTA]
	  ,[TR_UOM] AS [UOM]
      ,ROUND([X1],2) AS [X1]
      ,ROUND([Y],2) AS [Y]
      ,ROUND([X3],2) AS [X3]
      --,[LOGIN]
      --,[LOGOUT]
      --,ROUND([ACTUAL_WORKED_HOURS],2) AS [ACTUAL WORKED HOURS]
      --,[ACTUAL_OUTPUT] AS [ACTUAL OUTPUT]      
  FROM [CITITO].[dbo].[tbl_Report_TemptaskDetailsQUOTA_Updated]
  WHERE WORKDATE BETWEEN @mFrom AND @mTo  AND TR_PIC=@mPIC AND TR_UID=@mUser


--SELECT [WORKDATE]
--      ,[TR_ID] AS [RECORD ID]
--      ,[TR_UID] AS [UID]
--      ,[TR_ActualTaskIn] AS [TASKED-IN]
--      ,[TR_OutDate] AS [TASKED-OUT]
--      ,ROUND([WORKED_HOURS],2) AS [TOTAL TITO HOURS]
--      ,[LOGIN]
--      ,[LOGOUT]
--      ,ROUND([ACTUAL_WORKED_HOURS],2) AS [ACTUAL WORKED HOURS]
--      ,[TR_Status] AS [TASK STATUS]
--      ,[TR_Apporval] AS [APPROVAL STATUS]
--      ,[TR_MID] AS [IMMEDIATE SUPERVISOR]
--      ,[TR_PIC] AS [PIC]
--      ,[TR_Shipment] AS [SHIPMENT/BATCH]
--      ,[TR_File] AS [FILE NAME]
--      ,[USER_OUTPUT] AS [OUTPUT]
--      ,[ACTUAL_OUTPUT] AS [ACTUAL OUTPUT]
--      ,[QUOTA] AS [QUOTA]
--      ,[TR_UOM] AS [UOM]
--      ,[PCP_ID] AS [JOB CODE]
--      ,[Task_ID] [TASK CODE]
--      ,[PC_ProcessCode] AS [ITEM CODE]
--      ,[PCP_Project] AS [PROJECT]
--      ,ROUND([X1],2) AS [X1]
--      ,ROUND([Y],2) AS [Y]
--      ,ROUND([X3],2) AS [X3]
--  FROM [CITITO].[dbo].[tbl_Report_TemptaskDetailsQUOTA_Updated]
--  WHERE WORKDATE BETWEEN @mFrom AND @mTo  AND TR_PIC=@mPIC AND TR_UID=@mUser

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byUser_AllDataSetFilteredByUser_User]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byUser_AllDataSetFilteredByUser_User] @mUID nvarchar(20), @mFrom DateTime, @mTo DateTime

AS
/****** Script for SelectTopNRows command from SSMS  ******/


SELECT --[WORKDATE],
      [TR_ID] AS [RECORD ID]
      ,[TR_UID] AS [UID]
	  ,[PCP_Project] AS [PROJECT]
	  ,[TR_Shipment] AS [SHIPMENT/BATCH]
	  ,[TR_File] AS [FILE NAME]
	  ,[PCP_ID] AS [JOB CODE]
	  ,[PC_ProcessCode] AS [ITEM CODE]
	  ,[Task_ID] AS [TASK CODE]
	  ,[TR_InDate] AS [STARTED DATE TIME]
	  ,[TR_OutDate] AS [FINISHED DATE TIME]
	  ,ROUND([WORKED_HOURS],2) AS [TOTAL TITO TIME]
      --,[TR_ActualTaskIn] AS [TASKED-IN]
	  ,[TR_Status] AS [TASK STATUS]
      ,[TR_Apporval] AS [APPROVAL STATUS]
	  ,[TR_MID] AS [IMMEDIATE SUPERVISOR]
      ,[TR_PIC] AS [PIC]
	  ,[USER_OUTPUT] AS [OUTPUT]
	  ,[QUOTA] AS [QUOTA]
	  ,[TR_UOM] AS [UOM]
      ,ROUND([X1],2) AS [X1]
      ,ROUND([Y],2) AS [Y]
      ,ROUND([X3],2) AS [X3]
      --,[LOGIN]
      --,[LOGOUT]
      --,ROUND([ACTUAL_WORKED_HOURS],2) AS [ACTUAL WORKED HOURS]
      --,[ACTUAL_OUTPUT] AS [ACTUAL OUTPUT]      
  FROM [CITITO].[dbo].[tbl_Report_TemptaskDetailsQUOTA_Updated]
  WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_UID=@mUID
GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byUser_AllDataSetFilteredByUserAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byUser_AllDataSetFilteredByUserAndManager] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mUser nvarchar(50), @mMUID nvarchar(20)

AS
/****** Script for SelectTopNRows command from SSMS  ******/


SELECT --[WORKDATE],
      [TR_ID] AS [RECORD ID]
      ,[TR_UID] AS [UID]
	  ,[PCP_Project] AS [PROJECT]
	  ,[TR_Shipment] AS [SHIPMENT/BATCH]
	  ,[TR_File] AS [FILE NAME]
	  ,[PCP_ID] AS [JOB CODE]
	  ,[PC_ProcessCode] AS [ITEM CODE]
	  ,[Task_ID] AS [TASK CODE]
	  ,[TR_InDate] AS [STARTED DATE TIME]
	  ,[TR_OutDate] AS [FINISHED DATE TIME]
	  ,ROUND([WORKED_HOURS],2) AS [TOTAL TITO TIME]
      --,[TR_ActualTaskIn] AS [TASKED-IN]
	  ,[TR_Status] AS [TASK STATUS]
      ,[TR_Apporval] AS [APPROVAL STATUS]
	  ,[TR_MID] AS [IMMEDIATE SUPERVISOR]
      ,[TR_PIC] AS [PIC]
	  ,[USER_OUTPUT] AS [OUTPUT]
	  ,[QUOTA] AS [QUOTA]
	  ,[TR_UOM] AS [UOM]
      ,ROUND([X1],2) AS [X1]
      ,ROUND([Y],2) AS [Y]
      ,ROUND([X3],2) AS [X3]
      --,[LOGIN]
      --,[LOGOUT]
      --,ROUND([ACTUAL_WORKED_HOURS],2) AS [ACTUAL WORKED HOURS]
      --,[ACTUAL_OUTPUT] AS [ACTUAL OUTPUT]      
  FROM [CITITO].[dbo].[tbl_Report_TemptaskDetailsQUOTA_Updated]
  WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND TR_MID=@mMUID AND TR_UID=@mUser

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byUser_Ranked]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byUser_Ranked] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime

AS

/* MONTHLY X3 USER */
SELECT [TR_UID] AS [UID]
	--,SUM([USER_OUTPUT]) AS [USER OUTPUT]
    --,SUM([ACTUAL_OUTPUT]) AS [OUTPUT]
	--,ROUND(SUM([WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([ACTUAL_WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([APPROVED_IDLE]),2) AS [APPROVED IDLE]
      ,ROUND(SUM([SUM_OF_X1]),2) AS [X1]
      ,ROUND(SUM([Y]),2) AS [Y]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
	  ,RANK() OVER (ORDER BY ((SUM([SUM_OF_X1])/SUM([Y])) * 100) DESC) AS [RANK]
FROM tbl_Report_TempDailyX3Users
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC
GROUP BY TR_UID
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC



--/* Wokred Shift for 9 hours */
--DECLARE @K int;

--SET @K= 32400;

--WITH tblDifference AS
--(
--	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ISNULL(CAST(d.TR_FileSize AS float),0) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ISNULL(CAST(d.TR_Quota AS float),0) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
--    FROM tbl_TaskRecordDetail d
--	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
--	WHERE d.TR_InDate BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC
--	ORDER BY d.TR_UID
--),
--taskDetails AS(
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST((cur.TR_InDate - previous.TR_OutDate) AS float),0) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + ISNULL(CAST((cur.TR_OutDate - cur.TR_InDate) AS float),0)) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
--	FROM tblDifference cur
--	LEFT OUTER JOIN tblDifference previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--),
--idleDetails AS (
--	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
--	FROM tbl_IDLEDetail i
--	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
--	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC
--),
--approveDoneRecords AS(
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.[WORKED_HOURS], cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project
--	FROM tblDifference cur
--	LEFT OUTER JOIN tblDifference previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--),
--sumOfTapproveDoneRecords AS(
--	SELECT TOP (999999999999999999) CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, SUM(cur.WORKED_HOURS) AS [WORKED_HOURS]
--	FROM tblDifference cur
--	LEFT OUTER JOIN tblDifference previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID
--	ORDER BY CONVERT(date, cur.TR_OutDate), cur.TR_UID
--),
--sumOfTaskGap_WasteOurs AS(
--	SELECT CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, ISNULL(SUM(CAST(cur.TR_InDate - previous.TR_OutDate AS float)), 0) AS [WASTE_HOURS]
--	FROM tblDifference cur
--	LEFT OUTER JOIN tblDifference previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID
--),
--sumOfidleDetails AS (
--	SELECT TOP (999999999999999999) [WORKDATE], IDLE_UID, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
--	FROM idleDetails 
--	GROUP BY [WORKDATE], IDLE_UID
--	ORDER BY [WORKDATE], IDLE_UID
--),

--X1 AS (
--	SELECT TOP (999999999999999999) WORKDATE, TR_UID, SUM(ACTUAL_OUTPUT) AS [OUTPUT], SUM(X1) AS [X1]
--	FROM taskDetails
--	GROUP BY WORKDATE, TR_UID
--	ORDER BY WORKDATE, TR_UID
--),

--Y AS (
--	SELECT TOP (999999999999999999) WK.WORKDATE, WK.TR_UID,(ISNULL(WK.WORKED_HOURS,0)) AS [WORK_HOURS],(ISNULL(WK.WORKED_HOURS,0) + ISNULL(WHGAP.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
--	FROM sumOfTapproveDoneRecords WK
--	LEFT JOIN sumOfidleDetails IDLE ON WK.TR_UID =IDLE.IDLE_UID AND WK.WORKDATE = IDLE.WORKDATE
--	LEFT JOIN sumOfTaskGap_WasteOurs WHGAP ON  WK.TR_UID = WHGAP.TR_UID AND WK.WORKDATE = WHGAP.WORKDATE
--),
--X3 AS (
--	SELECT TOP (999999999999999999) X.TR_UID, X.WORKDATE, [OUTPUT], X1, [WORK_HOURS], (X.X1/CASE SIGN(ISNULL(Y1.Y,1)) WHEN -1 THEN 1 ELSE (ISNULL(Y1.Y,1)) END)*100 AS [X3]
--	FROM Y Y1
--	LEFT JOIN X1 X ON X.TR_UID =Y1.TR_UID AND X.WORKDATE = Y1.WORKDATE
--)

--/*Weekly X3 for cluster*/
--SELECT TR_UID AS [UID], SUM([OUTPUT]) AS [OUTPUT], ROUND(SUM(X1),2) AS [SUM X1], ROUND(SUM([WORK_HOURS]),2) AS [WORK HOURS], ROUND(SUM(X3),2) AS [X3], RANK() OVER (ORDER BY SUM(X3) DESC) AS [RANK]
--FROM X3
--GROUP BY TR_UID
--ORDER BY X3 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byUser_Ranked_Chart]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byUser_Ranked_Chart] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime

AS


/* MONTHLY X3 USER */
SELECT [TR_UID] AS [UID]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
FROM tbl_Report_TempDailyX3Users
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC
GROUP BY TR_UID
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

--/* Wokred Shift for 9 hours */
--DECLARE @K int;

--SET @K= 32400;

--DECLARE @TemptblDifference_@mPIC TABLE(
--RowNumber bigint,
--TR_Index bigint,
--WORKDATE Date,
--TR_ID nvarchar(100),
--TR_UID nvarchar(50), 
--TR_InDate DateTime,
--TR_OutDate DateTime,
--TR_Status int,
--TR_Apporval int,
--TR_MID nvarchar(50),
--TR_PIC nvarchar(50),
--TR_Shipment nvarchar(100),
--TR_File nvarchar(100),
--ACTUAL_OUTPUT float,
--WORKED_HOURS float,
--QUOTA float, 
--TR_UOM nvarchar(50), 
--PCP_ID nvarchar(50),
--Task_ID nvarchar(50),
--PC_ProcessCode nvarchar(50), 
--PCP_Project nvarchar(50)
--); 

--DECLARE @TemptaskDetails_@mPIC TABLE(
--RowNumber bigint,
--TR_Index bigint,
--WORKDATE Date,
--TR_ID nvarchar(100),
--TR_UID nvarchar(50), 
--TR_InDate DateTime,
--TR_OutDate DateTime,
--WORKED_HOURS float, 
--WASTE_HOURS float,
--X1 float,
--HRS_WASTE float,
--TR_Status int,
--TR_Apporval int,
--TR_MID nvarchar(50),
--TR_PIC nvarchar(50),
--TR_Shipment nvarchar(100),
--TR_File nvarchar(100),
--ACTUAL_OUTPUT float,
--QUOTA float, 
--TR_UOM nvarchar(50), 
--PCP_ID nvarchar(50),
--Task_ID nvarchar(50),
--PC_ProcessCode nvarchar(50), 
--PCP_Project nvarchar(50)
--); 

--DECLARE @TempidleDetails_@mPIC TABLE(
--IDLE_Index bigint,
--WORKDATE Date,
--IDLE_ID nvarchar(100),
--IDLE_UID nvarchar(50), 
--IDLE_InDate DateTime,
--IDLE_OutDate DateTime,
--IDLE_TIME float, 
--IDLE_Reason nvarchar(200),
--IDLE_MID nvarchar(50), 
--IDLE_PIC nvarchar(50), 
--IDLE_Project nvarchar(50)
--);

--INSERT INTO @TemptblDifference_@mPIC 
--	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ISNULL(CAST(d.TR_FileSize AS float),0) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ISNULL(CAST(d.TR_Quota AS float),0) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
--    FROM tbl_TaskRecordDetail d
--	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
--	WHERE d.TR_InDate BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC
--	ORDER BY d.TR_UID

--INSERT INTO @TemptaskDetails_@mPIC 
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST((cur.TR_InDate - previous.TR_OutDate) AS float),0) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + ISNULL(CAST((cur.TR_OutDate - cur.TR_InDate) AS float),0)) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)

--INSERT INTO @TempidleDetails_@mPIC 
--	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
--	FROM tbl_IDLEDetail i
--	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
--	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC
--;
--WITH approveDoneRecords AS(
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.[WORKED_HOURS], cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--),
--sumOfTapproveDoneRecords AS(
--	SELECT TOP (999999999999999999) CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, SUM(cur.WORKED_HOURS) AS [WORKED_HOURS]
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID
--	ORDER BY CONVERT(date, cur.TR_OutDate), cur.TR_UID
--),
--sumOfTaskGap_WasteOurs AS(
--	SELECT CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, ISNULL(SUM(CAST(cur.TR_InDate - previous.TR_OutDate AS float)), 0) AS [WASTE_HOURS]
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID
--),
--sumOfidleDetails AS (
--	SELECT TOP (999999999999999999) [WORKDATE], IDLE_UID, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
--	FROM @TempidleDetails_@mPIC 
--	GROUP BY [WORKDATE], IDLE_UID
--	ORDER BY [WORKDATE], IDLE_UID
--),

--X1 AS (
--	SELECT TOP (999999999999999999) WORKDATE, TR_UID, SUM(ACTUAL_OUTPUT) AS [OUTPUT], SUM(X1) AS [X1]
--	FROM @TemptaskDetails_@mPIC
--	GROUP BY WORKDATE, TR_UID
--	ORDER BY WORKDATE, TR_UID
--),

--Y AS (
--	SELECT TOP (999999999999999999) WK.WORKDATE, WK.TR_UID,(ISNULL(WK.WORKED_HOURS,0)) AS [WORK_HOURS],(ISNULL(WK.WORKED_HOURS,0) + ISNULL(WHGAP.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
--	FROM sumOfTapproveDoneRecords WK
--	LEFT JOIN sumOfidleDetails IDLE ON WK.TR_UID =IDLE.IDLE_UID AND WK.WORKDATE = IDLE.WORKDATE
--	LEFT JOIN sumOfTaskGap_WasteOurs WHGAP ON  WK.TR_UID = WHGAP.TR_UID AND WK.WORKDATE = WHGAP.WORKDATE
--),
--X3 AS (
--	SELECT TOP (999999999999999999) X.TR_UID, X.WORKDATE, [OUTPUT], X1, [WORK_HOURS], (X.X1/CASE SIGN(ISNULL(Y1.Y,1)) WHEN -1 THEN 1 ELSE (ISNULL(Y1.Y,1)) END )*100 AS [X3]
--	FROM Y Y1
--	LEFT JOIN X1 X ON X.TR_UID =Y1.TR_UID AND X.WORKDATE = Y1.WORKDATE
--)

--SELECT TR_UID AS [UID],  ROUND(SUM(X3),3) AS [X3] 
--FROM X3 WITH (NOLOCK)
--GROUP BY TR_UID
--ORDER BY X3 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byUser_Ranked_ChartByProject]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[DBoard_X3byUser_Ranked_ChartByProject] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mProject nvarchar(20)

AS

/* MONTHLY X3 USER */
SELECT [TR_UID] AS [UID]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
FROM tbl_Report_TempDailyX3Project
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND PCP_Project=@mProject
GROUP BY TR_UID
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

--/* Wokred Shift for 9 hours */
--DECLARE @K int;

--SET @K= 32400;

--DECLARE @TemptblDifference_@mPIC TABLE(
--RowNumber bigint,
--TR_Index bigint,
--WORKDATE Date,
--TR_ID nvarchar(100),
--TR_UID nvarchar(50), 
--TR_InDate DateTime,
--TR_OutDate DateTime,
--TR_Status int,
--TR_Apporval int,
--TR_MID nvarchar(50),
--TR_PIC nvarchar(50),
--TR_Shipment nvarchar(100),
--TR_File nvarchar(100),
--ACTUAL_OUTPUT float,
--WORKED_HOURS float,
--QUOTA float, 
--TR_UOM nvarchar(50), 
--PCP_ID nvarchar(50),
--Task_ID nvarchar(50),
--PC_ProcessCode nvarchar(50), 
--PCP_Project nvarchar(50)
--); 

--DECLARE @TemptaskDetails_@mPIC TABLE(
--RowNumber bigint,
--TR_Index bigint,
--WORKDATE Date,
--TR_ID nvarchar(100),
--TR_UID nvarchar(50), 
--TR_InDate DateTime,
--TR_OutDate DateTime,
--WORKED_HOURS float, 
--WASTE_HOURS float,
--X1 float,
--HRS_WASTE float,
--TR_Status int,
--TR_Apporval int,
--TR_MID nvarchar(50),
--TR_PIC nvarchar(50),
--TR_Shipment nvarchar(100),
--TR_File nvarchar(100),
--ACTUAL_OUTPUT float,
--QUOTA float, 
--TR_UOM nvarchar(50), 
--PCP_ID nvarchar(50),
--Task_ID nvarchar(50),
--PC_ProcessCode nvarchar(50), 
--PCP_Project nvarchar(50)
--); 

--DECLARE @TempidleDetails_@mPIC TABLE(
--IDLE_Index bigint,
--WORKDATE Date,
--IDLE_ID nvarchar(100),
--IDLE_UID nvarchar(50), 
--IDLE_InDate DateTime,
--IDLE_OutDate DateTime,
--IDLE_TIME float, 
--IDLE_Reason nvarchar(200),
--IDLE_MID nvarchar(50), 
--IDLE_PIC nvarchar(50), 
--IDLE_Project nvarchar(50)
--);

--INSERT INTO @TemptblDifference_@mPIC 
--	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ISNULL(CAST(d.TR_FileSize AS float),0) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ISNULL(CAST(d.TR_Quota AS float),0) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
--    FROM tbl_TaskRecordDetail d
--	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
--	WHERE d.TR_InDate BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC
--	ORDER BY d.TR_UID

--INSERT INTO @TemptaskDetails_@mPIC 
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST((cur.TR_InDate - previous.TR_OutDate) AS float),0) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + ISNULL(CAST((cur.TR_OutDate - cur.TR_InDate) AS float),0)) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)

--INSERT INTO @TempidleDetails_@mPIC 
--	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
--	FROM tbl_IDLEDetail i
--	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
--	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC
--;
--WITH approveDoneRecords AS(
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.[WORKED_HOURS], cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--),
--sumOfTapproveDoneRecords AS(
--	SELECT TOP (999999999999999999) CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.PCP_Project, SUM(cur.WORKED_HOURS) AS [WORKED_HOURS]
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.PCP_Project
--	ORDER BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.PCP_Project
--),
--sumOfTaskGap_WasteOurs AS(
--	SELECT CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.PCP_Project, ISNULL(SUM(CAST(cur.TR_InDate - previous.TR_OutDate AS float)), 0) AS [WASTE_HOURS]
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.PCP_Project
--),
--sumOfidleDetails AS (
--	SELECT TOP (999999999999999999) [WORKDATE], IDLE_UID, IDLE_Project, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
--	FROM @TempidleDetails_@mPIC 
--	GROUP BY [WORKDATE], IDLE_UID, IDLE_Project
--	ORDER BY [WORKDATE], IDLE_UID, IDLE_Project
--),

--X1 AS (
--	SELECT TOP (999999999999999999) WORKDATE, TR_UID, PCP_Project, SUM(ACTUAL_OUTPUT) AS [OUTPUT], SUM(X1) AS [X1]
--	FROM @TemptaskDetails_@mPIC
--	GROUP BY WORKDATE, TR_UID, PCP_Project
--	ORDER BY WORKDATE, TR_UID, PCP_Project
--),

--Y AS (
--	SELECT TOP (999999999999999999) WK.WORKDATE, WK.TR_UID, WK.PCP_Project,(ISNULL(WK.WORKED_HOURS,0)) AS [WORK_HOURS],(ISNULL(WK.WORKED_HOURS,0) + ISNULL(WHGAP.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
--	FROM sumOfTapproveDoneRecords WK
--	LEFT JOIN sumOfidleDetails IDLE ON WK.TR_UID =IDLE.IDLE_UID AND WK.WORKDATE = IDLE.WORKDATE AND WK.PCP_Project=IDLE.IDLE_Project
--	LEFT JOIN sumOfTaskGap_WasteOurs WHGAP ON  WK.TR_UID = WHGAP.TR_UID AND WK.WORKDATE = WHGAP.WORKDATE AND WHGAP.PCP_Project=WK.PCP_Project
--),
--X3 AS (
--	SELECT TOP (999999999999999999) X.TR_UID, X.PCP_Project, X.WORKDATE, [OUTPUT], X1, [WORK_HOURS], (X.X1/CASE SIGN(ISNULL(Y1.Y,1)) WHEN -1 THEN 1 ELSE (ISNULL(Y1.Y,1)) END)*100 AS [X3]
--	FROM Y Y1
--	LEFT JOIN X1 X ON X.TR_UID =Y1.TR_UID AND X.WORKDATE = Y1.WORKDATE AND X.PCP_Project= Y1.PCP_Project
--)

--SELECT TR_UID AS [UID],  ROUND(SUM(X3),3) AS [X3] 
--FROM X3 WITH (NOLOCK)
--WHERE PCP_Project=@mProject
--GROUP BY TR_UID
--ORDER BY X3 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byUser_Ranked_ChartByProjectAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byUser_Ranked_ChartByProjectAndManager] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mProject nvarchar(20), @mMUID nvarchar(20)

AS

/* MONTHLY X3 USER */
SELECT [TR_UID] AS [UID]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
FROM tbl_Report_TempDailyX3Project
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND PCP_Project=@mProject AND TR_MID=@mMUID
GROUP BY TR_UID
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byUser_Ranked_ChartByUID]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byUser_Ranked_ChartByUID] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mUID nvarchar(20)
WITH RECOMPILE
AS

/* MONTHLY X3 USER */
SELECT [TR_UID] AS [UID]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
FROM tbl_Report_TempDailyX3Users
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND TR_UID=@mUID
GROUP BY TR_UID
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

--/* Wokred Shift for 9 hours */
--DECLARE @K int;

--SET @K= 32400;

--DECLARE @TemptblDifference_@mPIC TABLE(
--RowNumber bigint,
--TR_Index bigint,
--WORKDATE Date,
--TR_ID nvarchar(100),
--TR_UID nvarchar(50), 
--TR_InDate DateTime,
--TR_OutDate DateTime,
--TR_Status int,
--TR_Apporval int,
--TR_MID nvarchar(50),
--TR_PIC nvarchar(50),
--TR_Shipment nvarchar(100),
--TR_File nvarchar(100),
--ACTUAL_OUTPUT float,
--WORKED_HOURS float,
--QUOTA float, 
--TR_UOM nvarchar(50), 
--PCP_ID nvarchar(50),
--Task_ID nvarchar(50),
--PC_ProcessCode nvarchar(50), 
--PCP_Project nvarchar(50)
--); 

--DECLARE @TemptaskDetails_@mPIC TABLE(
--RowNumber bigint,
--TR_Index bigint,
--WORKDATE Date,
--TR_ID nvarchar(100),
--TR_UID nvarchar(50), 
--TR_InDate DateTime,
--TR_OutDate DateTime,
--WORKED_HOURS float, 
--WASTE_HOURS float,
--X1 float,
--HRS_WASTE float,
--TR_Status int,
--TR_Apporval int,
--TR_MID nvarchar(50),
--TR_PIC nvarchar(50),
--TR_Shipment nvarchar(100),
--TR_File nvarchar(100),
--ACTUAL_OUTPUT float,
--QUOTA float, 
--TR_UOM nvarchar(50), 
--PCP_ID nvarchar(50),
--Task_ID nvarchar(50),
--PC_ProcessCode nvarchar(50), 
--PCP_Project nvarchar(50)
--); 

--DECLARE @TempidleDetails_@mPIC TABLE(
--IDLE_Index bigint,
--WORKDATE Date,
--IDLE_ID nvarchar(100),
--IDLE_UID nvarchar(50), 
--IDLE_InDate DateTime,
--IDLE_OutDate DateTime,
--IDLE_TIME float, 
--IDLE_Reason nvarchar(200),
--IDLE_MID nvarchar(50), 
--IDLE_PIC nvarchar(50), 
--IDLE_Project nvarchar(50)
--);

--INSERT INTO @TemptblDifference_@mPIC 
--	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ISNULL(CAST(d.TR_FileSize AS float),0) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ISNULL(CAST(d.TR_Quota AS float),0) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
--    FROM tbl_TaskRecordDetail d
--	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
--	WHERE d.TR_InDate BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC
--	ORDER BY d.TR_UID

--INSERT INTO @TemptaskDetails_@mPIC 
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST((cur.TR_InDate - previous.TR_OutDate) AS float),0) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + ISNULL(CAST((cur.TR_OutDate - cur.TR_InDate) AS float),0)) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)

--INSERT INTO @TempidleDetails_@mPIC 
--	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
--	FROM tbl_IDLEDetail i
--	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
--	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC
--;
--WITH approveDoneRecords AS(
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.[WORKED_HOURS], cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--),
--sumOfTapproveDoneRecords AS(
--	SELECT TOP (999999999999999999) CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, SUM(cur.WORKED_HOURS) AS [WORKED_HOURS]
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID
--	ORDER BY CONVERT(date, cur.TR_OutDate), cur.TR_UID
--),
--sumOfTaskGap_WasteOurs AS(
--	SELECT CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, ISNULL(SUM(CAST(cur.TR_InDate - previous.TR_OutDate AS float)), 0) AS [WASTE_HOURS]
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID
--),
--sumOfidleDetails AS (
--	SELECT TOP (999999999999999999) [WORKDATE], IDLE_UID, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
--	FROM @TempidleDetails_@mPIC 
--	GROUP BY [WORKDATE], IDLE_UID
--	ORDER BY [WORKDATE], IDLE_UID
--),

--X1 AS (
--	SELECT TOP (999999999999999999) WORKDATE, TR_UID, SUM(ACTUAL_OUTPUT) AS [OUTPUT], SUM(X1) AS [X1]
--	FROM @TemptaskDetails_@mPIC
--	GROUP BY WORKDATE, TR_UID
--	ORDER BY WORKDATE, TR_UID
--),

--Y AS (
--	SELECT TOP (999999999999999999) WK.WORKDATE, WK.TR_UID,(ISNULL(WK.WORKED_HOURS,0)) AS [WORK_HOURS],(ISNULL(WK.WORKED_HOURS,0) + ISNULL(WHGAP.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
--	FROM sumOfTapproveDoneRecords WK
--	LEFT JOIN sumOfidleDetails IDLE ON WK.TR_UID =IDLE.IDLE_UID AND WK.WORKDATE = IDLE.WORKDATE
--	LEFT JOIN sumOfTaskGap_WasteOurs WHGAP ON  WK.TR_UID = WHGAP.TR_UID AND WK.WORKDATE = WHGAP.WORKDATE
--),
--X3 AS (
--	SELECT TOP (999999999999999999) X.TR_UID, X.WORKDATE, [OUTPUT], X1, [WORK_HOURS], (X.X1/CASE SIGN(ISNULL(Y1.Y,1)) WHEN -1 THEN 1 ELSE (ISNULL(Y1.Y,1)) END)*100 AS [X3]
--	FROM Y Y1
--	LEFT JOIN X1 X ON X.TR_UID =Y1.TR_UID AND X.WORKDATE = Y1.WORKDATE
--)

--SELECT TR_UID AS [UID],  ROUND(SUM(X3),3) AS [X3] 
--FROM X3 WITH (NOLOCK)
--WHERE TR_UID=@mUID
--GROUP BY TR_UID
--ORDER BY X3 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byUser_Ranked_ChartByUIDAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[DBoard_X3byUser_Ranked_ChartByUIDAndManager] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mMID nvarchar(20)

AS


/* MONTHLY X3 USER */
SELECT [TR_UID] AS [UID]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
FROM tbl_Report_TempDailyX3Users
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND TR_MID=@mMID
GROUP BY TR_UID
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

--/* Wokred Shift for 9 hours */
--DECLARE @K int;

--SET @K= 32400;

--DECLARE @TemptblDifference_@mPIC TABLE(
--RowNumber bigint,
--TR_Index bigint,
--WORKDATE Date,
--TR_ID nvarchar(100),
--TR_UID nvarchar(50), 
--TR_InDate DateTime,
--TR_OutDate DateTime,
--TR_Status int,
--TR_Apporval int,
--TR_MID nvarchar(50),
--TR_PIC nvarchar(50),
--TR_Shipment nvarchar(100),
--TR_File nvarchar(100),
--ACTUAL_OUTPUT float,
--WORKED_HOURS float,
--QUOTA float, 
--TR_UOM nvarchar(50), 
--PCP_ID nvarchar(50),
--Task_ID nvarchar(50),
--PC_ProcessCode nvarchar(50), 
--PCP_Project nvarchar(50)
--); 

--DECLARE @TemptaskDetails_@mPIC TABLE(
--RowNumber bigint,
--TR_Index bigint,
--WORKDATE Date,
--TR_ID nvarchar(100),
--TR_UID nvarchar(50), 
--TR_InDate DateTime,
--TR_OutDate DateTime,
--WORKED_HOURS float, 
--WASTE_HOURS float,
--X1 float,
--HRS_WASTE float,
--TR_Status int,
--TR_Apporval int,
--TR_MID nvarchar(50),
--TR_PIC nvarchar(50),
--TR_Shipment nvarchar(100),
--TR_File nvarchar(100),
--ACTUAL_OUTPUT float,
--QUOTA float, 
--TR_UOM nvarchar(50), 
--PCP_ID nvarchar(50),
--Task_ID nvarchar(50),
--PC_ProcessCode nvarchar(50), 
--PCP_Project nvarchar(50)
--); 

--DECLARE @TempidleDetails_@mPIC TABLE(
--IDLE_Index bigint,
--WORKDATE Date,
--IDLE_ID nvarchar(100),
--IDLE_UID nvarchar(50), 
--IDLE_InDate DateTime,
--IDLE_OutDate DateTime,
--IDLE_TIME float, 
--IDLE_Reason nvarchar(200),
--IDLE_MID nvarchar(50), 
--IDLE_PIC nvarchar(50), 
--IDLE_Project nvarchar(50)
--);

--INSERT INTO @TemptblDifference_@mPIC 
--	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ISNULL(CAST(d.TR_FileSize AS float),0) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ISNULL(CAST(d.TR_Quota AS float),0) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
--    FROM tbl_TaskRecordDetail d
--	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
--	WHERE d.TR_InDate BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC
--	ORDER BY d.TR_UID

--INSERT INTO @TemptaskDetails_@mPIC 
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST((cur.TR_InDate - previous.TR_OutDate) AS float),0) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + ISNULL(CAST((cur.TR_OutDate - cur.TR_InDate) AS float),0)) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)

--INSERT INTO @TempidleDetails_@mPIC 
--	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
--	FROM tbl_IDLEDetail i
--	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
--	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC
--;
--WITH approveDoneRecords AS(
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.[WORKED_HOURS], cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--),
--sumOfTapproveDoneRecords AS(
--	SELECT TOP (999999999999999999) CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID, SUM(cur.WORKED_HOURS) AS [WORKED_HOURS]
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID
--	ORDER BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID
--),
--sumOfTaskGap_WasteOurs AS(
--	SELECT CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID, ISNULL(SUM(CAST(cur.TR_InDate - previous.TR_OutDate AS float)), 0) AS [WASTE_HOURS]
--	FROM @TemptblDifference_@mPIC cur
--	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID
--),
--sumOfidleDetails AS (
--	SELECT TOP (999999999999999999) [WORKDATE], IDLE_UID, IDLE_MID, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
--	FROM @TempidleDetails_@mPIC 
--	GROUP BY [WORKDATE], IDLE_UID, IDLE_MID
--	ORDER BY [WORKDATE], IDLE_UID, IDLE_MID
--),

--X1 AS (
--	SELECT TOP (999999999999999999) WORKDATE, TR_UID, TR_MID, SUM(ACTUAL_OUTPUT) AS [OUTPUT], SUM(X1) AS [X1]
--	FROM @TemptaskDetails_@mPIC
--	GROUP BY WORKDATE, TR_UID, TR_MID
--	ORDER BY WORKDATE, TR_UID, TR_MID
--),

--Y AS (
--	SELECT TOP (999999999999999999) WK.WORKDATE, WK.TR_UID, WK.TR_MID,(ISNULL(WK.WORKED_HOURS,0)) AS [WORK_HOURS],(ISNULL(WK.WORKED_HOURS,0) + ISNULL(WHGAP.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
--	FROM sumOfTapproveDoneRecords WK
--	LEFT JOIN sumOfidleDetails IDLE ON WK.TR_UID =IDLE.IDLE_UID AND WK.WORKDATE = IDLE.WORKDATE AND WK.TR_MID=IDLE.IDLE_MID
--	LEFT JOIN sumOfTaskGap_WasteOurs WHGAP ON  WK.TR_UID = WHGAP.TR_UID AND WK.WORKDATE = WHGAP.WORKDATE AND WHGAP.TR_MID=WK.TR_MID
--),
--X3 AS (
--	SELECT TOP (999999999999999999) X.TR_UID, X.TR_MID, X.WORKDATE, [OUTPUT], X1, [WORK_HOURS], (X.X1/CASE SIGN(ISNULL(Y1.Y,1)) WHEN -1 THEN 1 ELSE (ISNULL(Y1.Y,1)) END)*100 AS [X3]
--	FROM Y Y1
--	LEFT JOIN X1 X ON X.TR_UID =Y1.TR_UID AND X.WORKDATE = Y1.WORKDATE AND X.TR_MID= Y1.TR_MID
--)

--SELECT TR_UID AS [UID],  ROUND(SUM(X3),3) AS [X3] 
--FROM X3 WITH (NOLOCK)
--WHERE TR_MID=@mMID
--GROUP BY TR_UID
--ORDER BY X3 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byUser_Ranked_ChartByUIDWithManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byUser_Ranked_ChartByUIDWithManager] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mUID nvarchar(20), @mMUID nvarchar(20)
WITH RECOMPILE
AS

/* MONTHLY X3 USER */
SELECT [TR_UID] AS [UID]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
FROM tbl_Report_TempDailyX3Users
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND TR_UID=@mUID AND TR_MID=@mMUID
GROUP BY TR_UID
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byUser_Ranked_FilterByManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byUser_Ranked_FilterByManager] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mMID nvarchar(20)

AS
/* Wokred Shift for 9 hours */
DECLARE @K int;

SET @K= 32400;

WITH tblDifference AS
(
	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ISNULL(CAST(d.TR_FileSize AS float),0) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ISNULL(CAST(d.TR_Quota AS float),0) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
    FROM tbl_TaskRecordDetail d
	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
	WHERE d.TR_InDate BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC AND d.TR_MID=@mMID
	ORDER BY d.TR_UID
),
taskDetails AS(
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST((cur.TR_InDate - previous.TR_OutDate) AS float),0) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + ISNULL(CAST((cur.TR_OutDate - cur.TR_InDate) AS float),0)) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
	FROM tblDifference cur
	LEFT OUTER JOIN tblDifference previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
),
idleDetails AS (
	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
	FROM tbl_IDLEDetail i
	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC AND h.IDLE_MID=@mMID
),
approveDoneRecords AS(
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.[WORKED_HOURS], cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project
	FROM tblDifference cur
	LEFT OUTER JOIN tblDifference previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
),
sumOfTapproveDoneRecords AS(
	SELECT TOP (999999999999999999) CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, SUM(cur.WORKED_HOURS) AS [WORKED_HOURS]
	FROM tblDifference cur
	LEFT OUTER JOIN tblDifference previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID
	ORDER BY CONVERT(date, cur.TR_OutDate), cur.TR_UID
),
sumOfTaskGap_WasteOurs AS(
	SELECT CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, ISNULL(SUM(CAST(cur.TR_InDate - previous.TR_OutDate AS float)), 0) AS [WASTE_HOURS]
	FROM tblDifference cur
	LEFT OUTER JOIN tblDifference previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID
),
sumOfidleDetails AS (
	SELECT TOP (999999999999999999) [WORKDATE], IDLE_UID, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
	FROM idleDetails 
	GROUP BY [WORKDATE], IDLE_UID
	ORDER BY [WORKDATE], IDLE_UID
),

X1 AS (
	SELECT TOP (999999999999999999) WORKDATE, TR_UID, SUM(ACTUAL_OUTPUT) AS [OUTPUT], SUM(X1) AS [X1]
	FROM taskDetails
	GROUP BY WORKDATE, TR_UID
	ORDER BY WORKDATE, TR_UID
),

Y AS (
	SELECT TOP (999999999999999999) WK.WORKDATE, WK.TR_UID,(ISNULL(WK.WORKED_HOURS,0)) AS [WORK_HOURS],(ISNULL(WK.WORKED_HOURS,0) + ISNULL(WHGAP.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
	FROM sumOfTapproveDoneRecords WK
	LEFT JOIN sumOfidleDetails IDLE ON WK.TR_UID =IDLE.IDLE_UID AND WK.WORKDATE = IDLE.WORKDATE
	LEFT JOIN sumOfTaskGap_WasteOurs WHGAP ON  WK.TR_UID = WHGAP.TR_UID AND WK.WORKDATE = WHGAP.WORKDATE
),
X3 AS (
	SELECT TOP (999999999999999999) X.TR_UID, X.WORKDATE, [OUTPUT], X1, [WORK_HOURS], (X.X1/CASE SIGN(ISNULL(Y1.Y,1)) WHEN -1 THEN 1 ELSE (ISNULL(Y1.Y,1)) END)*100 AS [X3]
	FROM Y Y1
	LEFT JOIN X1 X ON X.TR_UID =Y1.TR_UID AND X.WORKDATE = Y1.WORKDATE
)

/*Weekly X3 for cluster*/
SELECT TR_UID AS [UID], SUM([OUTPUT]) AS [OUTPUT], ROUND(SUM(X1),2) AS [SUM X1], ROUND(SUM([WORK_HOURS]),2) AS [WORK HOURS], ROUND(SUM(X3),2) AS [X3], RANK() OVER (ORDER BY SUM(X3) DESC) AS [RANK]
FROM X3
GROUP BY TR_UID
ORDER BY X3 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byUser_Ranked_FilterByProject]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byUser_Ranked_FilterByProject] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mProject nvarchar(30)

AS
/* Wokred Shift for 9 hours */
DECLARE @K int;

SET @K= 32400;

WITH tblDifference AS
(
	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ISNULL(CAST(d.TR_FileSize AS float),0) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ISNULL(CAST(d.TR_Quota AS float),0) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
    FROM tbl_TaskRecordDetail d
	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
	WHERE d.TR_InDate BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC AND p.PCP_Project=@mProject
	ORDER BY d.TR_UID
),
taskDetails AS(
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST((cur.TR_InDate - previous.TR_OutDate) AS float),0) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + ISNULL(CAST((cur.TR_OutDate - cur.TR_InDate) AS float),0)) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
	FROM tblDifference cur
	LEFT OUTER JOIN tblDifference previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
),
idleDetails AS (
	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
	FROM tbl_IDLEDetail i
	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC AND h.IDLE_Project=@mProject
),
approveDoneRecords AS(
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.[WORKED_HOURS], cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project
	FROM tblDifference cur
	LEFT OUTER JOIN tblDifference previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
),
sumOfTapproveDoneRecords AS(
	SELECT TOP (999999999999999999) CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, SUM(cur.WORKED_HOURS) AS [WORKED_HOURS]
	FROM tblDifference cur
	LEFT OUTER JOIN tblDifference previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID
	ORDER BY CONVERT(date, cur.TR_OutDate), cur.TR_UID
),
sumOfTaskGap_WasteOurs AS(
	SELECT CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, ISNULL(SUM(CAST(cur.TR_InDate - previous.TR_OutDate AS float)), 0) AS [WASTE_HOURS]
	FROM tblDifference cur
	LEFT OUTER JOIN tblDifference previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID
),
sumOfidleDetails AS (
	SELECT TOP (999999999999999999) [WORKDATE], IDLE_UID, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
	FROM idleDetails 
	GROUP BY [WORKDATE], IDLE_UID
	ORDER BY [WORKDATE], IDLE_UID
),

X1 AS (
	SELECT TOP (999999999999999999) WORKDATE, TR_UID, SUM(ACTUAL_OUTPUT) AS [OUTPUT], SUM(X1) AS [X1]
	FROM taskDetails
	GROUP BY WORKDATE, TR_UID
	ORDER BY WORKDATE, TR_UID
),

Y AS (
	SELECT TOP (999999999999999999) WK.WORKDATE, WK.TR_UID,(ISNULL(WK.WORKED_HOURS,0)) AS [WORK_HOURS],(ISNULL(WK.WORKED_HOURS,0) + ISNULL(WHGAP.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
	FROM sumOfTapproveDoneRecords WK
	LEFT JOIN sumOfidleDetails IDLE ON WK.TR_UID =IDLE.IDLE_UID AND WK.WORKDATE = IDLE.WORKDATE
	LEFT JOIN sumOfTaskGap_WasteOurs WHGAP ON  WK.TR_UID = WHGAP.TR_UID AND WK.WORKDATE = WHGAP.WORKDATE
),
X3 AS (
	SELECT TOP (999999999999999999) X.TR_UID, X.WORKDATE, [OUTPUT], X1, [WORK_HOURS], (X.X1/CASE SIGN(ISNULL(Y1.Y,1)) WHEN -1 THEN 1 ELSE (CASE SIGN(ISNULL(Y1.Y,1)) WHEN -1 THEN 1 ELSE (ISNULL(Y1.Y,1)) END) END )*100 AS [X3]
	FROM Y Y1
	LEFT JOIN X1 X ON X.TR_UID =Y1.TR_UID AND X.WORKDATE = Y1.WORKDATE
)

/*Weekly X3 for cluster*/
SELECT TR_UID AS [UID], SUM([OUTPUT]) AS [OUTPUT], ROUND(SUM(X1),2) AS [SUM X1], ROUND(SUM([WORK_HOURS]),2) AS [WORK HOURS], ROUND(SUM(X3),2) AS [X3], RANK() OVER (ORDER BY SUM(X3) DESC) AS [RANK]
FROM X3
GROUP BY TR_UID
ORDER BY X3 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byUser_Ranked_FilterByUser]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byUser_Ranked_FilterByUser] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mUID nvarchar(20)

AS

/* MONTHLY X3 USER */
SELECT [TR_UID] AS [UID]
	--,SUM([USER_OUTPUT]) AS [USER OUTPUT]
    --,SUM([ACTUAL_OUTPUT]) AS [OUTPUT]
	--,ROUND(SUM([WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([ACTUAL_WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([APPROVED_IDLE]),2) AS [APPROVED IDLE]
      ,ROUND(SUM([SUM_OF_X1]),2) AS [X1]
      ,ROUND(SUM([Y]),2) AS [Y]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
	  ,RANK() OVER (ORDER BY ((SUM([SUM_OF_X1])/SUM([Y])) * 100) DESC) AS [RANK]
FROM tbl_Report_TempDailyX3Users
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND TR_UID=@mUID
GROUP BY TR_UID
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

--/* Wokred Shift for 9 hours */
--DECLARE @K int;

--SET @K= 32400;

--WITH tblDifference AS
--(
--	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ISNULL(CAST(d.TR_FileSize AS float),0) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ISNULL(CAST(d.TR_Quota AS float),0) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
--    FROM tbl_TaskRecordDetail d
--	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
--	WHERE d.TR_InDate BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC AND d.TR_UID=@mUID
--	ORDER BY d.TR_UID
--),
--taskDetails AS(
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST((cur.TR_InDate - previous.TR_OutDate) AS float),0) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + ISNULL(CAST((cur.TR_OutDate - cur.TR_InDate) AS float),0)) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
--	FROM tblDifference cur
--	LEFT OUTER JOIN tblDifference previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--),
--idleDetails AS (
--	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
--	FROM tbl_IDLEDetail i
--	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
--	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC AND h.IDLE_UID=@mUID
--),
--approveDoneRecords AS(
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.[WORKED_HOURS], cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project
--	FROM tblDifference cur
--	LEFT OUTER JOIN tblDifference previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--),
--sumOfTapproveDoneRecords AS(
--	SELECT TOP (999999999999999999) CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, SUM(cur.WORKED_HOURS) AS [WORKED_HOURS]
--	FROM tblDifference cur
--	LEFT OUTER JOIN tblDifference previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID
--	ORDER BY CONVERT(date, cur.TR_OutDate), cur.TR_UID
--),
--sumOfTaskGap_WasteOurs AS(
--	SELECT CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, ISNULL(SUM(CAST(cur.TR_InDate - previous.TR_OutDate AS float)), 0) AS [WASTE_HOURS]
--	FROM tblDifference cur
--	LEFT OUTER JOIN tblDifference previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
--	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID
--),
--sumOfidleDetails AS (
--	SELECT TOP (999999999999999999) [WORKDATE], IDLE_UID, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
--	FROM idleDetails 
--	GROUP BY [WORKDATE], IDLE_UID
--	ORDER BY [WORKDATE], IDLE_UID
--),

--X1 AS (
--	SELECT TOP (999999999999999999) WORKDATE, TR_UID, SUM(ACTUAL_OUTPUT) AS [OUTPUT], SUM(X1) AS [X1]
--	FROM taskDetails
--	GROUP BY WORKDATE, TR_UID
--	ORDER BY WORKDATE, TR_UID
--),

--Y AS (
--	SELECT TOP (999999999999999999) WK.WORKDATE, WK.TR_UID,(ISNULL(WK.WORKED_HOURS,0)) AS [WORK_HOURS],(ISNULL(WK.WORKED_HOURS,0) + ISNULL(WHGAP.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
--	FROM sumOfTapproveDoneRecords WK
--	LEFT JOIN sumOfidleDetails IDLE ON WK.TR_UID =IDLE.IDLE_UID AND WK.WORKDATE = IDLE.WORKDATE
--	LEFT JOIN sumOfTaskGap_WasteOurs WHGAP ON  WK.TR_UID = WHGAP.TR_UID AND WK.WORKDATE = WHGAP.WORKDATE
--),
--X3 AS (
--	SELECT TOP (999999999999999999) X.TR_UID, X.WORKDATE, [OUTPUT], X1, [WORK_HOURS], (X.X1/CASE SIGN(ISNULL(Y1.Y,1)) WHEN -1 THEN 1 ELSE (ISNULL(Y1.Y,1)) END )*100 AS [X3]
--	FROM Y Y1
--	LEFT JOIN X1 X ON X.TR_UID =Y1.TR_UID AND X.WORKDATE = Y1.WORKDATE
--)

--/*Weekly X3 for cluster*/
--SELECT TR_UID AS [UID], SUM([OUTPUT]) AS [OUTPUT], ROUND(SUM(X1),2) AS [SUM X1], ROUND(SUM([WORK_HOURS]),2) AS [WORK HOURS], ROUND(SUM(X3),2) AS [X3], RANK() OVER (ORDER BY SUM(X3) DESC) AS [RANK]
--FROM X3
--GROUP BY TR_UID
--ORDER BY X3 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byUser_Ranked_FilterByUserAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byUser_Ranked_FilterByUserAndManager] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mUID nvarchar(20), @mMUID nvarchar(20)

AS

/* MONTHLY X3 USER */
SELECT [TR_UID] AS [UID]
	--,SUM([USER_OUTPUT]) AS [USER OUTPUT]
    --,SUM([ACTUAL_OUTPUT]) AS [OUTPUT]
	--,ROUND(SUM([WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([ACTUAL_WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([APPROVED_IDLE]),2) AS [APPROVED IDLE]
      ,ROUND(SUM([SUM_OF_X1]),2) AS [X1]
      ,ROUND(SUM([Y]),2) AS [Y]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
	  ,RANK() OVER (ORDER BY ((SUM([SUM_OF_X1])/SUM([Y])) * 100) DESC) AS [RANK]
FROM tbl_Report_TempDailyX3Users
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND TR_UID=@mUID AND TR_MID=@mMUID
GROUP BY TR_UID
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byUser_RankedAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byUser_RankedAndManager] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mMUID nvarchar(20)

AS

/* MONTHLY X3 USER */
SELECT [TR_UID] AS [UID]
	--,SUM([USER_OUTPUT]) AS [USER OUTPUT]
    --,SUM([ACTUAL_OUTPUT]) AS [OUTPUT]
	--,ROUND(SUM([WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([ACTUAL_WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([APPROVED_IDLE]),2) AS [APPROVED IDLE]
      ,ROUND(SUM([SUM_OF_X1]),2) AS [X1]
      ,ROUND(SUM([Y]),2) AS [Y]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
	  ,RANK() OVER (ORDER BY ((SUM([SUM_OF_X1])/SUM([Y])) * 100) DESC) AS [RANK]
FROM tbl_Report_TempDailyX3Users
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND TR_MID=@mMUID
GROUP BY TR_UID
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byUser_User]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byUser_User] @mFrom DateTime, @mTo DateTime, @mUID nvarchar(20)

AS

/* MONTHLY X3 USER */
SELECT [TR_UID] AS [UID]
	--,SUM([USER_OUTPUT]) AS [USER OUTPUT]
    --,SUM([ACTUAL_OUTPUT]) AS [OUTPUT]
	--,ROUND(SUM([WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([ACTUAL_WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([APPROVED_IDLE]),2) AS [APPROVED IDLE]
      ,ROUND(SUM([SUM_OF_X1]),2) AS [X1]
      ,ROUND(SUM([Y]),2) AS [Y]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
	  --,RANK() OVER (ORDER BY ((SUM([SUM_OF_X1])/SUM([Y])) * 100) DESC) AS [RANK]
FROM tbl_Report_TempDailyX3Users
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_UID=@mUID
GROUP BY TR_UID
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC


GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byUserProjectWise]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byUserProjectWise] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime

AS

SELECT
	TR_UID AS [UID]
	,[PCP_Project] AS [PROJECT]
	--,SUM([USER_OUTPUT]) AS [USER OUTPUT]
    --,SUM([ACTUAL_OUTPUT]) AS [OUTPUT]
	--,ROUND(SUM([WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([ACTUAL_WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([APPROVED_IDLE]),2) AS [APPROVED IDLE]
      ,ROUND(SUM([SUM_OF_X1]),2) AS [X1]
      ,ROUND(SUM([Y]),2) AS [Y]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
	  --,RANK() OVER (ORDER BY ((SUM([SUM_OF_X1])/SUM([Y])) * 100) DESC) AS [RANK]
FROM tbl_Report_TempDailyX3Project
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC
GROUP BY TR_UID,[PCP_Project]
ORDER BY TR_UID,(SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byUserProjectWise_FilterByUser]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byUserProjectWise_FilterByUser] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mUID nvarchar(20)

AS

SELECT
	TR_UID AS [UID]
	,[PCP_Project] AS [PROJECT]
	--,SUM([USER_OUTPUT]) AS [USER OUTPUT]
    --,SUM([ACTUAL_OUTPUT]) AS [OUTPUT]
	--,ROUND(SUM([WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([ACTUAL_WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([APPROVED_IDLE]),2) AS [APPROVED IDLE]
      ,ROUND(SUM([SUM_OF_X1]),2) AS [X1]
      ,ROUND(SUM([Y]),2) AS [Y]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
	  --,RANK() OVER (ORDER BY ((SUM([SUM_OF_X1])/SUM([Y])) * 100) DESC) AS [RANK]
FROM tbl_Report_TempDailyX3Project
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND TR_UID=@mUID
GROUP BY TR_UID,[PCP_Project]
ORDER BY TR_UID,(SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byUserProjectWiseAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byUserProjectWiseAndManager] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mMUID nvarchar(20)

AS

SELECT
	TR_UID AS [UID]
	,[PCP_Project] AS [PROJECT]
	--,SUM([USER_OUTPUT]) AS [USER OUTPUT]
    --,SUM([ACTUAL_OUTPUT]) AS [OUTPUT]
	--,ROUND(SUM([WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([ACTUAL_WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([APPROVED_IDLE]),2) AS [APPROVED IDLE]
      ,ROUND(SUM([SUM_OF_X1]),2) AS [X1]
      ,ROUND(SUM([Y]),2) AS [Y]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
	  --,RANK() OVER (ORDER BY ((SUM([SUM_OF_X1])/SUM([Y])) * 100) DESC) AS [RANK]
FROM tbl_Report_TempDailyX3Project
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND TR_MID=@mMUID
GROUP BY TR_UID,[PCP_Project]
ORDER BY TR_UID,(SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

GO
/****** Object:  StoredProcedure [dbo].[DBoard_X3byUserProjectWiseAndManager_FilterByUser]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DBoard_X3byUserProjectWiseAndManager_FilterByUser] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mUID nvarchar(20), @mMUID nvarchar(20)

AS

SELECT
	TR_UID AS [UID]
	,[PCP_Project] AS [PROJECT]
	--,SUM([USER_OUTPUT]) AS [USER OUTPUT]
    --,SUM([ACTUAL_OUTPUT]) AS [OUTPUT]
	--,ROUND(SUM([WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([ACTUAL_WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([APPROVED_IDLE]),2) AS [APPROVED IDLE]
      ,ROUND(SUM([SUM_OF_X1]),2) AS [X1]
      ,ROUND(SUM([Y]),2) AS [Y]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
	  --,RANK() OVER (ORDER BY ((SUM([SUM_OF_X1])/SUM([Y])) * 100) DESC) AS [RANK]
FROM tbl_Report_TempDailyX3Project
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND TR_MID=@mMUID AND TR_UID=@mUID
GROUP BY TR_UID,[PCP_Project]
ORDER BY TR_UID,(SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

GO
/****** Object:  StoredProcedure [dbo].[DboardPerformanceX3Task_Ranked_FilterByTask]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DboardPerformanceX3Task_Ranked_FilterByTask] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mTask nvarchar(50)

AS

/* MONTHLY X3 TASK */
SELECT [PCP_Project] AS [PROJECT]
	  ,PC_ProcessCode AS [ITEM CODE]
	  ,Task_ID AS [TASK ID]
	  ,Task_Description AS [DESCRIPTION]
	--,SUM([USER_OUTPUT]) AS [USER OUTPUT]
    --,SUM([ACTUAL_OUTPUT]) AS [OUTPUT]
	--,ROUND(SUM([WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([ACTUAL_WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([APPROVED_IDLE]),2) AS [APPROVED IDLE]
      ,ROUND(SUM([SUM_OF_X1]),2) AS [X1]
      ,ROUND(SUM([Y]),2) AS [Y]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
	  ,RANK() OVER (ORDER BY ((SUM([SUM_OF_X1])/SUM([Y])) * 100) DESC) AS [RANK]
FROM tbl_Report_TempDailyX3Task
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND Task_ID=@mTask
GROUP BY [PCP_Project],PC_ProcessCode,Task_ID,Task_Description
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

GO
/****** Object:  StoredProcedure [dbo].[DboardPerformanceX3Task_Ranked_FilterByTaskAndManager]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DboardPerformanceX3Task_Ranked_FilterByTaskAndManager] @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime, @mTask nvarchar(50), @mMUID nvarchar(20)

AS

/* MONTHLY X3 TASK */
SELECT [PCP_Project] AS [PROJECT]
	  ,PC_ProcessCode AS [ITEM CODE]
	  ,Task_ID AS [TASK ID]
	  ,Task_Description AS [DESCRIPTION]
	--,SUM([USER_OUTPUT]) AS [USER OUTPUT]
    --,SUM([ACTUAL_OUTPUT]) AS [OUTPUT]
	--,ROUND(SUM([WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([ACTUAL_WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([APPROVED_IDLE]),2) AS [APPROVED IDLE]
      ,ROUND(SUM([SUM_OF_X1]),2) AS [X1]
      ,ROUND(SUM([Y]),2) AS [Y]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
	  ,RANK() OVER (ORDER BY ((SUM([SUM_OF_X1])/SUM([Y])) * 100) DESC) AS [RANK]
FROM tbl_Report_TempDailyX3Task
WHERE WORKDATE BETWEEN @mFrom AND @mTo AND TR_PIC=@mPIC AND Task_ID=@mTask AND TR_MID=@mMUID
GROUP BY [PCP_Project],PC_ProcessCode,Task_ID,Task_Description
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

GO
/****** Object:  StoredProcedure [dbo].[DboardWorkLoadDataSetTitlesByPICAndFileName]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DboardWorkLoadDataSetTitlesByPICAndFileName] @mPIC varchar(50), @mFileName varchar(1000)

AS

SELECT PROJECT, [JOB CODE], [SHIPMENT], [FILE NAME], [TASK COUNT], [FRESH COUNT], [IN-PROCESS COUNT], [DONE COUNT], [HOLD COUNT],
	CASE WHEN ([IN-PROCESS COUNT]>=1 AND [HOLD COUNT]=0) THEN ('In-Process') ELSE (CASE WHEN ([HOLD COUNT]>=1 AND [IN-PROCESS COUNT]=0) THEN ('Hold') ELSE (CASE WHEN ([TASK COUNT]=[DONE COUNT]) THEN ('Done') ELSE (CASE WHEN ([TASK COUNT]=([DONE COUNT]+[FRESH COUNT])) THEN ('In-Process') ELSE (CASE WHEN ([TASK COUNT]=[FRESH COUNT]) THEN ('Fresh') END) END) END) END) END AS  [STATUS]
	FROM(
		SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], COUNT(pd.PCP_Status) AS [TASK COUNT], 
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=0 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [FRESH COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=2 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [IN-PROCESS COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=3 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [DONE COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=1 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [HOLD COUNT]
		FROM tbl_PCPDetail pd
		INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
		INNER JOIN tbl_PCPHeader ph ON pd.PCP_ID=ph.PCP_ID
		WHERE pch.PIC_UID=@mPIC AND pd.PCP_File=@mFileName
		GROUP BY pd.PCP_Project, pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File
	)WLResource

GO
/****** Object:  StoredProcedure [dbo].[DCD_getRegisteredPCPDetails]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DCD_getRegisteredPCPDetails] @mUID varchar(30)

AS 

	SELECT top (5000)
		d.PCPD_Index AS [#], 
		h.PCP_ID AS[Job Code], 
		h.PCP_Shipment AS [Shipment], 
		d.PC_ProcessCode AS [Process Code], 
		d.Task_ID AS [Task Code], 
		d.PCP_File AS [File Name], 
		d.PCP_FileSize AS [File Size], 
		d.PCP_Status AS [Job Status], 
		d.PCP_StartDate As [Created Date/Time], 
		d.PCP_EndDate AS [Done Date/Time], 
		d.PCP_CreatorUID AS [DCD User] 
	FROM 
		tbl_PCPHeader h 
		INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID 
		INNER JOIN tbl_ManagerDetail u ON u.M_Project = d.PCP_Project AND u.M_UID = @mUID 
	ORDER BY d.PCPD_Index DESC

GO
/****** Object:  StoredProcedure [dbo].[DILE_checkTimeSpanOnIDLERecord]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DILE_checkTimeSpanOnIDLERecord] @mUID varchar(30), @mIdleIn datetime, @mIdleOut datetime

AS 
	
	SELECT 
		d.IDLE_UID, 
		h.IDLE_Project, 
		d.IDLE_InDate, 
		d.IDLE_OutDate 
	FROM 
		tbl_IDLEDetail d 
		INNER JOIN tbl_IDLEHeader h ON d.IDLE_ID = h.IDLE_ID
	WHERE 
		d.IDLE_UID = @mUID AND 
		(@mIdleIn BETWEEN d.IDLE_InDate AND d.IDLE_OutDate OR
		 @mIdleOut BETWEEN d.IDLE_InDate AND d.IDLE_OutDate)

	--SELECT 
	--	d.IDLE_UID, 
	--	h.IDLE_Project, 
	--	d.IDLE_InDate, 
	--	d.IDLE_OutDate 
	--FROM 
	--	tbl_IDLEDetail d 
	--	INNER JOIN tbl_IDLEHeader h ON d.IDLE_ID = h.IDLE_ID 
	--WHERE d.IDLE_UID = @mUID 
	----AND h.IDLE_Project = @mProject 
	--AND ((d.IDLE_InDate BETWEEN @mIdleIn AND @mIdleOut OR d.IDLE_OutDate BETWEEN @mIdleIn AND @mIdleOut) 
	--OR (@mIdleIn < d.IDLE_InDate OR d.IDLE_InDate > @mIdleOut) OR (@mIdleIn < d.IDLE_OutDate OR d.IDLE_OutDate > @mIdleOut))
GO
/****** Object:  StoredProcedure [dbo].[ScheduledX3Calculation]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ScheduledX3Calculation] 
AS 

set xact_abort on

/* Wokred Shift for 9 hours */
DECLARE @K int;
declare @starttime datetime
declare @endtime datetime
declare @workstation varchar(200)

SET @K=32400;
set @starttime = getdate()  
set @workstation= HOST_NAME()

TRUNCATE TABLE tbl_Report_TempidleDetails;
TRUNCATE TABLE tbl_Report_TempsumofidleDetails;
--TRUNCATE TABLE tbl_Report_TempModifiedTaskDetails;
TRUNCATE TABLE tbl_Report_TemptblDifference;
TRUNCATE TABLE tbl_Report_TemptaskDetails;
TRUNCATE TABLE tbl_Report_TemptaskDetailsQUOTA_Updated;
TRUNCATE TABLE tbl_Report_TempDailyX3Users;
TRUNCATE TABLE tbl_Report_TempDailyX3Project;
TRUNCATE TABLE tbl_Report_TempDailyX3Task;
TRUNCATE TABLE tbl_Report_TempIDLEAndWastage;

/* IDLE DETAILS */
INSERT INTO tbl_Report_TempidleDetails
	SELECT 
		i.IDLE_Index, 
		CONVERT(date, i.IDLE_InDate) AS [WORKDATE], 
		i.IDLE_ID, i.IDLE_UID, 
		i.IDLE_InDate,
		i.IDLE_OutDate,
		ROUND(ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0)*24,2) AS [IDLE_TIME], 
		i.IDLE_Reason,i.IDLE_MID, 
		i.IDLE_PIC, h.IDLE_Project
	FROM 
		tbl_IDLEDetail i
		INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
	/*WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC AND h.IDLE_UID=@mUID*/

/* SUM OF IDLE DETAILS */
INSERT INTO tbl_Report_TempsumofidleDetails
	SELECT TOP (999999999999999999)
		 [WORKDATE], 
		 IDLE_UID, SUM ([IDLE_TIME]) AS [APPROVED_IDLE], 
		 IDLE_Project
	FROM 
		tbl_Report_TempidleDetails 
	GROUP BY 
		[WORKDATE], 
		IDLE_UID, 
		IDLE_Project
	ORDER BY 
		[WORKDATE], 
		IDLE_UID, 
		IDLE_Project

/* MODIFIED TASK RECORDS */
--INSERT INTO tbl_Report_TempModifiedTaskDetails
--SELECT h.TR_ID
--      ,MAX(d.[TR_FileSize]) AS [MODIFIED_OUTPUT]
--      ,d.[TR_UID]
--      ,d.[TRM_PIC]
--      ,d.[TRM_MID]
--      ,MAX(d.[TRM_Hours]) AS [MODIFIED_HOURS]
--  FROM [CITITO].[dbo].[tbl_TaskRecordDetailModify] d
--  INNER JOIN [tbl_TaskRecordHeaderModify] h ON h.TRM_ID=d.TRM_ID
--  WHERE d.TRM_Apporval=2
--  GROUP BY h.TR_ID,d.[TR_UID],d.[TRM_PIC],d.[TRM_MID] 

/* TASK TIME GAP */
INSERT INTO tbl_Report_TemptblDifference 
	SELECT TOP (999999999999999999) 
		ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, 
		d.TR_Index, 
		CONVERT(date, 
		d.TR_ActualTaskIn) AS [WORKDATE], 
		d.TR_ID, d.TR_UID, 
		d.TR_InDate,
		d.TR_ActualTaskIn, 
		d.TR_OutDate, 
		d.TR_Status, 
		d.TR_Apporval,
		usr.M_UID,
		usr.PIC_UID,
		d.TR_Shipment,
		d.TR_File,
		ROUND(ISNULL(CAST(d.TR_FileSize AS float),0),2) AS [ACTUAL_OUTPUT],
		d.TR_Hours AS [WORKED_HOURS], 
		ams.FIRSTLOGIN,ams.LASTLOGOUT,
		ISNULL(CAST(ams.LASTLOGOUT - ams.FIRSTLOGIN AS float)*24,0),
		idl.IDLE_InDate,
		IDLE_OutDate,
		ISNULL(CAST(idl.IDLE_OutDate - idl.IDLE_InDate AS float)*24,0),
		ROUND(ISNULL(CAST(d.TR_Quota AS float),0),2) AS [QUOTA], 
		d.TR_UOM, d.PCP_ID, d.Task_ID, 
		p.PC_ProcessCode, 
		p.PCP_Project
    FROM 
		tbl_TaskRecordDetail d
		LEFT OUTER JOIN tbl_UserLILO ams ON d.TR_UID=ams.[UID] AND CONVERT(date, d.TR_ActualTaskIn)=CONVERT(date, ams.[DATE])
		LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
		LEFT OUTER JOIN tbl_UserManagementDetail usr ON usr.P_UID=d.TR_UID AND usr.P_Project_Availability='Active' AND usr.P_Project=p.PCP_Project
		LEFT OUTER JOIN tbl_Report_TempidleDetails idl ON idl.IDLE_Project=p.PCP_Project AND  d.TR_UID=idl.IDLE_UID AND CONVERT(date, d.TR_OutDate)=idl.WORKDATE AND idl.IDLE_Project=usr.P_Project
	/*WHERE d.TR_ActualTaskIn BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC AND d.TR_Status IS NOT NULL*/
	ORDER BY 
		d.TR_UID

--INSERT INTO tbl_Report_TemptblDifference 
--	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_ActualTaskIn) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate,d.TR_ActualTaskIn, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ROUND(ISNULL(CAST(d.TR_FileSize AS float),0),2) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS], 
--	ams.FIRSTLOGIN,ams.LASTLOGOUT,ISNULL(CAST(ams.LASTLOGOUT - ams.FIRSTLOGIN AS float)*24,0),idl.IDLE_InDate,IDLE_OutDate,ISNULL(CAST(idl.IDLE_OutDate - idl.IDLE_InDate AS float)*24,0),
--	ROUND(ISNULL(CAST(d.TR_Quota AS float),0),2) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
--    FROM tbl_TaskRecordDetail d
--	LEFT OUTER JOIN tbl_UserLILO ams ON d.TR_UID=ams.[UID] AND CONVERT(date, d.TR_ActualTaskIn)=CONVERT(date, ams.[DATE])
--	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
--	LEFT OUTER JOIN tbl_Report_TempidleDetails idl ON idl.IDLE_Project=p.PCP_Project AND  d.TR_UID=idl.IDLE_UID AND CONVERT(date, d.TR_OutDate)=idl.WORKDATE
--	/*WHERE d.TR_ActualTaskIn BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC AND d.TR_Status IS NOT NULL*/
--	ORDER BY d.TR_UID


/* TASK DETAILS */ -- Any Fiter Apply to This ###################
INSERT INTO tbl_Report_TemptaskDetails 
	SELECT 
		cur.RowNumber, 
		cur.TR_Index, 
		CONVERT(date, cur.TR_OutDate) AS [WORKDATE], 
		cur.TR_ID, 
		cur.TR_UID, 
		cur.TR_InDate, 
		cur.TR_ActualTaskIn, 
		cur.TR_OutDate,
		cur.[WORKED_HOURS], 
		cur.[LOGIN],
		cur.[LOGOUT],
		ISNULL(CAST(cur.LOGOUT - cur.LOGIN AS float),0)*24 AS ACTUAL_WORKED_HOURS
	/*ISNULL(CAST(cur.TR_OutDate - cur.TR_ActualTaskIn AS float),0)*24 AS ACTUAL_WORKED_HOURS*/
	--CASE WHEN (SELECT COUNT(rec.TR_ID) AS [RecCOUNT] FROM tbl_TaskRecordDetail rec WHERE cur.PCP_ID=rec.PCP_ID AND cur.Task_ID=rec.Task_ID) > 1 THEN (CASE WHEN cur.TR_Apporval=2 AND cur.TR_Status=3 THEN ISNULL((cur.AMS_DIFF+(SELECT SUM(rec.AMS_DIFF) FROM tbl_Report_TemptblDifference rec WHERE cur.PCP_ID=rec.PCP_ID AND cur.Task_ID=rec.Task_ID AND rec.TR_Status=2 AND rec.TR_Apporval=4)),cur.AMS_DIFF) ELSE (cur.AMS_DIFF) END) ELSE (cur.AMS_DIFF) END AS [ACTUAL_WORKED_HOURS]
		,cur.TR_Status, 
		cur.TR_Apporval,
		cur.TR_MID,
		cur.TR_PIC,
		cur.TR_Shipment,
		cur.TR_File,
		cur.[ACTUAL_OUTPUT],
		CASE WHEN (SELECT COUNT(rec.TR_ID) AS [RecCOUNT] FROM tbl_TaskRecordDetail rec WHERE cur.PCP_ID=rec.PCP_ID AND cur.Task_ID=rec.Task_ID) > 1 THEN (CASE WHEN cur.TR_Apporval=2 AND cur.TR_Status=3 THEN (cur.[ACTUAL_OUTPUT]-(SELECT SUM(rec.TR_FileSize) FROM tbl_TaskRecordDetail rec WHERE cur.PCP_ID=rec.PCP_ID AND cur.Task_ID=rec.Task_ID AND rec.TR_Status=2 AND rec.TR_Apporval=4)) ELSE (cur.[ACTUAL_OUTPUT]) END) ELSE (cur.[ACTUAL_OUTPUT]) END AS [ACTUAL_OUTPUT]
		,cur.[QUOTA],
		cur.TR_UOM,
		cur.PCP_ID,
		cur.Task_ID,
		cur.PC_ProcessCode,
		cur.PCP_Project
	FROM 
		tbl_Report_TemptblDifference cur
		LEFT OUTER JOIN tbl_Report_TemptblDifference previous ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_ActualTaskIn) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	--WHERE cur.[LOGIN] IS NOT NULL OR cur.[LOGOUT] IS NOT NULL
	WHERE 
		cur.TR_Status=3 AND cur.TR_Apporval=2 /*AND cur.TR_UID=@mUID*/

/* REMOVE DUPLICATES */


;WITH cte AS (
  SELECT [TR_Index]
      ,[WORKDATE]
      ,[TR_ID]
      ,[TR_UID]
      ,[TR_InDate]
      ,[TR_ActualTaskIn]
      ,[TR_OutDate]
      ,[WORKED_HOURS]
      ,[LOGIN]
      ,[LOGOUT]
      ,[ACTUAL_WORKED_HOURS]
      ,[TR_Status]
      ,[TR_Apporval]
      ,[TR_MID]
      ,[TR_PIC]
      ,[TR_Shipment]
      ,[TR_File]
      ,[USER_OUTPUT]
      ,[ACTUAL_OUTPUT]
      ,[QUOTA]
      ,[TR_UOM]
      ,[PCP_ID]
      ,[Task_ID]
      ,[PC_ProcessCode]
      ,[PCP_Project], 
     row_number() OVER(PARTITION BY [TR_Index]
      ,[WORKDATE]
      ,[TR_ID]
      ,[TR_UID]
      ,[TR_InDate]
      ,[TR_ActualTaskIn]
      ,[TR_OutDate]
      ,[WORKED_HOURS]
      ,[LOGIN]
      ,[LOGOUT]
      ,[ACTUAL_WORKED_HOURS]
      ,[TR_Status]
      ,[TR_Apporval]
      ,[TR_MID]
      ,[TR_PIC]
      ,[TR_Shipment]
      ,[TR_File]
      ,[USER_OUTPUT]
      ,[ACTUAL_OUTPUT]
      ,[QUOTA]
      ,[TR_UOM]
      ,[PCP_ID]
      ,[Task_ID]
      ,[PC_ProcessCode]
      ,[PCP_Project] ORDER BY [TR_Index]) AS [rn]
  FROM tbl_Report_TemptaskDetails
)
DELETE cte WHERE [rn] > 1



/* REMOVE DUPLICATES */

INSERT INTO tbl_Report_TemptaskDetailsQUOTA_Updated 
	SELECT 
		cur.RowNumber, 
		cur.TR_Index, 
		CONVERT(date, cur.TR_OutDate) AS [WORKDATE], 
		cur.TR_ID, 
		cur.TR_UID, 
		cur.TR_InDate, 
		cur.TR_ActualTaskIn, 
		cur.TR_OutDate,
		cur.[WORKED_HOURS], 
		cur.[LOGIN],
		cur.[LOGOUT], 
		cur.ACTUAL_WORKED_HOURS, 
		cur.TR_Status, 
		cur.TR_Apporval,
		cur.TR_MID,
		cur.TR_PIC,
		cur.TR_Shipment,
		cur.TR_File,
		cur.USER_OUTPUT,
		cur.[ACTUAL_OUTPUT] AS [ACTUAL_OUTPUT],
		cur.[QUOTA],
		cur.TR_UOM,
		cur.PCP_ID,
		cur.Task_ID,
		cur.PC_ProcessCode,
		cur.PCP_Project, 
		((cur.USER_OUTPUT/cur.QUOTA) * @K) AS X1, 
		(cur.WORKED_HOURS * 3600)  AS Y, 
		((cur.USER_OUTPUT/cur.QUOTA) * @K/(cur.WORKED_HOURS * 3600)) * 100 AS X3
	FROM 
		tbl_Report_TemptaskDetails cur

/* DAILY X3 User*/


INSERT INTO tbl_Report_TempDailyX3Users
	SELECT 
		tsk.WORKDATE,
		tsk.TR_UID,tsk.TR_MID,
		tsk.TR_PIC, 
		SUM(tsk.WORKED_HOURS) AS WORKED_HOURS, 
		MAX(tsk.ACTUAL_WORKED_HOURS) AS ACTUAL_WORKED_HOURS, 
		SUM(tsk.USER_OUTPUT) AS USER_OUTPUT, 
		SUM(tsk.ACTUAL_OUTPUT) AS ACTUAL_OUTPUT, 
		MAX(ISNULL(idle.APPROVED_IDLE,0)) AS APPROVED_IDLE, 
		SUM(tsk.X1) AS SUM_OF_X1, 
		(MAX(tsk.ACTUAL_WORKED_HOURS) * 3600)  AS Y, 
		(SUM(tsk.X1)/((MAX(tsk.ACTUAL_WORKED_HOURS) * 3600)- ISNULL(idle.APPROVED_IDLE,0))) * 100 AS X3/**/
	FROM 
		tbl_Report_TemptaskDetailsQUOTA_Updated tsk
		LEFT OUTER JOIN tbl_Report_TempsumofidleDetails idle ON tsk.WORKDATE=idle.WORKDATE AND tsk.TR_UID=idle.IDLE_UID
	WHERE 
		tsk.[LOGIN] IS NOT NULL AND tsk.[LOGOUT] IS NOT NULL  /*AND tsk.WORKDATE BETWEEN '2018-04-01' AND '2018-04-30'  AND tsk.TR_PIC='EC4'*/
	GROUP BY 
		tsk.WORKDATE, 
		tsk.TR_UID, 
		idle.APPROVED_IDLE,
		tsk.TR_MID,
		tsk.TR_PIC
	ORDER BY 
		WORKDATE

--SELECT tsk.WORKDATE,tsk.TR_UID,userd.M_UID,userd.PIC_UID, SUM(tsk.WORKED_HOURS) AS WORKED_HOURS, MAX(tsk.ACTUAL_WORKED_HOURS) AS ACTUAL_WORKED_HOURS, SUM(tsk.USER_OUTPUT) AS USER_OUTPUT, SUM(tsk.ACTUAL_OUTPUT) AS ACTUAL_OUTPUT, MAX(ISNULL(idle.APPROVED_IDLE,0)) AS APPROVED_IDLE, SUM(tsk.X1) AS SUM_OF_X1, (MAX(tsk.ACTUAL_WORKED_HOURS) * 3600)  AS Y, (SUM(tsk.X1)/((MAX(tsk.ACTUAL_WORKED_HOURS) * 3600)- ISNULL(idle.APPROVED_IDLE,0))) * 100 AS X3/**/
--FROM tbl_Report_TemptaskDetailsQUOTA_Updated tsk
--LEFT OUTER JOIN tbl_Report_TempsumofidleDetails idle ON tsk.WORKDATE=idle.WORKDATE AND tsk.TR_UID=idle.IDLE_UID
--LEFT OUTER JOIN [tbl_UserManagementDetail] userd ON userd.P_UID=tsk.TR_UID
--WHERE tsk.[LOGIN] IS NOT NULL AND tsk.[LOGOUT] IS NOT NULL  /*AND tsk.WORKDATE BETWEEN '2018-02-01' AND '2018-02-28'  AND userd.PIC_UID='ZDQ'*/
--GROUP BY tsk.WORKDATE, tsk.TR_UID, idle.APPROVED_IDLE,userd.M_UID,userd.PIC_UID
--ORDER BY WORKDATE

/* DAILY X3 Project*/
INSERT INTO tbl_Report_TempDailyX3Project
	SELECT 
		tsk.WORKDATE,
		tsk.PCP_Project,
		tsk.TR_UID,
		tsk.TR_MID,
		tsk.TR_PIC, 
		SUM(tsk.WORKED_HOURS) AS WORKED_HOURS, 
		MAX(tsk.ACTUAL_WORKED_HOURS) AS ACTUAL_WORKED_HOURS, 
		SUM(tsk.USER_OUTPUT) AS USER_OUTPUT, 
		SUM(tsk.ACTUAL_OUTPUT) AS ACTUAL_OUTPUT, 
		MAX(ISNULL(idle.APPROVED_IDLE,0)) AS APPROVED_IDLE, 
		SUM(tsk.X1) AS SUM_OF_X1, 
		(MAX(tsk.ACTUAL_WORKED_HOURS) * 3600)  AS Y, 
		(SUM(tsk.X1)/((MAX(tsk.ACTUAL_WORKED_HOURS) * 3600)- ISNULL(idle.APPROVED_IDLE,0))) * 100 AS X3/**/
	FROM 
		tbl_Report_TemptaskDetailsQUOTA_Updated tsk
		LEFT OUTER JOIN tbl_Report_TempsumofidleDetails idle ON tsk.WORKDATE=idle.WORKDATE AND tsk.TR_UID=idle.IDLE_UID
	WHERE 
		tsk.[LOGIN] IS NOT NULL AND tsk.[LOGOUT] IS NOT NULL  /*AND tsk.WORKDATE BETWEEN '2018-02-01' AND '2018-02-28'  AND userd.PIC_UID='ZDQ'*/
	GROUP BY 
		tsk.WORKDATE, 
		tsk.PCP_Project, 
		tsk.TR_UID, 
		idle.APPROVED_IDLE,
		tsk.TR_MID,
		tsk.TR_PIC
	ORDER BY 
		WORKDATE

--SELECT tsk.WORKDATE,tsk.PCP_Project,tsk.TR_UID,userd.M_UID,userd.PIC_UID, SUM(tsk.WORKED_HOURS) AS WORKED_HOURS, MAX(tsk.ACTUAL_WORKED_HOURS) AS ACTUAL_WORKED_HOURS, SUM(tsk.USER_OUTPUT) AS USER_OUTPUT, SUM(tsk.ACTUAL_OUTPUT) AS ACTUAL_OUTPUT, MAX(ISNULL(idle.APPROVED_IDLE,0)) AS APPROVED_IDLE, SUM(tsk.X1) AS SUM_OF_X1, (MAX(tsk.ACTUAL_WORKED_HOURS) * 3600)  AS Y, (SUM(tsk.X1)/((MAX(tsk.ACTUAL_WORKED_HOURS) * 3600)- ISNULL(idle.APPROVED_IDLE,0))) * 100 AS X3/**/
--FROM tbl_Report_TemptaskDetailsQUOTA_Updated tsk
--LEFT OUTER JOIN tbl_Report_TempsumofidleDetails idle ON tsk.WORKDATE=idle.WORKDATE AND tsk.TR_UID=idle.IDLE_UID
--LEFT OUTER JOIN [tbl_UserManagementDetail] userd ON userd.P_UID=tsk.TR_UID
--WHERE tsk.[LOGIN] IS NOT NULL AND tsk.[LOGOUT] IS NOT NULL  /*AND tsk.WORKDATE BETWEEN '2018-02-01' AND '2018-02-28'  AND userd.PIC_UID='ZDQ'*/
--GROUP BY tsk.WORKDATE, tsk.PCP_Project, tsk.TR_UID, idle.APPROVED_IDLE,userd.M_UID,userd.PIC_UID
--ORDER BY WORKDATE

/* DAILY X3 Task*/
INSERT INTO tbl_Report_TempDailyX3Task
	SELECT 
		tsk.WORKDATE,
		tsk.PCP_Project,
		tsk.PC_ProcessCode,
		tsk.Task_ID,
		td.Task_Description,
		tsk.TR_UID,
		tsk.TR_MID,
		tsk.TR_PIC, 
		SUM(tsk.WORKED_HOURS) AS WORKED_HOURS, 
		MAX(tsk.ACTUAL_WORKED_HOURS) AS ACTUAL_WORKED_HOURS, 
		SUM(tsk.USER_OUTPUT) AS USER_OUTPUT, 
		SUM(tsk.ACTUAL_OUTPUT) AS ACTUAL_OUTPUT, 
		MAX(ISNULL(idle.APPROVED_IDLE,0)) AS APPROVED_IDLE, 
		SUM(tsk.X1) AS SUM_OF_X1, 
		(MAX(tsk.ACTUAL_WORKED_HOURS) * 3600)  AS Y, 
		(SUM(tsk.X1)/((MAX(tsk.ACTUAL_WORKED_HOURS) * 3600)- ISNULL(idle.APPROVED_IDLE,0))) * 100 AS X3/**/
	FROM 
		tbl_Report_TemptaskDetailsQUOTA_Updated tsk
		LEFT OUTER JOIN tbl_Report_TempsumofidleDetails idle ON tsk.WORKDATE=idle.WORKDATE AND tsk.TR_UID=idle.IDLE_UID
		LEFT OUTER JOIN tbl_TaskDetail td ON td.Task_ID=tsk.Task_ID AND td.PIC_Project=tsk.PCP_Project AND td.PC_ProcessCode=tsk.PC_ProcessCode
	WHERE 
		tsk.[LOGIN] IS NOT NULL AND tsk.[LOGOUT] IS NOT NULL  /*AND tsk.WORKDATE BETWEEN '2018-02-01' AND '2018-02-28'  AND userd.PIC_UID='ZDQ'*/
	GROUP BY 
		tsk.WORKDATE, 
		tsk.PCP_Project, 
		tsk.TR_UID, 
		idle.APPROVED_IDLE,
		tsk.TR_MID,
		tsk.TR_PIC,
		tsk.Task_ID,
		tsk.PC_ProcessCode,
		td.Task_Description
	ORDER BY 
		WORKDATE

--SELECT tsk.WORKDATE,tsk.PCP_Project,tsk.PC_ProcessCode,tsk.Task_ID,td.Task_Description,tsk.TR_UID,userd.M_UID,userd.PIC_UID, SUM(tsk.WORKED_HOURS) AS WORKED_HOURS, MAX(tsk.ACTUAL_WORKED_HOURS) AS ACTUAL_WORKED_HOURS, SUM(tsk.USER_OUTPUT) AS USER_OUTPUT, SUM(tsk.ACTUAL_OUTPUT) AS ACTUAL_OUTPUT, MAX(ISNULL(idle.APPROVED_IDLE,0)) AS APPROVED_IDLE, SUM(tsk.X1) AS SUM_OF_X1, (MAX(tsk.ACTUAL_WORKED_HOURS) * 3600)  AS Y, (SUM(tsk.X1)/((MAX(tsk.ACTUAL_WORKED_HOURS) * 3600)- ISNULL(idle.APPROVED_IDLE,0))) * 100 AS X3/**/
--FROM tbl_Report_TemptaskDetailsQUOTA_Updated tsk
--LEFT OUTER JOIN tbl_Report_TempsumofidleDetails idle ON tsk.WORKDATE=idle.WORKDATE AND tsk.TR_UID=idle.IDLE_UID
--LEFT OUTER JOIN [tbl_UserManagementDetail] userd ON userd.P_UID=tsk.TR_UID
--LEFT OUTER JOIN tbl_TaskDetail td ON td.Task_ID=tsk.Task_ID AND td.PIC_Project=tsk.PCP_Project AND td.PC_ProcessCode=tsk.PC_ProcessCode
--WHERE tsk.[LOGIN] IS NOT NULL AND tsk.[LOGOUT] IS NOT NULL  /*AND tsk.WORKDATE BETWEEN '2018-02-01' AND '2018-02-28'  AND userd.PIC_UID='ZDQ'*/
--GROUP BY tsk.WORKDATE, tsk.PCP_Project, tsk.TR_UID, idle.APPROVED_IDLE,userd.M_UID,userd.PIC_UID,tsk.Task_ID,tsk.PC_ProcessCode,td.Task_Description
--ORDER BY WORKDATE

/* IDLE AND WASTAGE */
INSERT INTO tbl_Report_TempIDLEAndWastage
	SELECT 
		T.TR_UID AS [UID], 
		usr.M_UID AS [MID], 
		usr.PIC_UID AS [PIC], 
		convert(date,L.[DATE]) AS [DATE],
		L.FIRSTLOGIN, L.LASTLOGOUT, 
		ROUND(ISNULL(CAST(L.LASTLOGOUT-L.FIRSTLOGIN AS float)*24,0),2) AS [AMSDIFF], 
		MIN(T.TR_ActualTaskIn) AS [TASKED-IN], 
		MAX(T.TR_OutDate) AS [TASKED-OUT], 
		ROUND(ISNULL(CAST(MAX(T.TR_OutDate)-MIN(T.TR_ActualTaskIn) AS float)*24,0),2) AS [TASKDIFF], 
		ISNULL((I.APPROVED_IDLE),0) AS [APPROVED_IDLE], 
		((ROUND(ISNULL(CAST(L.LASTLOGOUT-L.FIRSTLOGIN AS float)*24,0),2))-(ROUND(ISNULL(CAST(MAX(T.TR_OutDate)-MIN(T.TR_ActualTaskIn) AS float)*24,0),2)))-(ISNULL((I.APPROVED_IDLE),0)) AS [WASTAGE]
	FROM 
		tbl_TaskRecordDetail T
		INNER JOIN tbl_UserLILO L ON T.TR_UID=L.[UID] AND L.[DATE]=convert(date, T.TR_ActualTaskIn)
		LEFT OUTER JOIN tbl_Report_TempsumofidleDetails I ON I.WORKDATE=convert(date, T.TR_ActualTaskIn) AND T.TR_UID=I.IDLE_UID
		LEFT OUTER JOIN tbl_UserManagementDetail usr ON usr.P_UID=T.TR_UID AND usr.P_Project_Availability='Active'
	--WHERE T.TR_PIC='16V' AND T.TR_InDate BETWEEN '2018-02-01' AND '2018-02-28' 
	GROUP BY  
		T.TR_UID, 
		usr.M_UID,  
		usr.PIC_UID, 
		L.[DATE], 
		L.FIRSTLOGIN, 
		L.LASTLOGOUT,
		L.[UID],
		I.APPROVED_IDLE
	--HAVING (CAST(ROUND(DATEDIFF(MINUTE,L.LASTLOGOUT, MAX(T.TR_OutDate))/60.0, 3)AS decimal (6,3))) NOT IN (0)
	ORDER BY 
		L.[DATE] DESC
--SELECT T.TR_UID AS [UID], T.TR_MID AS [MID], T.TR_PIC AS [PIC], convert(date,L.[DATE]) AS [DATE],L.FIRSTLOGIN, L.LASTLOGOUT, ROUND(ISNULL(CAST(L.LASTLOGOUT-L.FIRSTLOGIN AS float)*24,0),2) AS [AMSDIFF], MIN(T.TR_ActualTaskIn) AS [TASKED-IN], MAX(T.TR_OutDate) AS [TASKED-OUT], ROUND(ISNULL(CAST(MAX(T.TR_OutDate)-MIN(T.TR_ActualTaskIn) AS float)*24,0),2) AS [TASKDIFF], ISNULL(SUM(I.APPROVED_IDLE),0) AS [APPROVED_IDLE], ((ROUND(ISNULL(CAST(L.LASTLOGOUT-L.FIRSTLOGIN AS float)*24,0),2))-(ROUND(ISNULL(CAST(MAX(T.TR_OutDate)-MIN(T.TR_ActualTaskIn) AS float)*24,0),2)))-(ISNULL(SUM(I.APPROVED_IDLE),0)) AS [WASTAGE]
--	FROM tbl_TaskRecordDetail T
--	INNER JOIN tbl_UserLILO L ON T.TR_UID=L.[UID] AND L.[DATE]=convert(date, T.TR_ActualTaskIn)
--	LEFT OUTER JOIN tbl_Report_TempsumofidleDetails I ON I.WORKDATE=convert(date, T.TR_ActualTaskIn) AND T.TR_UID=I.IDLE_UID
--	--WHERE T.TR_PIC='16V' AND T.TR_InDate BETWEEN '2018-02-01' AND '2018-02-28' 
--	GROUP BY  T.TR_UID, T.TR_MID, T.TR_PIC, L.[DATE], L.FIRSTLOGIN, L.LASTLOGOUT
--	--HAVING (CAST(ROUND(DATEDIFF(MINUTE,L.LASTLOGOUT, MAX(T.TR_OutDate))/60.0, 3)AS decimal (6,3))) NOT IN (0)
--	ORDER BY L.[DATE] DESC


--INSERT INTO tbl_Report_TempIDLEAndWastage
--SELECT T.TR_UID AS [UID], T.TR_MID AS [MID], T.TR_PIC AS [PIC], convert(date,L.[DATE]) AS [DATE],L.FIRSTLOGIN, L.LASTLOGOUT, ROUND(ISNULL(CAST(L.LASTLOGOUT-L.FIRSTLOGIN AS float)*24,0),2) AS [AMSDIFF], MIN(T.TR_ActualTaskIn) AS [TASKED-IN], MAX(T.TR_OutDate) AS [TASKED-OUT], ROUND(ISNULL(CAST(MAX(T.TR_OutDate)-MIN(T.TR_ActualTaskIn) AS float)*24,0),2) AS [TASKDIFF], ISNULL((I.APPROVED_IDLE),0) AS [APPROVED_IDLE], ((ROUND(ISNULL(CAST(L.LASTLOGOUT-L.FIRSTLOGIN AS float)*24,0),2))-(ROUND(ISNULL(CAST(MAX(T.TR_OutDate)-MIN(T.TR_ActualTaskIn) AS float)*24,0),2)))-(ISNULL((I.APPROVED_IDLE),0)) AS [WASTAGE]
--	FROM tbl_TaskRecordDetail T
--	INNER JOIN tbl_UserLILO L ON T.TR_UID=L.[UID] AND L.[DATE]=convert(date, T.TR_ActualTaskIn)
--	LEFT OUTER JOIN tbl_Report_TempsumofidleDetails I ON I.WORKDATE=convert(date, T.TR_ActualTaskIn) AND T.TR_UID=I.IDLE_UID
--	--WHERE T.TR_PIC='16V' AND T.TR_InDate BETWEEN '2018-02-01' AND '2018-02-28' 
--	GROUP BY  T.TR_UID, T.TR_MID, T.TR_PIC, L.[DATE], L.FIRSTLOGIN, L.LASTLOGOUT,L.[UID],I.APPROVED_IDLE
--	--HAVING (CAST(ROUND(DATEDIFF(MINUTE,L.LASTLOGOUT, MAX(T.TR_OutDate))/60.0, 3)AS decimal (6,3))) NOT IN (0)
--	ORDER BY L.[DATE] DESC
----SELECT T.TR_UID AS [UID], T.TR_MID AS [MID], T.TR_PIC AS [PIC], convert(date,L.[DATE]) AS [DATE],L.FIRSTLOGIN, L.LASTLOGOUT, ROUND(ISNULL(CAST(L.LASTLOGOUT-L.FIRSTLOGIN AS float)*24,0),2) AS [AMSDIFF], MIN(T.TR_ActualTaskIn) AS [TASKED-IN], MAX(T.TR_OutDate) AS [TASKED-OUT], ROUND(ISNULL(CAST(MAX(T.TR_OutDate)-MIN(T.TR_ActualTaskIn) AS float)*24,0),2) AS [TASKDIFF], ISNULL(SUM(I.APPROVED_IDLE),0) AS [APPROVED_IDLE], ((ROUND(ISNULL(CAST(L.LASTLOGOUT-L.FIRSTLOGIN AS float)*24,0),2))-(ROUND(ISNULL(CAST(MAX(T.TR_OutDate)-MIN(T.TR_ActualTaskIn) AS float)*24,0),2)))-(ISNULL(SUM(I.APPROVED_IDLE),0)) AS [WASTAGE]
----	FROM tbl_TaskRecordDetail T
----	INNER JOIN tbl_UserLILO L ON T.TR_UID=L.[UID] AND L.[DATE]=convert(date, T.TR_ActualTaskIn)
----	LEFT OUTER JOIN tbl_Report_TempsumofidleDetails I ON I.WORKDATE=convert(date, T.TR_ActualTaskIn) AND T.TR_UID=I.IDLE_UID
----	--WHERE T.TR_PIC='16V' AND T.TR_InDate BETWEEN '2018-02-01' AND '2018-02-28' 
----	GROUP BY  T.TR_UID, T.TR_MID, T.TR_PIC, L.[DATE], L.FIRSTLOGIN, L.LASTLOGOUT
----	--HAVING (CAST(ROUND(DATEDIFF(MINUTE,L.LASTLOGOUT, MAX(T.TR_OutDate))/60.0, 3)AS decimal (6,3))) NOT IN (0)
----	ORDER BY L.[DATE] DESC


/* LOG */
set @endtime = GETDATE()
INSERT INTO tbl_QueryLog (WorkDate,StartTime,EndTime,ExecutedTime,QueryOwner,Workstation) 
VALUES(CONVERT(date, @starttime),@starttime,@endtime,CONVERT(VARCHAR(12),@endtime-@starttime, 114),CURRENT_USER,@workstation)

GO
/****** Object:  StoredProcedure [dbo].[User_getAllTaskInAndOutDetails]    Script Date: 6/11/2018 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[User_getAllTaskInAndOutDetails] @mUID varchar(30)

AS

SELECT
	d.TR_ID AS [#], 
	h.PCP_ID AS[Job Code], 
	d.TR_Shipment AS [Shipment], 
	d.TR_File AS [File Name], 
	d.TR_FileSize AS [Output], 
	d.TR_UOM AS [OUM], 
	d.Task_ID AS [Task], 
	d.TR_Status AS [Job Status], 
	d.TR_InDate AS [Task In Time], 
	d.TR_OutDate AS [Task Out Time], 
	d.TR_Hours AS [Task Hours], 
	d.TR_Apporval As [Approval Status], 
	d.TR_ApprovalTime As [Approval Time], 
	d.TR_Productivity AS [Task Productivity] 
FROM 
	tbl_TaskRecordHeader h 
	INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID 
WHERE 
	d.TR_UID = @mUID AND TR_Status!='' 
ORDER BY 
	d.TR_Index DESC

GO
USE [master]
GO
ALTER DATABASE [CITITO] SET  READ_WRITE 
GO
