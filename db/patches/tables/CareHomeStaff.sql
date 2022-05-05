USE [VoyageCare]
GO

/****** Object:  Table [dbo].[CareHomeStaff]    Script Date: 04/05/2022 16:43:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CareHomeStaff](
	[CareHomeStaffID] [int] IDENTITY(1,1) NOT NULL,
	[CareHomeID] [int] NOT NULL,
	[Forename] [varchar](255) NOT NULL,
	[Surname] [varchar](255) NOT NULL,
	[DOB] [date] NOT NULL,
	[JobTitle] [varchar](255) NOT NULL,
	[AnnualSalary] [int] NOT NULL,
 CONSTRAINT [PK_CareHomeStaff] PRIMARY KEY CLUSTERED 
(
	[CareHomeStaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CareHomeStaff]  WITH CHECK ADD  CONSTRAINT [FK_CareHomeStaff_CareHome] FOREIGN KEY([CareHomeID])
REFERENCES [dbo].[CareHome] ([CareHomeID])
GO

ALTER TABLE [dbo].[CareHomeStaff] CHECK CONSTRAINT [FK_CareHomeStaff_CareHome]
GO


