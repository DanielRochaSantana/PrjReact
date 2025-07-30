import axios from 'axios';
import { useState } from 'react';

const AdicionarUsuario = () => {

    const url = "https://localhost:7227/Usuario"

    const [error, setError] = useState(null);

    const [isLoading, setIsLoading] = useState(false);

    const [usuario, definirUsuario] = useState({
        nome: "",
        email: "",
        celular: ""
    })

    const handelInput = (event) => {
        event.preventDefault();
        const { name, value } = event.target;
        console.log(name, value)
        definirUsuario({ ...usuario, [name]: value });
    }

    const handelSubmit = async (event) => {
        event.preventDefault();
        console.log(usuario)
        try {
            setIsLoading(true);

            axios.get(url)
                .then(response => {
                    console.log(response.data);
                })
                .catch(error => {
                    console.error('Erro ao obter os dados: ', error);
                });

            axios.post(url, usuario)
                .then(response => {
                    console.log('Usuário criado: ', response.data);
                    if (response.data.statusCode == 200) {
                        console.log('Operação efetuada com sucesso!');
                        definirUsuario({ nome: "", email: "", celular: "" })

                    } else {
                        console.error('Falha na operação!');
                    }
                })
                .catch(error => {
                    console.error('Erro ao criar usuário: ', error);
                });

        } catch (error) {
            setError(error.message);
        } finally {
            setIsLoading(false);
        }
    }

    return (
        <div className='user-form'>
            <div className='heading'>
                {isLoading}
                {error && <p>Erro: {error}</p>}
                <p>Adicionar/Editar Usu&aacute;rio</p>
            </div>
            <form onSubmit={handelSubmit}>
                <div className="row" style={{ justifyContent: "space-between" }}>
                    <div className="col-4">
                        &nbsp;
                    </div>
                    <div className="col-4">
                        <label htmlFor="nome" className="form-label">Nome</label>
                    </div>
                    <div className="col-4">
                        <input type="text" className="form-control" id="nome" name="nome" value={usuario.nome} onChange={handelInput} />
                    </div>
                    <div className="col-4">
                        &nbsp;
                    </div>
                </div>
                <div className="row" style={{ justifyContent: "space-between" }}>
                    <div className="col-4">
                        <label htmlFor="email" className="form-label">Email</label>
                    </div>
                    <div className="col-4">
                        <input type="email" className="form-control" id="email" name="email" value={usuario.email} onChange={handelInput} />
                    </div>
                    <div className="col-4">
                        &nbsp;
                    </div>
                </div>
                <div className="row" style={{ justifyContent: "space-between" }}>
                    <div className="col-4">
                        <label htmlFor="celular" className="form-label">Celular</label>
                    </div>
                    <div className="col-4">
                        <input type="text" className="form-control" id="celular" name="celular" value={usuario.celular} onChange={handelInput} />
                    </div>
                    <div className="col-4">
                        &nbsp;
                    </div>
                </div>
                <div className="row">
                    <button type="submit" className="btn btn-primary submit-btn">Salvar</button>
                </div>
            </form>
        </div>
    )
}

export default AdicionarUsuario