select * from medilink.user;
select * from medilink.patient;
select * from medilink.professional;
select * from medilink.professionalSpecialty;
select * from medilink.professionalWorkSchedules;
select * from medilink.schedule;
select * from medilink.specialty;
select * from medilink.unit;
select * from medilink.examSpecialty;

-- Campo Id de todas as tableas é gerado automaticamente
-- Não tem insert de Users pois precisa de Hash de para senhas (que o .Net do MVC gera)
-- Professional e Patient dependem de Users, por isso também não tem inserts

-- Unidades para realizar agendamentos
INSERT INTO medilink.unit (name,description,createdAt,updatedAt,active) VALUES ('Unidade Lapa Tito','R. Tito, 54 - Vila Romana, São Paulo - SP, 05051-000','2024-05-26 22:46:50','2024-05-26 22:46:50',1);
INSERT INTO medilink.unit (name,description,createdAt,updatedAt,active) VALUES ('Unidade Pirituba','R. ABC, 123, São Paulo - SP, 05900-000','2024-05-27 20:00:00','2024-05-27 20:00:00',1);
INSERT INTO medilink.unit (name,description,createdAt,updatedAt,active) VALUES ('Unidade Barra Funda','R. ABC, 123, São Paulo - SP, 05900-000','2024-05-27 20:00:00','2024-05-27 20:00:00',1);
INSERT INTO medilink.unit (name,description,createdAt,updatedAt,active) VALUES ('Unidade Santana','R. ABC, 123, São Paulo - SP, 05900-000','2024-05-27 20:00:00','2024-05-27 20:00:00',1);
INSERT INTO medilink.unit (name,description,createdAt,updatedAt,active) VALUES ('Unidade Casa Verde','R. ABC, 123, São Paulo - SP, 05900-000','2024-05-27 20:00:00','2024-05-27 20:00:00',1);

-- Especialidades do tipo profissionais
INSERT INTO medilink.specialty (name,description,createdAt,updatedAt,active,type) VALUES ('Consulta geral','Consulta geral','2024-05-27 20:00:00','2024-05-27 20:00:00',1,1);
INSERT INTO medilink.specialty (name,description,createdAt,updatedAt,active,type) VALUES ('Psicologia','Psicologia','2024-05-27 20:00:00','2024-05-27 20:00:00',1,1);
INSERT INTO medilink.specialty (name,description,createdAt,updatedAt,active,type) VALUES ('Oftalmologia','Oftalmologia','2024-05-27 20:00:00','2024-05-27 20:00:00',1,1);
INSERT INTO medilink.specialty (name,description,createdAt,updatedAt,active,type) VALUES ('Cardiologia','Cardiologia','2024-05-27 20:00:00','2024-05-27 20:00:00',1,1);

-- Especialidades do tipo exame
INSERT INTO medilink.specialty (name,description,createdAt,updatedAt,active,type) VALUES ('Checkup Geral','Checkup Geral','2024-06-01 15:00:00','2024-06-01 15:00:00',1,2);
INSERT INTO medilink.specialty (name,description,createdAt,updatedAt,active,type) VALUES ('Exame Sangue','Exame Sangue','2024-06-01 15:00:00','2024-06-01 15:00:00',1,2);
INSERT INTO medilink.specialty (name,description,createdAt,updatedAt,active,type) VALUES ('Exame de vista','Exame de vista','2024-06-01 15:00:00','2024-06-01 15:00:00',1,2);
INSERT INTO medilink.specialty (name,description,createdAt,updatedAt,active,type) VALUES ('Hemograma','Hemograma','2024-06-01 15:00:00','2024-06-01 15:00:00',1,2);
INSERT INTO medilink.specialty (name,description,createdAt,updatedAt,active,type) VALUES ('Glicemia de Jejum','Glicemia de Jejum','2024-06-01 15:00:00','2024-06-01 15:00:00',1,2);
INSERT INTO medilink.specialty (name,description,createdAt,updatedAt,active,type) VALUES ('Cardiovascular','Cardiovascular','2024-06-01 15:00:00','2024-06-01 15:00:00',1,2);

