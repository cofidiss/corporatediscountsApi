

[kurumsal.indirm.mockup.docx](https://github.com/cofidiss/corporatediscountsApi/files/9692354/kurumsal.indirm.mockup.docx)


Öğrenilmiş bilgiler
Postgre
------------------------------------------------------------------------------------------------------------------------------------------------------------
column_name data_type GENERATED { ALWAYS | BY DEFAULT } AS IDENTITY[ ( sequence_option ) ]
ALWAYS dersen o column_name e insert updatede hata alırsın.sen veremezsin. kendi sequndan yeni değeri verir. BY DEFAULT  da ise sen vermezsen sıradan değer verir 
verirsende alır
 rank_id INT GENERATED BY DEFAULT AS IDENTITY 
    (START WITH 10 INCREMENT BY 10)
 
 ---------------------------------------------------------------------------------------------------------------------------------------------------------------------
    A foreign key  defaullta nul
is a column or a group of columns in a table that reference the unique(null olabilir birden çok ta olabilir.) columns of another table.foreign keyli column  defaullta null olabilir. refenced tabledaki columnda null olmasa bile
    foriegn key olan child primary olan parent tablo olsun. şu kısıtlamaları koyar
    1-childaın fk cloumına sadece parenttaki primaryden olan şeyler insert update edilebilir
    2-no actionda parenttdan pkyı silmek ya da update ederken eğer o pk chlildın fk columnda var ise işlem yaptırmaz. parentıdaki bu pkyı değişitrince 
    childali fk colınını sil (CASCADE) nulla set et (SET NULL)  ya da default değerine set et ( SET DEFAULT) gibi şeyler denilebilir o zaman parenttadaki bu pk değişebilir ya da silinebilir ama yinede garanti değil mesela set null dedik ama child column not null varsa parent değiştirilemez yine
    [CONSTRAINT fk_name]
   FOREIGN KEY(fk_columns) 
   REFERENCES parent_table(parent_key_columns)
   [ON DELETE delete_action(SET DEFAULT,CASCADE,SET NULL, RESTRICT,NO ACTION )]
   [ON UPDATE update_action(SET DEFAULT,CASCADE,SET NULL ,RESTRICT,NO ACTION )]
   default no actiondır RESTRICT de aynı işi yapar ama O ACTION allows the check to be deferred until later in the transaction, whereas RESTRICT does not.) restrict daha iyi gibi . these do not excuse you from observing any constraints.i.e set default dedik deafult değer de 1 olsun referenced table/parent table daki columnda 1 yoksa yine hata alırsın
   --------------------------------------------------------------------------------------------------------------------------------------------------------------
    primary key
 A primary key constraint indicates that a column, or group of columns, can be used as a unique identifier for rows in the table. This requires that the values be both unique and not nul
    
  
