package lucas.com.br.ankioab;

import java.util.List;

import feign.Param;
import feign.RequestLine;

/**
 * Created by aluno on 07/06/2017.
 */

public interface CartaRequest {

    @RequestLine("GET /api/Carta/Get?id={id}")
    List<Carta> getCarta(@Param("id") Integer id);

    @RequestLine("DELETE /posts/{id}/")
    void deleteCarta(@Param("id") Integer id);

    @RequestLine("POST /posts")
    void createCarta(Carta carta);

    @RequestLine("PUT /posts/{id}")
    void updateCarta(@Param("id") Integer id, Carta carta);
}
