USE [BDJSL]
GO

/****** Object:  Table [dbo].[Veiculo]    Script Date: 01/07/2021 08:44:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Veiculo](
	[placa] [varchar](10) NOT NULL,
	[modelo] [varchar](50) NULL,
	[marca] [varchar](50) NULL,
	[eixos] [int] NULL,
	[id_motorista] [int] NOT NULL,
 CONSTRAINT [PK_Veiculo] PRIMARY KEY CLUSTERED 
(
	[placa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Veiculo]  WITH CHECK ADD  CONSTRAINT [FK_Veiculo_Motorista] FOREIGN KEY([id_motorista])
REFERENCES [dbo].[Motorista] ([id_motorista])
GO

ALTER TABLE [dbo].[Veiculo] CHECK CONSTRAINT [FK_Veiculo_Motorista]
GO

