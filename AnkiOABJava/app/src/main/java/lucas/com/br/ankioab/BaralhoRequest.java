package lucas.com.br.ankioab;

import java.util.List;

import feign.Param;
import feign.RequestLine;

/**
 * Created by aluno on 07/06/2017.
 */

public interface BaralhoRequest {

    @RequestLine("POST /api/Baralho/Get")
    Baralho getBaralho(Integer id);

    @RequestLine("GET /api/Baralho/GetAll")
    List<Baralho> getAllBaralho();

    @RequestLine("POST /api/Baralho/Delete")
    void deleteBaralho(Integer id);

    @RequestLine("POST /api/Baralho/Post")
    void createBaralho(Baralho baralho);

    @RequestLine("POST /api/Baralho/Put")
    void updateBaralho(Integer codBaralho, Baralho baralho);
}
