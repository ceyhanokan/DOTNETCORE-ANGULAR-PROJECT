-- ----------------------------
-- Table structure for Authorizations
-- ----------------------------
DROP TABLE IF EXISTS "public"."Authorizations";
CREATE TABLE "public"."Authorizations" (
  "AuthID" SERIAL NOT NULL,
  "Name" varchar(50) COLLATE "pg_catalog"."default",
  "Title" varchar(75) COLLATE "pg_catalog"."default",
  "Description" varchar(100) COLLATE "pg_catalog"."default",
  "Code" int4,
  "Type" int4
)
;

-- ----------------------------
-- Records of Authorizations
-- ----------------------------

-- ----------------------------
-- Table structure for Citys
-- ----------------------------
DROP TABLE IF EXISTS "public"."Citys";
CREATE TABLE "public"."Citys" (
  "CityID" SERIAL NOT NULL,
  "CityName" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "CityCode" int4
)
;

-- ----------------------------
-- Records of Citys
-- ----------------------------

-- ----------------------------
-- Table structure for Districts
-- ----------------------------
DROP TABLE IF EXISTS "public"."Districts";
CREATE TABLE "public"."Districts" (
  "DistrictID" SERIAL NOT NULL,
  "CityID" int4 NOT NULL,
  "DistrictName" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "DistrictCode" varchar(10) COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Records of Districts
-- ----------------------------

-- ----------------------------
-- Table structure for Immovables
-- ----------------------------
DROP TABLE IF EXISTS "public"."Immovables";
CREATE TABLE "public"."Immovables" (
  "ImmovableID" SERIAL NOT NULL,
  "TypeID" int4 NOT NULL,
  "TypeName" int4 NOT NULL,
  "CityID" int4 NOT NULL,
  "DistrictID" int4 NOT NULL,
  "NeighbourhoodID" int4 NOT NULL,
  "Adress" varchar(150) COLLATE "pg_catalog"."default",
  "Block" int4 NOT NULL,
  "Plot" int4 NOT NULL,
  "Title" varchar(100) COLLATE "pg_catalog"."default",
  "Description" varchar(255) COLLATE "pg_catalog"."default",
  "CreatedDate" date,
  "UpdatedDate" date,
  "CreatedUser" int4 NOT NULL,
  "UpdatedUser" int4,
  "Status" int4
)
;

-- ----------------------------
-- Records of Immovables
-- ----------------------------

-- ----------------------------
-- Table structure for Logs
-- ----------------------------
DROP TABLE IF EXISTS "public"."Logs";
CREATE TABLE "public"."Logs" (
  "LogID" SERIAL NOT NULL,
  "CreatedDate" date,
  "LogType" int4,
  "Title" varchar(50) COLLATE "pg_catalog"."default",
  "Description" varchar(100) COLLATE "pg_catalog"."default",
  "ActionUserID" int4,
  "TargetUserID" int4,
  "TargetImmovableID" int4
)
;

-- ----------------------------
-- Records of Logs
-- ----------------------------

-- ----------------------------
-- Table structure for Neighbourhoods
-- ----------------------------
DROP TABLE IF EXISTS "public"."Neighbourhoods";
CREATE TABLE "public"."Neighbourhoods" (
  "NeightbourhoodID" SERIAL NOT NULL,
  "DistrictID" int4 NOT NULL,
  "Name" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "Code" varchar(10) COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Records of Neighbourhoods
-- ----------------------------

-- ----------------------------
-- Table structure for Roles
-- ----------------------------
DROP TABLE IF EXISTS "public"."Roles";
CREATE TABLE "public"."Roles" (
  "RoleID" SERIAL NOT NULL,
  "RoleName" varchar(50) COLLATE "pg_catalog"."default",
  "RoleTitle" varchar(100) COLLATE "pg_catalog"."default",
  "Authorizations" varchar(50) COLLATE "pg_catalog"."default",
  "Status" int2
)
;

-- ----------------------------
-- Records of Roles
-- ----------------------------
INSERT INTO "public"."Roles" VALUES (1, 'ADMIN', 'ADMİN', '[1,2,3,4,5,6,7,8,9]', 1);
INSERT INTO "public"."Roles" VALUES (2, 'TEST', 'TEST ROLÜ', '[1,2]', 1);

-- ----------------------------
-- Table structure for Types
-- ----------------------------
DROP TABLE IF EXISTS "public"."Types";
CREATE TABLE "public"."Types" (
  "TypeID" SERIAL NOT NULL,
  "TypeName" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "TypeTitle" varchar(100) COLLATE "pg_catalog"."default",
  "TypeCode" varchar(10) COLLATE "pg_catalog"."default",
  "TypeCode2" varchar(10) COLLATE "pg_catalog"."default",
  "TypeCode3" varchar(10) COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Records of Types
-- ----------------------------

-- ----------------------------
-- Table structure for Users
-- ----------------------------
DROP TABLE IF EXISTS "public"."Users";
CREATE TABLE "public"."Users" (
  "UserID" SERIAL NOT NULL,
  "FullName" varchar(50) COLLATE "pg_catalog"."default",
  "IdentityNumber" varchar(11) COLLATE "pg_catalog"."default",
  "UserName" varchar(30) COLLATE "pg_catalog"."default",
  "Email" varchar(50) COLLATE "pg_catalog"."default",
  "Password" varchar(100) COLLATE "pg_catalog"."default",
  "UserRole" int4,
  "IsAdmin" int4,
  "Status" int4
)
;

-- ----------------------------
-- Records of Users
-- ----------------------------
INSERT INTO "public"."Users" VALUES (2, 'admin', 'admin@test.com', '9UfnUN1nhXO7Pl1VNoxnOw==', 1, 1, 1);
INSERT INTO "public"."Users" VALUES (1, 'CEYHAN', 'ceyhan@gmail.com', 'zolX9MkdfC8yD09nz0HJIQ==', 1, 1, 1);

-- ----------------------------
-- Indexes structure for table Authorizations
-- ----------------------------
CREATE UNIQUE INDEX "IX_AUTHORIZATIONS" ON "public"."Authorizations" USING btree (
  "AuthID" "pg_catalog"."int4_ops" DESC NULLS FIRST,
  "Name" COLLATE "pg_catalog"."default" "pg_catalog"."text_ops" ASC NULLS LAST,
  "Code" "pg_catalog"."int4_ops" ASC NULLS LAST
);
CREATE INDEX "fki_FK_Authorization_Type_from_Types_TypeID" ON "public"."Authorizations" USING btree (
  "Type" "pg_catalog"."int4_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table Authorizations
-- ----------------------------
ALTER TABLE "public"."Authorizations" ADD CONSTRAINT "Authorizations_pkey" PRIMARY KEY ("AuthID");

-- ----------------------------
-- Primary Key structure for table Citys
-- ----------------------------
ALTER TABLE "public"."Citys" ADD CONSTRAINT "Citys_pkey" PRIMARY KEY ("CityID");

-- ----------------------------
-- Indexes structure for table Districts
-- ----------------------------
CREATE INDEX "fki_FK_CityID_from_Citys_CityID" ON "public"."Districts" USING btree (
  "CityID" "pg_catalog"."int4_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table Districts
-- ----------------------------
ALTER TABLE "public"."Districts" ADD CONSTRAINT "Districts_pkey" PRIMARY KEY ("DistrictID");

-- ----------------------------
-- Indexes structure for table Immovables
-- ----------------------------
CREATE INDEX "fki_FK_Immovables_CityID_from_Citys_CityID" ON "public"."Immovables" USING btree (
  "CityID" "pg_catalog"."int4_ops" ASC NULLS LAST
);
CREATE INDEX "fki_FK_Immovables_DistrictID_from_Districts_DistrictID" ON "public"."Immovables" USING btree (
  "DistrictID" "pg_catalog"."int4_ops" ASC NULLS LAST
);
CREATE INDEX "fki_FK_Immovables_NeighbourhoodID_from_Neighbourhoods_Neighbour" ON "public"."Immovables" USING btree (
  "NeighbourhoodID" "pg_catalog"."int4_ops" ASC NULLS LAST
);
CREATE INDEX "fki_FK_Immovables_Type_from_Types_TypeID" ON "public"."Immovables" USING btree (
  "TypeID" "pg_catalog"."int4_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table Immovables
-- ----------------------------
ALTER TABLE "public"."Immovables" ADD CONSTRAINT "Immovables_pkey" PRIMARY KEY ("ImmovableID");

-- ----------------------------
-- Primary Key structure for table Logs
-- ----------------------------
ALTER TABLE "public"."Logs" ADD CONSTRAINT "Logs_pkey" PRIMARY KEY ("LogID");

-- ----------------------------
-- Primary Key structure for table Neighbourhoods
-- ----------------------------
ALTER TABLE "public"."Neighbourhoods" ADD CONSTRAINT "Neighbourhood_pkey" PRIMARY KEY ("NeightbourhoodID");

-- ----------------------------
-- Primary Key structure for table Roles
-- ----------------------------
ALTER TABLE "public"."Roles" ADD CONSTRAINT "Roles_pkey" PRIMARY KEY ("RoleID");

-- ----------------------------
-- Primary Key structure for table Types
-- ----------------------------
ALTER TABLE "public"."Types" ADD CONSTRAINT "Types_pkey" PRIMARY KEY ("TypeID");

-- ----------------------------
-- Indexes structure for table Users
-- ----------------------------
CREATE UNIQUE INDEX "IX_USERS" ON "public"."Users" USING btree (
  "UserName" COLLATE "pg_catalog"."default" "pg_catalog"."text_ops" ASC NULLS LAST,
  "Email" COLLATE "pg_catalog"."default" "pg_catalog"."text_ops" ASC NULLS LAST,
  "UserID" "pg_catalog"."int4_ops" DESC NULLS FIRST
);
CREATE INDEX "fki_FK_ROLE_FROM_ROLES_ROLE_ID" ON "public"."Users" USING btree (
  "UserRole" "pg_catalog"."int4_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table Users
-- ----------------------------
ALTER TABLE "public"."Users" ADD CONSTRAINT "Users_pkey" PRIMARY KEY ("UserID");

-- ----------------------------
-- Foreign Keys structure for table Authorizations
-- ----------------------------
ALTER TABLE "public"."Authorizations" ADD CONSTRAINT "FK_Authorization_Type_from_Types_TypeID" FOREIGN KEY ("Type") REFERENCES "public"."Types" ("TypeID") ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMENT ON CONSTRAINT "FK_Authorization_Type_from_Types_TypeID" ON "public"."Authorizations" IS 'Authorizations Tablosundaki Type sütunu için Types Tablosundaki TypeID sütünunun eşleşmesi';

-- ----------------------------
-- Foreign Keys structure for table Districts
-- ----------------------------
ALTER TABLE "public"."Districts" ADD CONSTRAINT "FK_CityID_from_Citys_CityID" FOREIGN KEY ("CityID") REFERENCES "public"."Citys" ("CityID") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table Immovables
-- ----------------------------
ALTER TABLE "public"."Immovables" ADD CONSTRAINT "FK_CREATED_USER" FOREIGN KEY ("CreatedUser") REFERENCES "public"."Users" ("UserID") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."Immovables" ADD CONSTRAINT "FK_Immovables_CityID_from_Citys_CityID" FOREIGN KEY ("CityID") REFERENCES "public"."Citys" ("CityID") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."Immovables" ADD CONSTRAINT "FK_Immovables_DistrictID_from_Districts_DistrictID" FOREIGN KEY ("DistrictID") REFERENCES "public"."Districts" ("DistrictID") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."Immovables" ADD CONSTRAINT "FK_Immovables_NeighbourhoodID_from_Neighbourhoods_Neighbourhood" FOREIGN KEY ("NeighbourhoodID") REFERENCES "public"."Neighbourhoods" ("NeightbourhoodID") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."Immovables" ADD CONSTRAINT "FK_Immovables_Type_from_Types_TypeID" FOREIGN KEY ("TypeID") REFERENCES "public"."Types" ("TypeID") ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMENT ON CONSTRAINT "FK_Immovables_Type_from_Types_TypeID" ON "public"."Immovables" IS 'Immovables Taşınmazlar tablosu TypeID sütunu ile Types Tablosu TypeID sütünu eşleşmesi';

-- ----------------------------
-- Foreign Keys structure for table Logs
-- ----------------------------
ALTER TABLE "public"."Logs" ADD CONSTRAINT "FK_LOG_ACTION_USERID_FROM_USERS" FOREIGN KEY ("ActionUserID") REFERENCES "public"."Users" ("UserID") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."Logs" ADD CONSTRAINT "FK_LOG_TARGET_USERID_FROM_USERS" FOREIGN KEY ("TargetUserID") REFERENCES "public"."Users" ("UserID") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."Logs" ADD CONSTRAINT "FK_LOG_TYPE" FOREIGN KEY ("LogType") REFERENCES "public"."Types" ("TypeID") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."Logs" ADD CONSTRAINT "FK_TargetImmovableID" FOREIGN KEY ("TargetImmovableID") REFERENCES "public"."Immovables" ("ImmovableID") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table Neighbourhoods
-- ----------------------------
ALTER TABLE "public"."Neighbourhoods" ADD CONSTRAINT "FK_DistrictID_from_Districts_DistrictID" FOREIGN KEY ("NeightbourhoodID") REFERENCES "public"."Districts" ("DistrictID") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table Users
-- ----------------------------
ALTER TABLE "public"."Users" ADD CONSTRAINT "FK_ROLE_FROM_ROLES_ROLE_ID" FOREIGN KEY ("UserRole") REFERENCES "public"."Roles" ("RoleID") ON DELETE NO ACTION ON UPDATE NO ACTION;
