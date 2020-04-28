namespace Noticias.Web.Repositories
{
    public static class AutoresSQL
    {
        public static string GetAutores => @"
            SELECT 
                A.ID_Autor,
                A.Nombre_Autor,
                A.Apellido_Autor,
                A.Estatus_Autor
            FROM AUTORES AS A
            WHERE A.Estatus_Autor = 1
        ";

        public static string CreateAutor => @"
        INSERT INTO AUTORES(Nombre_Autor, Apellido_Autor, Estatus_Autor)
        VALUES (@Nombre_Autor, @Apellido_Autor, 1);
        ";

        public static string GetAutor => @"SELECT 
                A.ID_Autor,
                A.Nombre_Autor,
                A.Apellido_Autor,
                A.Estatus_Autor
            FROM AUTORES AS A
            WHERE A.ID_Autor=@ID_Autor";

        public static string UpdateAutor => @"
        UPDATE AUTORES
            SET Nombre_Autor = @Nombre_Autor,
            Apellido_Autor = @Apellido_Autor
        WHERE ID_Autor = @ID_Autor;
        ";

        public static string DeleteAutor => @"
        UPDATE AUTORES
        SET Estatus_Autor = 0
        WHERE ID_Autor = @ID_Autor;
";
    }
}