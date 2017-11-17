package lucas.com.br.ankioab;

import android.content.Context;
import android.os.AsyncTask;
import feign.Feign;
import feign.gson.GsonEncoder;

/**
 * Created by aluno on 07/06/2017.
 */

public class AtualizarCartaTask extends AsyncTask<Carta, Void, Void> {

    Context context;
    String url = context.getString(R.string.url_api);

    @Override
    protected Void doInBackground(Carta... params) {
        try {
            // 1. usando a Feign para fazer uma chamada a uma api rest
            CartaRequest request = Feign.builder().
                    encoder(new GsonEncoder()).
                    target(CartaRequest.class, url);

            // 2. Fazendo a chamada e enviando o objeto convertido em JSON
            request.updateCarta(params[0].getCodCarta(), params[0]);
            return null;

        } catch (Exception e) {
            System.err.println("Erro ao tentar atualizar Carta!");
            e.printStackTrace();
            return null;
        }
    }
}
