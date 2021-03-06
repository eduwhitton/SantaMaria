USE [master]
GO
/****** Object:  Database [SantaMaria]    Script Date: 03/06/2017 12:26:43 p.m. ******/
CREATE DATABASE [SantaMaria]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SantaMaria', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\SantaMaria.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SantaMaria_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\SantaMaria_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SantaMaria] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SantaMaria].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SantaMaria] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SantaMaria] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SantaMaria] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SantaMaria] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SantaMaria] SET ARITHABORT OFF 
GO
ALTER DATABASE [SantaMaria] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SantaMaria] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SantaMaria] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SantaMaria] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SantaMaria] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SantaMaria] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SantaMaria] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SantaMaria] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SantaMaria] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SantaMaria] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SantaMaria] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SantaMaria] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SantaMaria] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SantaMaria] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SantaMaria] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SantaMaria] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SantaMaria] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SantaMaria] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SantaMaria] SET  MULTI_USER 
GO
ALTER DATABASE [SantaMaria] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SantaMaria] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SantaMaria] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SantaMaria] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SantaMaria] SET DELAYED_DURABILITY = DISABLED 
GO
USE [SantaMaria]
GO
/****** Object:  Schema [Audit]    Script Date: 03/06/2017 12:26:43 p.m. ******/
CREATE SCHEMA [Audit]
GO
/****** Object:  Schema [Servicios]    Script Date: 03/06/2017 12:26:43 p.m. ******/
CREATE SCHEMA [Servicios]
GO
/****** Object:  Table [Audit].[ActivityLog]    Script Date: 03/06/2017 12:26:43 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Audit].[ActivityLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[Activity] [nvarchar](255) NOT NULL,
	[Result] [nvarchar](255) NULL,
	[IpAddress] [nvarchar](255) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ChangedOn] [datetime] NULL,
	[ChangedBy] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Audit].[DataLog]    Script Date: 03/06/2017 12:26:43 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Audit].[DataLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LogDate] [datetime] NULL,
	[What] [varchar](30) NOT NULL,
	[WhatId] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Column] [varchar](30) NOT NULL,
	[OldValue] [varchar](255) NULL,
	[NewValue] [varchar](255) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ChangedOn] [datetime] NULL,
	[ChangedBy] [uniqueidentifier] NULL,
	[UndoDate] [datetime] NULL,
	[UndoBy] [uniqueidentifier] NULL,
 CONSTRAINT [PK_DATALOG] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Audit].[ErrorLog]    Script Date: 03/06/2017 12:26:43 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Audit].[ErrorLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ErrorDate] [datetime] NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[Exception] [nvarchar](255) NULL,
	[IpAddress] [nvarchar](255) NULL,
	[CreatedOn] [nchar](10) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ChangedOn] [datetime] NULL,
	[ChangedBy] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Personas]    Script Date: 03/06/2017 12:26:43 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[ID] [uniqueidentifier] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[DNI] [int] NULL,
	[Direccion] [nvarchar](100) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[ChangedOn] [datetime] NULL,
	[ChangedBy] [uniqueidentifier] NULL,
	[DeletedOn] [datetime] NULL,
	[DeletedBy] [uniqueidentifier] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Servicios].[Familia]    Script Date: 03/06/2017 12:26:43 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Servicios].[Familia](
	[ID] [uniqueidentifier] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[ChangedOn] [datetime] NULL,
	[ChangedBy] [uniqueidentifier] NULL,
	[DeletedOn] [datetime] NULL,
	[DeletedBy] [uniqueidentifier] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Familia] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Servicios].[Familia_Familia]    Script Date: 03/06/2017 12:26:43 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Servicios].[Familia_Familia](
	[Id_FamiliaContenedora] [uniqueidentifier] NOT NULL,
	[Id_FamiliaContenida] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[ChangedOn] [datetime] NULL,
	[ChangedBy] [uniqueidentifier] NULL,
	[DeletedOn] [datetime] NULL,
	[DeletedBy] [uniqueidentifier] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Familia_Familia] PRIMARY KEY CLUSTERED 
(
	[Id_FamiliaContenedora] ASC,
	[Id_FamiliaContenida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Servicios].[Familia_Patente]    Script Date: 03/06/2017 12:26:43 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Servicios].[Familia_Patente](
	[Id_Familia] [uniqueidentifier] NOT NULL,
	[Id_Patente] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[ChangedOn] [datetime] NULL,
	[ChangedBy] [uniqueidentifier] NULL,
	[DeletedOn] [datetime] NULL,
	[DeletedBy] [uniqueidentifier] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Familia_Patente] PRIMARY KEY CLUSTERED 
(
	[Id_Patente] ASC,
	[Id_Familia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Servicios].[Patente]    Script Date: 03/06/2017 12:26:43 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Servicios].[Patente](
	[ID] [uniqueidentifier] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[ChangedOn] [datetime] NULL,
	[ChangedBy] [uniqueidentifier] NULL,
	[DeletedOn] [datetime] NULL,
	[DeletedBy] [uniqueidentifier] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Patente] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Servicios].[Usuario]    Script Date: 03/06/2017 12:26:43 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Servicios].[Usuario](
	[ID] [uniqueidentifier] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
	[Usuario] [nvarchar](50) NOT NULL,
	[Contraseña] [nvarchar](50) NOT NULL,
	[Dni] [int] NOT NULL,
	[Habilitado] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[ChangedOn] [datetime] NULL,
	[ChangedBy] [uniqueidentifier] NULL,
	[DeletedOn] [datetime] NULL,
	[DeletedBy] [uniqueidentifier] NULL,
	[Deleted] [bit] NOT NULL,
	[CheckSum] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Servicios].[Usuario_Familia]    Script Date: 03/06/2017 12:26:43 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Servicios].[Usuario_Familia](
	[Id_Usuario] [uniqueidentifier] NOT NULL,
	[Id_Familia] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[ChangedOn] [datetime] NULL,
	[ChangedBy] [uniqueidentifier] NULL,
	[DeletedOn] [datetime] NULL,
	[DeletedBy] [uniqueidentifier] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario_Familia] PRIMARY KEY CLUSTERED 
(
	[Id_Usuario] ASC,
	[Id_Familia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Servicios].[Usuario_Patente]    Script Date: 03/06/2017 12:26:43 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Servicios].[Usuario_Patente](
	[Id_Usuario] [uniqueidentifier] NOT NULL,
	[Id_Patente] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[ChangedOn] [datetime] NULL,
	[ChangedBy] [uniqueidentifier] NULL,
	[DeletedOn] [datetime] NULL,
	[DeletedBy] [uniqueidentifier] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario_Patente] PRIMARY KEY CLUSTERED 
(
	[Id_Usuario] ASC,
	[Id_Patente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [Servicios].[Familia_Familia]  WITH CHECK ADD  CONSTRAINT [FK_Familia_Familia_FamiliaContenedora] FOREIGN KEY([Id_FamiliaContenedora])
REFERENCES [Servicios].[Familia] ([ID])
GO
ALTER TABLE [Servicios].[Familia_Familia] CHECK CONSTRAINT [FK_Familia_Familia_FamiliaContenedora]
GO
ALTER TABLE [Servicios].[Familia_Familia]  WITH CHECK ADD  CONSTRAINT [FK_Familia_Familia_FamiliaContenida] FOREIGN KEY([Id_FamiliaContenida])
REFERENCES [Servicios].[Familia] ([ID])
GO
ALTER TABLE [Servicios].[Familia_Familia] CHECK CONSTRAINT [FK_Familia_Familia_FamiliaContenida]
GO
ALTER TABLE [Servicios].[Familia_Patente]  WITH CHECK ADD  CONSTRAINT [FK_Familia_Patente_Familia] FOREIGN KEY([Id_Familia])
REFERENCES [Servicios].[Familia] ([ID])
GO
ALTER TABLE [Servicios].[Familia_Patente] CHECK CONSTRAINT [FK_Familia_Patente_Familia]
GO
ALTER TABLE [Servicios].[Familia_Patente]  WITH CHECK ADD  CONSTRAINT [FK_Familia_Patente_Patente] FOREIGN KEY([Id_Patente])
REFERENCES [Servicios].[Patente] ([ID])
GO
ALTER TABLE [Servicios].[Familia_Patente] CHECK CONSTRAINT [FK_Familia_Patente_Patente]
GO
ALTER TABLE [Servicios].[Usuario_Familia]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Familia_Familia] FOREIGN KEY([Id_Familia])
REFERENCES [Servicios].[Familia] ([ID])
GO
ALTER TABLE [Servicios].[Usuario_Familia] CHECK CONSTRAINT [FK_Usuario_Familia_Familia]
GO
ALTER TABLE [Servicios].[Usuario_Familia]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Familia_Usuario] FOREIGN KEY([Id_Usuario])
REFERENCES [Servicios].[Usuario] ([ID])
GO
ALTER TABLE [Servicios].[Usuario_Familia] CHECK CONSTRAINT [FK_Usuario_Familia_Usuario]
GO
ALTER TABLE [Servicios].[Usuario_Patente]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Patente_Patente] FOREIGN KEY([Id_Usuario])
REFERENCES [Servicios].[Patente] ([ID])
GO
ALTER TABLE [Servicios].[Usuario_Patente] CHECK CONSTRAINT [FK_Usuario_Patente_Patente]
GO
ALTER TABLE [Servicios].[Usuario_Patente]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Patente_Usuario] FOREIGN KEY([Id_Usuario])
REFERENCES [Servicios].[Usuario] ([ID])
GO
ALTER TABLE [Servicios].[Usuario_Patente] CHECK CONSTRAINT [FK_Usuario_Patente_Usuario]
GO
/****** Object:  Trigger [dbo].[trg_PersonasUpdate]    Script Date: 03/06/2017 12:26:43 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[trg_PersonasUpdate]
       ON [dbo].[Personas]
AFTER UPDATE
AS
BEGIN
       DECLARE @ID uniqueidentifier
       DECLARE @NAME [varchar](100)
       DECLARE @WHO uniqueidentifier
       DECLARE @WHEN [datetime2]
       DECLARE @OLDVALUE [varchar](10)
       DECLARE @NEWVALUE [varchar](255)
	   DECLARE @CreatedBy uniqueidentifier
       DECLARE @CreatedOn [datetime2]

       SELECT @ID = INSERTED.ID
       FROM INSERTED
       
       SELECT @WHO = INSERTED.ChangedBy
       FROM INSERTED

       SELECT @WHEN = CAST(inserted.ChangedOn AS datetime2)
       FROM INSERTED

	   SELECT @CreatedBy = inserted.CreatedBy
       FROM INSERTED

       SELECT @CreatedOn = CAST(inserted.CreatedOn As Datetime2)
       FROM INSERTED

       SELECT @NAME = (deleted.Nombre) -- + ' ' + DELETED.APELLIDO)
       FROM DELETED

	   IF UPDATE(NOMBRE)
       BEGIN
               SELECT @OLDVALUE = DELETED.NOMBRE
               FROM DELETED
               
               SELECT @NEWVALUE = INSERTED.NOMBRE
               FROM INSERTED

               INSERT INTO Audit.DataLog
               VALUES(@WHEN, 'Personas', @ID, @NAME, 'Nombre', @OLDVALUE, @NEWVALUE, @CreatedOn	, @CreatedBy, GETDATE(), @WHO, NULL, NULL)
       END
       
       IF UPDATE(Direccion)
       BEGIN
               SELECT @OLDVALUE = DELETED.Direccion
               FROM DELETED
               
               SELECT @NEWVALUE = INSERTED.Direccion
               FROM INSERTED

               INSERT INTO Audit.DataLog
               VALUES(@WHEN, 'Personas', @ID, @NAME, 'Direccion', @OLDVALUE, @NEWVALUE, @CreatedOn	, @CreatedBy, GETDATE(), @WHO, NULL, NULL)
       END
      
	   IF UPDATE(DNI)
       BEGIN
               SELECT @OLDVALUE = DELETED.DNI
               FROM DELETED
               
               SELECT @NEWVALUE = INSERTED.DNI
               FROM INSERTED

               INSERT INTO Audit.DataLog
               VALUES(@WHEN, 'Personas', @ID, @NAME, 'DNI', @OLDVALUE, @NEWVALUE, @CreatedOn	, @CreatedBy, GETDATE(), @WHO, NULL, NULL)
       END
END

GO
/****** Object:  Trigger [Servicios].[trg_FamiliaUpdate]    Script Date: 03/06/2017 12:26:43 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [Servicios].[trg_FamiliaUpdate]
       ON [Servicios].[Familia]
AFTER UPDATE
AS
BEGIN
       DECLARE @ID uniqueidentifier
       DECLARE @NAME [varchar](100)
       DECLARE @WHO uniqueidentifier
       DECLARE @WHEN [datetime2]
       DECLARE @OLDVALUE [varchar](10)
       DECLARE @NEWVALUE [varchar](255)
	   DECLARE @CreatedBy uniqueidentifier
       DECLARE @CreatedOn [datetime2]

       SELECT @ID = INSERTED.ID
       FROM INSERTED
       
       SELECT @WHO = INSERTED.ChangedBy
       FROM INSERTED

       SELECT @WHEN = CAST(inserted.ChangedOn AS datetime2)
       FROM INSERTED

	   SELECT @CreatedBy = inserted.CreatedBy
       FROM INSERTED

       SELECT @CreatedOn = CAST(inserted.CreatedOn As Datetime2)
       FROM INSERTED

       SELECT @NAME = (deleted.Nombre) -- + ' ' + DELETED.APELLIDO)
       FROM DELETED

	   IF UPDATE(NOMBRE)
       BEGIN
               SELECT @OLDVALUE = DELETED.NOMBRE
               FROM DELETED
               
               SELECT @NEWVALUE = INSERTED.NOMBRE
               FROM INSERTED

               INSERT INTO Audit.DataLog
               VALUES(@WHEN, 'Familia', @ID, @NAME, 'Nombre', @OLDVALUE, @NEWVALUE, @CreatedOn	, @CreatedBy, GETDATE(), @WHO, NULL, NULL)
       END
       
       IF UPDATE(Descripcion)
       BEGIN
               SELECT @OLDVALUE = DELETED.Descripcion
               FROM DELETED
               
               SELECT @NEWVALUE = INSERTED.Descripcion
               FROM INSERTED

               INSERT INTO Audit.DataLog
               VALUES(@WHEN, 'Familia', @ID, @NAME, 'Descripcion', @OLDVALUE, @NEWVALUE, @CreatedOn	, @CreatedBy, GETDATE(), @WHO, NULL, NULL)
       END
END

GO
/****** Object:  Trigger [Servicios].[trg_PatenteUpdate]    Script Date: 03/06/2017 12:26:43 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [Servicios].[trg_PatenteUpdate]
       ON [Servicios].[Patente]
AFTER UPDATE
AS
BEGIN
       DECLARE @ID uniqueidentifier
       DECLARE @NAME [varchar](100)
       DECLARE @WHO uniqueidentifier
       DECLARE @WHEN [datetime2]
       DECLARE @OLDVALUE [varchar](10)
       DECLARE @NEWVALUE [varchar](255)
	   DECLARE @CreatedBy uniqueidentifier
       DECLARE @CreatedOn [datetime2]

       SELECT @ID = INSERTED.ID
       FROM INSERTED
       
       SELECT @WHO = INSERTED.ChangedBy
       FROM INSERTED

       SELECT @WHEN = CAST(inserted.ChangedOn AS datetime2)
       FROM INSERTED

	   SELECT @CreatedBy = inserted.CreatedBy
       FROM INSERTED

       SELECT @CreatedOn = CAST(inserted.CreatedOn As Datetime2)
       FROM INSERTED

       SELECT @NAME = (deleted.Nombre) -- + ' ' + DELETED.APELLIDO)
       FROM DELETED

	   IF UPDATE(NOMBRE)
       BEGIN
               SELECT @OLDVALUE = DELETED.NOMBRE
               FROM DELETED
               
               SELECT @NEWVALUE = INSERTED.NOMBRE
               FROM INSERTED

               INSERT INTO Audit.DataLog
               VALUES(@WHEN, 'Patente', @ID, @NAME, 'Nombre', @OLDVALUE, @NEWVALUE, @CreatedOn	, @CreatedBy, GETDATE(), @WHO, NULL, NULL)
       END
       
       IF UPDATE(Descripcion)
       BEGIN
               SELECT @OLDVALUE = DELETED.Descripcion
               FROM DELETED
               
               SELECT @NEWVALUE = INSERTED.Descripcion
               FROM INSERTED

               INSERT INTO Audit.DataLog
               VALUES(@WHEN, 'Patente', @ID, @NAME, 'Descripcion', @OLDVALUE, @NEWVALUE, @CreatedOn	, @CreatedBy, GETDATE(), @WHO, NULL, NULL)
       END
END

GO
/****** Object:  Trigger [Servicios].[trg_UsuarioUpdate]    Script Date: 03/06/2017 12:26:43 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [Servicios].[trg_UsuarioUpdate]
       ON [Servicios].[Usuario]
AFTER UPDATE
AS
BEGIN
       DECLARE @ID uniqueidentifier
       DECLARE @NAME [varchar](100)
       DECLARE @WHO uniqueidentifier
       DECLARE @WHEN [datetime2]
       DECLARE @OLDVALUE [varchar](10)
       DECLARE @NEWVALUE [varchar](255)
	   DECLARE @CreatedBy uniqueidentifier
       DECLARE @CreatedOn [datetime2]

       SELECT @ID = INSERTED.ID
       FROM INSERTED
       
       SELECT @WHO = INSERTED.ChangedBy
       FROM INSERTED

       SELECT @WHEN = CAST(inserted.ChangedOn AS datetime2)
       FROM INSERTED

	   SELECT @CreatedBy = inserted.CreatedBy
       FROM INSERTED

       SELECT @CreatedOn = CAST(inserted.CreatedOn As Datetime2)
       FROM INSERTED

       SELECT @NAME = (deleted.Nombre) -- + ' ' + DELETED.APELLIDO)
       FROM DELETED

	   IF UPDATE(NOMBRE)
       BEGIN
               SELECT @OLDVALUE = DELETED.NOMBRE
               FROM DELETED
               
               SELECT @NEWVALUE = INSERTED.NOMBRE
               FROM INSERTED

               INSERT INTO Audit.DataLog
               VALUES(@WHEN, 'Usuario', @ID, @NAME, 'Nombre', @OLDVALUE, @NEWVALUE, @CreatedOn	, @CreatedBy, GETDATE(), @WHO, NULL, NULL)
       END
       
       IF UPDATE(Descripcion)
       BEGIN
               SELECT @OLDVALUE = DELETED.Descripcion
               FROM DELETED
               
               SELECT @NEWVALUE = INSERTED.Descripcion
               FROM INSERTED

               INSERT INTO Audit.DataLog
               VALUES(@WHEN, 'Usuario', @ID, @NAME, 'Descripcion', @OLDVALUE, @NEWVALUE, @CreatedOn	, @CreatedBy, GETDATE(), @WHO, NULL, NULL)
       END
END

GO
USE [master]
GO
ALTER DATABASE [SantaMaria] SET  READ_WRITE 
GO
