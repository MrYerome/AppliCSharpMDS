#------------------------------------------------------------
#        Script MySQL.
#------------------------------------------------------------


#------------------------------------------------------------
# Table: Club
#------------------------------------------------------------

CREATE TABLE Club(
        id         Int  Auto_increment  NOT NULL ,
        nom        Varchar (100) ,
        adresse    Varchar (50) ,
        codePostal Int ,
        ville      Varchar (50)
	,CONSTRAINT Club_PK PRIMARY KEY (id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Terrain
#------------------------------------------------------------

CREATE TABLE Terrain(
        id      Int  Auto_increment  NOT NULL ,
        adresse Varchar (80) ,
        id_Club Int NOT NULL
	,CONSTRAINT Terrain_PK PRIMARY KEY (id)

	,CONSTRAINT Terrain_Club_FK FOREIGN KEY (id_Club) REFERENCES Club(id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Entrainement
#------------------------------------------------------------

CREATE TABLE Entrainement(
        id   Int  Auto_increment  NOT NULL ,
        type Varchar (40) ,
        date Date NOT NULL
	,CONSTRAINT Entrainement_PK PRIMARY KEY (id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Match
#------------------------------------------------------------

CREATE TABLE Matchs(
        id   Int  Auto_increment  NOT NULL ,
        date Date
	,CONSTRAINT Match_PK PRIMARY KEY (id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Produit
#------------------------------------------------------------

CREATE TABLE Produit(
        id      Int  Auto_increment  NOT NULL ,
        nom     Varchar (40) ,
        prix    Float ,
        id_Club Int NOT NULL
	,CONSTRAINT Produit_PK PRIMARY KEY (id)

	,CONSTRAINT Produit_Club_FK FOREIGN KEY (id_Club) REFERENCES Club(id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: STATUT
#------------------------------------------------------------

CREATE TABLE STATUT(
        id    Int  Auto_increment  NOT NULL ,
        label Varchar (50)
	,CONSTRAINT STATUT_PK PRIMARY KEY (id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: User
#------------------------------------------------------------

CREATE TABLE User(
        id          Int  Auto_increment  NOT NULL ,
        nom         Varchar (50) ,
        prenom      Varchar (50) ,
        statut      Varchar (50) ,
        email       Varchar (100) ,
        identifiant Varchar (100) NOT NULL ,
        password    Varchar (100) NOT NULL ,
        id_Club     Int NOT NULL ,
        id_STATUT   Int NOT NULL
	,CONSTRAINT User_PK PRIMARY KEY (id)

	,CONSTRAINT User_Club_FK FOREIGN KEY (id_Club) REFERENCES Club(id)
	,CONSTRAINT User_STATUT0_FK FOREIGN KEY (id_STATUT) REFERENCES STATUT(id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: relation2
#------------------------------------------------------------

CREATE TABLE MatchClubTerrain(
        id           Int Auto_increment  NOT NULL ,
        id_Matchs     Int NOT NULL ,
        id_Terrain   Int NOT NULL ,
        id_Club Int NOT NULL
	,CONSTRAINT MatchClubTerrain_PK PRIMARY KEY (id)

	,CONSTRAINT MatchClubTerrain_Club_FK FOREIGN KEY (id_Club) REFERENCES Club(id)
	,CONSTRAINT MatchClubTerrain_Matchs_FK FOREIGN KEY (id_Matchs) REFERENCES Matchs(id)
	,CONSTRAINT MatchClubTerrain_Terrain_FK FOREIGN KEY (id_Terrain) REFERENCES Terrain(id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: relation6
#------------------------------------------------------------

CREATE TABLE EntrainementClubTerrain(
        id              Int Auto_increment  NOT NULL ,
        id_Entrainement Int NOT NULL ,
        id_Terrain      Int NOT NULL ,
        id_Club			Int NOT NULL 
	,CONSTRAINT EntrainementClubTerrain_PK PRIMARY KEY (id)

	,CONSTRAINT EntrainementClubTerrain_Club_FK FOREIGN KEY (id_Club) REFERENCES Club(id)
	,CONSTRAINT EntrainementClubTerrain_Entrainement_FK FOREIGN KEY (id_Entrainement) REFERENCES Entrainement(id)
	,CONSTRAINT EntrainementClubTerrain_Terrain_FK FOREIGN KEY (id_Terrain) REFERENCES Terrain(id)
)ENGINE=InnoDB;