INSERT INTO medilink.professionalSpecialty (SpecialtyId,ProfessionalId,UnitId,createdAt,updatedAt,active) VALUES (2,2,2,'2024-05-27 20:00:00','2024-05-27 20:00:00',1);
INSERT INTO medilink.professionalSpecialty (SpecialtyId,ProfessionalId,UnitId,createdAt,updatedAt,active) VALUES (1,3,2,'2024-05-27 20:00:00','2024-05-27 20:00:00',1);
INSERT INTO medilink.professionalSpecialty (SpecialtyId,ProfessionalId,UnitId,createdAt,updatedAt,active) VALUES (3,4,2,'2024-05-27 20:00:00','2024-05-27 20:00:00',1);
INSERT INTO medilink.professionalSpecialty (SpecialtyId,ProfessionalId,UnitId,createdAt,updatedAt,active) VALUES (4,5,2,'2024-05-27 20:00:00','2024-05-27 20:00:00',1);
INSERT INTO medilink.professionalSpecialty (SpecialtyId,ProfessionalId,UnitId,createdAt,updatedAt,active) VALUES (3,6,2,'2024-05-27 20:00:00','2024-05-27 20:00:00',1);
INSERT INTO medilink.professionalSpecialty (SpecialtyId,ProfessionalId,UnitId,createdAt,updatedAt,active) VALUES (2,7,2,'2024-05-27 20:00:00','2024-05-27 20:00:00',1);
INSERT INTO medilink.professionalSpecialty (SpecialtyId,ProfessionalId,UnitId,createdAt,updatedAt,active) VALUES (1,8,2,'2024-05-27 20:00:00','2024-05-27 20:00:00',1);

-- Horários de trabalho (dia por dia)
INSERT INTO medilink.professionalWorkSchedules (ProfessionalId,UnitId,ProfessionalSpecialtyId,DayOfWeek,StartTime,EndTime) VALUES (2,2,2,2,'13:00:00', '15:00:00');
INSERT INTO medilink.professionalWorkSchedules (ProfessionalId,UnitId,ProfessionalSpecialtyId,DayOfWeek,StartTime,EndTime) VALUES (2,2,2,3,'13:00:00', '15:00:00');
INSERT INTO medilink.professionalWorkSchedules (ProfessionalId,UnitId,ProfessionalSpecialtyId,DayOfWeek,StartTime,EndTime) VALUES (2,2,2,4,'13:00:00', '15:00:00');
INSERT INTO medilink.professionalWorkSchedules (ProfessionalId,UnitId,ProfessionalSpecialtyId,DayOfWeek,StartTime,EndTime) VALUES (3,1,3,2,'13:00:00', '15:00:00');
INSERT INTO medilink.professionalWorkSchedules (ProfessionalId,UnitId,ProfessionalSpecialtyId,DayOfWeek,StartTime,EndTime) VALUES (3,1,3,3,'13:00:00', '15:00:00');
INSERT INTO medilink.professionalWorkSchedules (ProfessionalId,UnitId,ProfessionalSpecialtyId,DayOfWeek,StartTime,EndTime) VALUES (3,1,3,4,'13:00:00', '15:00:00');
INSERT INTO medilink.professionalWorkSchedules (ProfessionalId,UnitId,ProfessionalSpecialtyId,DayOfWeek,StartTime,EndTime) VALUES (4,3,4,2,'13:00:00', '15:00:00');
INSERT INTO medilink.professionalWorkSchedules (ProfessionalId,UnitId,ProfessionalSpecialtyId,DayOfWeek,StartTime,EndTime) VALUES (4,3,4,3,'13:00:00', '15:00:00');
INSERT INTO medilink.professionalWorkSchedules (ProfessionalId,UnitId,ProfessionalSpecialtyId,DayOfWeek,StartTime,EndTime) VALUES (4,3,4,4,'13:00:00', '15:00:00');
INSERT INTO medilink.professionalWorkSchedules (ProfessionalId,UnitId,ProfessionalSpecialtyId,DayOfWeek,StartTime,EndTime) VALUES (5,4,5,2,'13:00:00', '15:00:00');
INSERT INTO medilink.professionalWorkSchedules (ProfessionalId,UnitId,ProfessionalSpecialtyId,DayOfWeek,StartTime,EndTime) VALUES (5,4,5,3,'13:00:00', '15:00:00');
INSERT INTO medilink.professionalWorkSchedules (ProfessionalId,UnitId,ProfessionalSpecialtyId,DayOfWeek,StartTime,EndTime) VALUES (5,4,5,4,'13:00:00', '15:00:00');
INSERT INTO medilink.professionalWorkSchedules (ProfessionalId,UnitId,ProfessionalSpecialtyId,DayOfWeek,StartTime,EndTime) VALUES (6,3,6,2,'13:00:00', '15:00:00');
INSERT INTO medilink.professionalWorkSchedules (ProfessionalId,UnitId,ProfessionalSpecialtyId,DayOfWeek,StartTime,EndTime) VALUES (6,3,6,3,'13:00:00', '15:00:00');
INSERT INTO medilink.professionalWorkSchedules (ProfessionalId,UnitId,ProfessionalSpecialtyId,DayOfWeek,StartTime,EndTime) VALUES (6,3,6,4,'13:00:00', '15:00:00');
INSERT INTO medilink.professionalWorkSchedules (ProfessionalId,UnitId,ProfessionalSpecialtyId,DayOfWeek,StartTime,EndTime) VALUES (7,2,7,2,'13:00:00', '15:00:00');
INSERT INTO medilink.professionalWorkSchedules (ProfessionalId,UnitId,ProfessionalSpecialtyId,DayOfWeek,StartTime,EndTime) VALUES (7,2,7,3,'13:00:00', '15:00:00');
INSERT INTO medilink.professionalWorkSchedules (ProfessionalId,UnitId,ProfessionalSpecialtyId,DayOfWeek,StartTime,EndTime) VALUES (7,2,7,4,'13:00:00', '15:00:00');
INSERT INTO medilink.professionalWorkSchedules (ProfessionalId,UnitId,ProfessionalSpecialtyId,DayOfWeek,StartTime,EndTime) VALUES (8,1,8,2,'13:00:00', '15:00:00');
INSERT INTO medilink.professionalWorkSchedules (ProfessionalId,UnitId,ProfessionalSpecialtyId,DayOfWeek,StartTime,EndTime) VALUES (8,1,8,3,'13:00:00', '15:00:00');
INSERT INTO medilink.professionalWorkSchedules (ProfessionalId,UnitId,ProfessionalSpecialtyId,DayOfWeek,StartTime,EndTime) VALUES (8,1,8,4,'13:00:00', '15:00:00');

