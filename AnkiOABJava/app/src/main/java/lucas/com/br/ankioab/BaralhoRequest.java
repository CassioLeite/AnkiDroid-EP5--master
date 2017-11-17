package lucas.com.br.ankioab;

import java.util.List;

import feign.Param;
import feign.RequestLine;

/**
 * Created by aluno on 07/06/2017.
 */

public interface BaralhoRequest {

    @RequestLine("GET /api/Baralho/Get?id={id}")
    Baralho getBaralho(@Param("id") Integer id);

    @RequestLine("GET /api/Baralho/GetAll")
    List<Baralho> getAllBaralho();

    @RequestLine("DELETE /posts/{id}/")
    void deleteBaralho(@Param("id") Integer id);

    @RequestLine("POST /api/Baralho/")
    void createBaralho(Baralho baralho);

    @RequestLine("PUT /posts/{id}")
    void updateBaralho(@Param("id") Integer id, Baralho baralho);
}
