USE [BDJSL]
GO

/****** Object:  Table [dbo].[Viagem]    Script Date: 01/07/2021 08:45:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Viagem](
	[id_viagem] [int] IDENTITY(1,1) NOT NULL,
	[dataHora] [datetime] NOT NULL,
	[localEntrega] [int] NOT NULL,
	[localSaida] [int] NOT NULL,
	[distancia] [int] NOT NULL,
	[pesoCarga] [int] NULL,
	[id_motorista] [int] NULL,
 CONSTRAINT [PK_Viagem] PRIMARY KEY CLUSTERED 
(
	[id_viagem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Viagem] ADD  CONSTRAINT [DF_Viagem_dataHora]  DEFAULT (getdate()) FOR [dataHora]
GO

ALTER TABLE [dbo].[Viagem]  WITH CHECK ADD  CONSTRAINT [FK_Viagem_Endereco] FOREIGN KEY([localEntrega])
REFERENCES [dbo].[Endereco] ([id_end])
GO

ALTER TABLE [dbo].[Viagem] CHECK CONSTRAINT [FK_Viagem_Endereco]
GO

ALTER TABLE [dbo].[Viagem]  WITH CHECK ADD  CONSTRAINT [FK_Viagem_Endereco1] FOREIGN KEY([localSaida])
REFERENCES [dbo].[Endereco] ([id_end])
GO

ALTER TABLE [dbo].[Viagem] CHECK CONSTRAINT [FK_Viagem_Endereco1]
GO

ALTER TABLE [dbo].[Viagem]  WITH CHECK ADD  CONSTRAINT [FK_Viagem_Motorista] FOREIGN KEY([id_motorista])
REFERENCES [dbo].[Motorista] ([id_motorista])
GO

ALTER TABLE [dbo].[Viagem] CHECK CONSTRAINT [FK_Viagem_Motorista]
GO

