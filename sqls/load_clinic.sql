 INSERT INTO dentalrj.Clinic (Id, Status, CreatedAt, CreatedBy, Name, TradeName, Phone, PostalCode, Address, AdditionalAddress, CityName, StateCode, CompanyId) values
(UUID(), 1, now(), 'Loader', 'JACAREPAGUÁ', '021 DENTAL JACAREPAGUÁ', '2122638900','22740220', 'Rua Lopo Saraiva', '', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'BANGU', '021 DENTAL BANGU', '2122638960','21810032', 'Rua Silva Cardoso 152', '515 [próximo a Casas Bahia]', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'BONSUCESSO', '021 DENTAL BONSUCESSO', '2122638960','21032000', 'Rua Cardoso de Morais 145', '601 [ao lado da CeA]', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'CENTRO I (CARIOCA)', '021 DENTAL CENTRO I (CARIOCA)', '21965300259','20040003', 'Rua Uruguaiana 10', '1706 [ Ed. Largo da Carioca - Prédio do IBEU ]', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'CAXIAS', '021 DENTAL CAXIAS', '2122638960','25070350', 'Rua Conde de Porto Alegre 477', '908 / 910 [próximo ao hospital Daniel Lipp]', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'NOVA IGUACU', '021 DENTAL NOVA IGUACU', '2122638960','26255060', 'Rua Getúlio Vargas 121', '416 e 417 [próximo a Rua dos cartórios]', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'CAMPO GRANDE', '021 DENTAL CAMPO GRANDE', '2122638960','23050340', 'Rua Augusto de Vasconcelos 544', '340/341 [ao lado do Agadir Hotel]', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'CINELANDIA', '021 DENTAL CINELANDIA', '2122638960','20040009', 'Avenida Rio Branco 277', '1806', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'COPACABANA', '021 DENTAL COPACABANA', '21994924106','22041012', 'Rua Santa Clara 50', '910 [Esquina com Nossa Sra de Copacabana]', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'MADUREIRA', '021 DENTAL MADUREIRA', '21994924106','21351080', 'Rua Soares Caldeira 142', '807 [ao lado do Madureira Shopping]', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'NORTE SHOPPING', '021 DENTAL NORTE SHOPPING', '2122638960','22251090', 'Av Dom Hélder câmara 5555', 'Salas 712 e 713 [em frente ao Norte Shopping - prédio da Memorial Saude]', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'PRESIDENTE VARGAS', '021 DENTAL PRESIDENTE VARGAS', '2122638960','20071000', 'Avenida Presidente Vargas 590', '1007', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'TIJUCA', '021 DENTAL TIJUCA', '21967794631','20550012', 'Rua São Francisco Xavier 168', 'Térreo [ próximo ao Colégio Pedro II ]', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'ESCRITORIO', '021 DENTAL HOLDING', '2122638960','20071907', 'Avenida Presidente Vargas', '446', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'NITEROI', '021 DENTAL PLAZA NITEROI', '21969449896','24020125', 'Rua Quinze de Novembro 4', 'Sala 708 (Bloco 1) [em cima do Plaza Shopping]', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'CARIOCA SHOPPING', '021 DENTAL CARIOCA SHOPPING', '21976372259','21210000', 'Av. Vicente de Carvalho, 909', 'bloco 1 sala 1220 ( Carioca Shopping )', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'TAQUARA', '021 DENTAL TAQUARA', '21979870127','22730522', 'Rua André Rocha 750', 'SALA 303 E 304 [em frente a UPA]', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'SÃO CRISTÓVÃO', '021 DENTAL SÃO CRISTÓVÃO', '','22941120', 'Rua Francisco Eugênio, 268', 'Sala 936 [edifício Alfa Corporate]', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'MÉIER', '021 DENTAL MÉIER', '00000','20720010', 'Rua Dias da Cruz 155', 'sala 308  [Edifício Mesbla]', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'ILHA DO GOVERNADOR', '021 DENTAL ILHA DO GOVERNADOR', '','21931387', 'Estrada do Galeão, 2701', 'Sala 209 [Prédio do Wizard]', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'SÃO GONÇALO (AO LADO DA PREFEITURA)', '021 DENTAL SÃO GONÇALO', '000000000','20031202', 'Rua Feliciano Sodré, 78', 'sala 1904', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'ALCÂNTARA (em frente ao banco Itaú da Raul Veiga)', '021 DENTAL ALCÂNTARA', '0000000000','20031202', 'Estrada Raul Veiga, 351', '904 [Prédio da Smart Fit]', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'SÃO JOÃO DE MERITI', '021 DENTAL SÃO JOÃO DE MERITI', '22638960','25520570', 'Rua Gessyr Gonçalves Fontes 115', 'Salas 804 e 805 [Próximo a drogaria Galante]', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'BELFORD ROXO', '021 DENTAL BELFORD ROXO', '21975464325','26130000', 'Avenida Benjamim Pinto Dias 1130', 'Sala 105 [Shopping Nova Belford]', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'BARRA II (ABELARDO BUENO)', '021 DENTAL BARRA II (ABELARDO BUENO)', '21983804756','22775028', 'Avenida Almirante Júlio de Sá Bierrenbach 200', 'BLOCO 1A / SALA 235 [em frente a estação do BRT centro metropolitano]', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'FLAMENGO', '021 DENTAL FLAMENGO', '','22230060', 'Rua Marquês de Abrantes 27', 'Sala 302', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'BARRA I (BARRA SQUARE)', '021 DENTAL BARRA I (BARRA SQUARE)', '21991701741','22631003', 'Avenida das Américas 3665', 'Loja 207 ( Fica no Barra Square Expansão, entrada pela lateral do shopping Ba', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'SP CENTRO | SÃO BENTO', '021 SP CENTRO | SÃO BENTO', '','21931387', 'Rua São Bento 545', ' conjunto 13 – sala 3 [próximo a Estação de Metro São Bento]', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'SP VILA OLIMPIA', '021 SP VILA OLIMPIA', '','21931387', 'Rua do Rocio 423', 'sala 1714 [atrás do Shopping Vila Olímpia]', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'SP AV PAULISTA | CONSOLAÇÃO', '021 SP AV PAULISTA | CONSOLAÇÃO', '11951626958','21931387', 'Av Paulista 2444', 'conjunto 54 [próximo a Estação de Metro Consolação]', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'BOTAFOGO', 'IN RIO - Em parceria com 021 DENTAL', '21976316551','22270018', 'Rua Voluntários da Pátria, 45 [próximo ao cinema NET RIO]', '703', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'CENTRO II (PRESIDENTE VARGAS)', '021 DENTAL CENTRO II (PRESIDENTE VARGAS)', '000000000','20071907', 'Avenida Presidente Vargas', '446 SEGUNDO ANDAR', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'SANTA CRUZ', '021 DENTAL SANTA CRUZ', '00000','23515020', 'Rua Lópes de Moura 78', '[Próximo a Estação Santa Cruz]', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'VILA ISABEL', '021 DENTAL VILA ISABEL', '00000000000','20551031', 'Boulevard Vinte e Oito de Setembro 389', 'Sala 213 ( Próximo ao Shopping Iguatemi', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'FREGUESIA', '021 DENTAL FREGUESIA', '','22755002', 'Estrada dos Três Rios 200', 'Bloco 1, Sala 201 [Ao lado da Passarela de Jacarepaguá]', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'RECREIO SHOPPING', '021 DENTAL RECREIO SHOPPING', '00000','22790701', 'Avenida Das Américas,19019.', 'Sala 350 (Recreio Shopping).', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'NILÓPOLIS', '021 DENTAL NILÓPOLIS', '','26525052', 'Rua Pedro Álvares Cabral 256', '403 [próximo a prefeitura de Nilópolis]', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'SHOPPING CONJUNTO NACIONAL BRASÍLIA', '021 DENTAL SHOPPING CONJUNTO NACIONAL BRASÍLIA', '','70077900', 'Setor de Diversão Norte', '6041 [Edifício Torre Azul do Shopping]', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'SP SÃO VICENTE | BAIXADA SANTISTA', '021 DENTAL SÃO VICENTE | BAIXADA SANTISTA', '','11310401', 'Rua Quinze de Novembro', '312', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'SP SANTO AMARO', '021 DENTAL SANTO AMARO', '','04753000', 'Rua Barão do Rio Branco', '264', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'SP SÃO BERNARDO DO CAMPO', '021 DENTAL SÃO BERNARDO DO CAMPO', '0000000000000','09750420', 'Rua Mediterrâneo 290', '15', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'CUIABÁ', '021 DENTAL CUIABÁ', '','78005290', 'Rua Joaquim Murtinho', '46', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'SP FARIA LIMA', '021 FARIA LIMA', '','01452000', 'StarsClinics - Avenida Brigadeiro Faria Lima', 'Salas(s): 2383, Loja 2', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'MARACANA / CIU', '021 MARACANA / CIU', '','20270004', 'Rua Mariz e Barros', '300', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'MANHUAÇU (ODONTO VIP)', '021 DENTAL MANHUAÇU (ODONTO VIP)', '','36900085', 'Rua Luiz Cerqueira', ' n 312, Centro', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'IPANEMA', '021 DENTAL IPANEMA', '1','22410000', 'Rua Farme de Amoedo, nº 66', 'Salas 201 (Dentotal)', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'Amil Dental - Rio Sul', 'Rio Sul', '','22290160', 'Rua Lauro Muller', '116 sala 2005', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'LARGO DO MACHADO (RIZI DENTAL)', '021 DENTAL LARGO DO MACHADO', '','22220050', 'Rua Governador Irineu Borhausen, 105', 'Lojas T1, U1 e V1', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental')),
(UUID(), 1, now(), 'Loader', 'BARRA III (RIO2) - RIZI DENTAL', '021 DENTAL RIO 2', '','22775054', 'Rua Bruno Giorgi, 114', 'Grupo 229', 'Rio de Janeiro', 'RJ', (select Id from Company where Name = 'RJ Dental'));