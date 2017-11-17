package lucas.com.br.ankioab;

import android.content.Context;
import android.os.AsyncTask;

import feign.Feign;
import feign.gson.GsonEncoder;

/**
 * Created by aluno on 07/06/2017.
 */

public class AtualizarBaralhoTask extends AsyncTask<Baralho, Void, Void> {

    Context context;
    String url = context.getString(R.string.url_api);

    @Override
    protected Void doInBackground(Baralho... params) {
        try {
            // 1. usando a Feign para fazer uma chamada a uma api rest
            BaralhoRequest request = Feign.builder().
                    encoder(new GsonEncoder()).
                    target(BaralhoRequest.class, url);

            // 2. Fazendo a chamada e enviando o objeto convertido em JSON
            request.updateBaralho(params[0].getCodBaralho(), params[0]);
            return null;

        } catch (Exception e) {
            System.err.println("Erro ao tentar atualizar Baralho!");
            e.printStackTrace();
            return null;
        }
    }

}
