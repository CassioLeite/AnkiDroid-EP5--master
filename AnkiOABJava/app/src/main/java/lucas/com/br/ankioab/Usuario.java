package lucas.com.br.ankioab;

/**
 * Created by aluno on 07/06/2017.
 */

public class Usuario {

    private Integer CodUsuario ;
    private String NomeUsuario ;
    private String Email ;
    private String Senha ;

    public Integer getCodUsuario() {return CodUsuario;}

    public void setCodUsuario(Integer codUsuario) {this.CodUsuario = codUsuario;}

    public String getNomeUsuario() {return NomeUsuario;}

    public void setNomeUsuario(String nomeUsuario) {this.NomeUsuario = nomeUsuario;}

    public String getEmail() {return Email;}

    public void setEmail(String email) {this.Email = email;}

    public String getSenha() {return Senha;}

    public void setSenha(String senha) {this.Senha = senha;}

}
