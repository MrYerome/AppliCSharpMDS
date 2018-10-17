/*------------------------------------------------------------
*        Script SQLSERVER 
------------------------------------------------------------*/


/*------------------------------------------------------------
-- Table: Club
------------------------------------------------------------*/

CREATE TABLE Club(
	id           INT IDENTITY (1,1) NOT NULL ,
	nom          VARCHAR (100)  ,
	adresse      VARCHAR (50)  ,
	codePostal   INT   ,
	ville        VARCHAR (50)   ,
	CONSTRAINT Club_PK PRIMARY KEY (id)
);

/*------------------------------------------------------------
-- Table: Statut
------------------------------------------------------------*/
CREATE TABLE Statut(
	id		INT IDENTITY (1,1) NOT NULL,
	label	VARCHAR (100),
	CONSTRAINT Statut_PK PRIMARY KEY (id)
);


/*------------------------------------------------------------
-- Table: User
------------------------------------------------------------*/
CREATE TABLE Users(
	id            INT IDENTITY (1,1) NOT NULL ,
	nom           VARCHAR (50)  ,
	prenom        VARCHAR (50)  ,
	id_Statut     INT	NOT NULL ,
	email         VARCHAR (100)  ,
	identifiant   VARCHAR (100) NOT NULL ,
	password      VARCHAR (100) NOT NULL ,
	id_Club       INT  NOT NULL  ,
	CONSTRAINT User_PK PRIMARY KEY (id)

	,CONSTRAINT Users_Club_FK FOREIGN KEY (id_Club) REFERENCES Club(id)
	,CONSTRAINT Users_Statut_FK FOREIGN KEY (id_Statut) REFERENCES Statut(id)
);



/*------------------------------------------------------------
-- Table: Terrain
------------------------------------------------------------*/
CREATE TABLE Terrain(
	id        INT IDENTITY (1,1) NOT NULL ,
	adresse   VARCHAR (80)  ,
	id_Club   INT  NOT NULL  ,
	CONSTRAINT Terrain_PK PRIMARY KEY (id)

	,CONSTRAINT Terrain_Club_FK FOREIGN KEY (id_Club) REFERENCES Club(id)
);


/*------------------------------------------------------------
-- Table: Entrainement
------------------------------------------------------------*/
CREATE TABLE Entrainement(
	id     INT IDENTITY (1,1) NOT NULL ,
	type   VARCHAR (40)  ,
	date   DATETIME NOT NULL  ,
	CONSTRAINT Entrainement_PK PRIMARY KEY (id)
);


/*------------------------------------------------------------
-- Table: Match
------------------------------------------------------------*/
CREATE TABLE Matchs(
	id     INT IDENTITY (1,1) NOT NULL ,
	date   DATETIME   ,
	CONSTRAINT Matchs_PK PRIMARY KEY (id)
);


/*------------------------------------------------------------
-- Table: Produit
------------------------------------------------------------*/
CREATE TABLE Produit(
	id        INT IDENTITY (1,1) NOT NULL ,
	nom       VARCHAR (40)  ,
	prix      FLOAT   ,
	id_Club   INT  NOT NULL  ,
	CONSTRAINT Produit_PK PRIMARY KEY (id)

	,CONSTRAINT Produit_Club_FK FOREIGN KEY (id_Club) REFERENCES Club(id)
);


/*------------------------------------------------------------
-- Table: relation2
------------------------------------------------------------*/
CREATE TABLE MatchsClubTerrain(
	id           INT  NOT NULL ,
	id_Matchs     INT  NOT NULL ,
	id_Terrain   INT  NOT NULL  ,
	id_Club		INT	NOT NULL,
	CONSTRAINT MatchsClubTerrain_PK PRIMARY KEY (id)

	,CONSTRAINT MatchsClubTerrain_Club_FK FOREIGN KEY (id_Club) REFERENCES Club(id)
	,CONSTRAINT MatchsClubTerrain_Match0_FK FOREIGN KEY (id_Matchs) REFERENCES Matchs(id)
	,CONSTRAINT MatchsClubTerrain_Terrain1_FK FOREIGN KEY (id_Terrain) REFERENCES Terrain(id)
);


/*------------------------------------------------------------
-- Table: relation6
------------------------------------------------------------*/
CREATE TABLE EntrainementClubTerrain(
	id                INT  NOT NULL ,
	id_Entrainement   INT  NOT NULL ,
	id_Terrain        INT  NOT NULL ,
	id_Club			  INT	NOT NULL,
	CONSTRAINT relation6_PK PRIMARY KEY (id)

	,CONSTRAINT EntrainementClubTerrain_Club_FK FOREIGN KEY (id_Club) REFERENCES Club(id)
	,CONSTRAINT EntrainementClubTerrain_Entrainement_FK FOREIGN KEY (id_Entrainement) REFERENCES Entrainement(id)
	,CONSTRAINT EntrainementClubTerrain_Terrain1_FK FOREIGN KEY (id_Terrain) REFERENCES Terrain(id)
);



