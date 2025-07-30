import { useState } from 'react'
import axios from 'axios'

const CreateUser = () => {

    const createUserApi = "https://localhost:7227/WeatherForecast"

    const [error, setError] = useState(null);

    const [isLoading, setIsLoading] = useState(false);

    const [user, setUser] = useState({
        name: "",
        email: "",
        phone: ""
    })

    const handelInput = (event) => {
        event.preventDefault();
        const { name, value } = event.target;
        console.log(name, value)
        setUser({ ...user, [name]: value });
    }

    const handelSubmit = async (event) => {
        event.preventDefault();
        console.log(user)
        try {
            setIsLoading(true);

            axios.get(createUserApi)
                .then(response => {
                    console.log(response.data);
                })
                .catch(error => {
                    console.error('Error fetching data: ', error);
                });

            axios.post(createUserApi, user)
                .then(response => {
                    console.log('Product created successfully: ', response.data);
                    if (response.ok) {
                        console.log('Form submitted successfully!');
                        setUser({ name: "", email: "", phone: "" })

                    } else {
                        console.error('Form submission failed!');
                    }
                })
                .catch(error => {
                    console.error('Error creating product: ', error);
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
                        <label htmlFor="name" className="form-label">Nome</label>
                    </div>
                    <div className="col-4">
                        <input type="text" className="form-control" id="name" name="name" value={user.name} onChange={handelInput} />
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
                        <input type="email" className="form-control" id="email" name="email" value={user.email} onChange={handelInput} />
                    </div>
                    <div className="col-4">
                        &nbsp;
                    </div>
                </div>
                <div className="row" style={{ justifyContent: "space-between" }}>
                    <div className="col-4">
                        <label htmlFor="pwd" className="form-label">Celular</label>
                    </div>
                    <div className="col-4">
                        <input type="text" className="form-control" id="phone" name="phone" value={user.phone} onChange={handelInput} />
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

export default CreateUser