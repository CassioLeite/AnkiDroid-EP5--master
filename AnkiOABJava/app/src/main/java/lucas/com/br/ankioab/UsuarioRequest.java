package lucas.com.br.ankioab;

import feign.Param;
import feign.RequestLine;

/**
 * Created by aluno on 07/06/2017.
 */

public interface UsuarioRequest {

    @RequestLine("GET /api/Usuario/Get")
    Usuario getUsuario(String id);

    @RequestLine("DELETE /api/Usuario/Delete")
    void deleteUsuario(Integer id);

    @RequestLine("POST /api/Usuario/Post")
    void createUsuario(Usuario usuario);

    @RequestLine("PUT /api/Usuario/Put")
    void updateUsuario(Integer id, Usuario usuario);

}