-- Especialidades para fazer exames
INSERT INTO medilink.examSpecialty (unitId,specialtyId,createdAt,updatedAt,active) VALUES (1,5,'2024-06-02 14:00:00', '2024-06-02 14:00:00',1);
INSERT INTO medilink.examSpecialty (unitId,specialtyId,createdAt,updatedAt,active) VALUES (1,6,'2024-06-02 14:00:00', '2024-06-02 14:00:00',1);
INSERT INTO medilink.examSpecialty (unitId,specialtyId,createdAt,updatedAt,active) VALUES (1,8,'2024-06-02 14:00:00', '2024-06-02 14:00:00',1);
INSERT INTO medilink.examSpecialty (unitId,specialtyId,createdAt,updatedAt,active) VALUES (2,6,'2024-06-02 14:00:00', '2024-06-02 14:00:00',1);
INSERT INTO medilink.examSpecialty (unitId,specialtyId,createdAt,updatedAt,active) VALUES (2,8,'2024-06-02 14:00:00', '2024-06-02 14:00:00',1);
INSERT INTO medilink.examSpecialty (unitId,specialtyId,createdAt,updatedAt,active) VALUES (2,10,'2024-06-02 14:00:00', '2024-06-02 14:00:00',1);
INSERT INTO medilink.examSpecialty (unitId,specialtyId,createdAt,updatedAt,active) VALUES (3,5,'2024-06-02 14:00:00', '2024-06-02 14:00:00',1);
INSERT INTO medilink.examSpecialty (unitId,specialtyId,createdAt,updatedAt,active) VALUES (3,6,'2024-06-02 14:00:00', '2024-06-02 14:00:00',1);
INSERT INTO medilink.examSpecialty (unitId,specialtyId,createdAt,updatedAt,active) VALUES (3,7,'2024-06-02 14:00:00', '2024-06-02 14:00:00',1);
INSERT INTO medilink.examSpecialty (unitId,specialtyId,createdAt,updatedAt,active) VALUES (3,8,'2024-06-02 14:00:00', '2024-06-02 14:00:00',1);
INSERT INTO medilink.examSpecialty (unitId,specialtyId,createdAt,updatedAt,active) VALUES (3,9,'2024-06-02 14:00:00', '2024-06-02 14:00:00',1);
INSERT INTO medilink.examSpecialty (unitId,specialtyId,createdAt,updatedAt,active) VALUES (3,10,'2024-06-02 14:00:00', '2024-06-02 14:00:00',1);
INSERT INTO medilink.examSpecialty (unitId,specialtyId,createdAt,updatedAt,active) VALUES (4,8,'2024-06-02 14:00:00', '2024-06-02 14:00:00',1);
INSERT INTO medilink.examSpecialty (unitId,specialtyId,createdAt,updatedAt,active) VALUES (4,9,'2024-06-02 14:00:00', '2024-06-02 14:00:00',1);
INSERT INTO medilink.examSpecialty (unitId,specialtyId,createdAt,updatedAt,active) VALUES (4,10,'2024-06-02 14:00:00', '2024-06-02 14:00:00',1);
INSERT INTO medilink.examSpecialty (unitId,specialtyId,createdAt,updatedAt,active) VALUES (5,8,'2024-06-02 14:00:00', '2024-06-02 14:00:00',1);
INSERT INTO medilink.examSpecialty (unitId,specialtyId,createdAt,updatedAt,active) VALUES (5,9,'2024-06-02 14:00:00', '2024-06-02 14:00:00',1);
INSERT INTO medilink.examSpecialty (unitId,specialtyId,createdAt,updatedAt,active) VALUES (5,10,'2024-06-02 14:00:00', '2024-06-02 14:00:00',1);