package lucas.com.br.ankioab;

import android.content.Context;
import android.os.AsyncTask;

import java.util.List;

import feign.Feign;
import feign.gson.GsonDecoder;

/**
 * Created by aluno on 07/06/2017.
 */

public class LerCartaTask extends AsyncTask<Integer, Void, List> {

    Context context;
    String url = context.getString(R.string.url_api);

    @Override
    protected List<Carta> doInBackground(Integer... params) {
        try {
            // 1. usando a Feign para fazer uma chamada a uma api rest
            CartaRequest request = Feign.builder().
                    decoder(new GsonDecoder()).
                    target(CartaRequest.class, url);

            // 2. Fazendo a chamada e recuperando o objeto convertido
            List<Carta> cartas = request.getCarta(params[0]);
            return cartas;


        } catch (Exception e) {
            System.err.println("Erro na chamada à API "+e.getMessage());
            e.printStackTrace();
            return null;
        }

    }
}
