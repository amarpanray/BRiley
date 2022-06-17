USE [BRiley]
GO

/****** Object: Table [dbo].[Account] Script Date: 6/17/2022 5:19:58 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Account] (
    [AccountID] INT          IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (50) NULL,
    [Balance]   MONEY        NULL,

	 PRIMARY KEY ([AccountID]) 
);


