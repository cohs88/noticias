namespace Noticias.Web.Repositories
{
    public static class NoticiasSQL
    {
        public static string GetNoticias => @"
            SELECT 
                A.ID_Autor,
                A.Nombre_Autor, 
                A.Apellido_Autor,
                N.ID_Noticia,
                N.Titulo_Noticia,
                N.Descripcion_Noticia,
                N.Contenido_Noticia,
                N.Fecha_Noticia 
            FROM NOTICIAS N 
                LEFT JOIN AUTORES A
                ON A.ID_Autor = N.ID_Autor
                    AND A.Estatus_Autor = 1
            WHERE
                N.Estatus_Noticia = 1
            ORDER BY N.ID_Noticia DESC;
        ";

        public static string CreateNoticia => @"
        INSERT INTO NOTICIAS(ID_Autor, Titulo_Noticia, Descripcion_Noticia, Contenido_Noticia, Fecha_Noticia, Estatus_Noticia)
        VALUES (@ID_Autor, @Titulo_Noticia, @Descripcion_Noticia, @Contenido_Noticia, @Fecha_Noticia,1);
        ";

        public static string GetNoticia => @"
            SELECT 
                A.ID_Autor,
                A.Nombre_Autor, 
                A.Apellido_Autor,
                N.ID_Noticia,
                N.Titulo_Noticia,
                N.Descripcion_Noticia,
                N.Contenido_Noticia,
                N.Fecha_Noticia 
            FROM NOTICIAS N 
                LEFT JOIN AUTORES A 
                ON A.ID_Autor = N.ID_Autor 
                AND N.Estatus_Noticia = 1
                AND A.Estatus_Autor = 1
            WHERE N.ID_Noticia=@ID_Noticia
            ;
        ";

        public static string UpdateNoticia => @"
        UPDATE NOTICIAS
        SET 
            ID_Autor = @ID_Autor,
            Titulo_Noticia = @Titulo_Noticia,
            Descripcion_Noticia = @Descripcion_Noticia,
            Contenido_Noticia =  @Contenido_Noticia,
            Fecha_Noticia = @Fecha_Noticia
        WHERE ID_Noticia = @ID_Noticia;
        ";

        public static string DeleteNoticia => @"
        UPDATE NOTICIAS
        SET Estatus_Noticia=0
        WHERE ID_Noticia = @ID_Noticia;
";
    }
}