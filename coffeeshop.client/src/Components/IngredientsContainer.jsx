import { useEffect, useState } from 'react'

export default function IngredientsContainer({ coffeeId, coffee, createOrder }) {
    const [selectedIngredientsId, setSelectedIngredientsId] = useState([]);
    const [ingredients, setIngredients] = useState([]);
    const [street, setStreet] = useState([]);

    useEffect(() => {
        async function getIngredient() {
            fetch(`https://localhost:7001/api/ingredient/${coffeeId}`, {
                method: "GET"
            })
                .then(responce => responce.json())
                .then(json => setIngredients(json));
        }
        getIngredient()
    }, [])

    function manageOrder(){
        const order = {
            coffeeId: coffeeId,
            ingredientsId: selectedIngredientsId,
            street: street
        }
        createOrder( order);
    }
    return (

        <div>
            <div className='card mx-2 col-4 my-2' key={coffee.id}>
                <img className="card-img-top py-2" src={coffee.imageUrl} alt="alt"></img>
                <div className='card-body'>
                    <h4 className='card-title'>{coffee.name}</h4>
                    <p className='card-subtitle'>{coffee.cost}</p>
                </div>
                <div>
                </div>
            </div>
            <div className="container">
                <div className="row">
                    {ingredients.map(ing =>
                        <div key={ing.id} className="col-sm-6">
                            <div className="form-check form-check-inline">
                                <input className="form-check-input" type="checkbox" id={ing.id} value={ing.id} onChange={(e) => {
                                    if (e.target.checked) {
                                        setSelectedIngredientsId([...selectedIngredientsId, ing.id]);
                                        console.log(selectedIngredientsId);
                                    } else {
                                        setSelectedIngredientsId(selectedIngredientsId.filter((id) => id !== ing.id));
                                    }
                                }} />
                                <label className="form-check-label" htmlFor={ing.id}>
                                    <span>
                                        {ing.name}
                                    </span>
                                </label>
                            </div>
                        </div>
                    )}
                </div>
                <div className='my-3'>
                    
                    <input className='form-input mx-4' placeholder='Street' onChange={(e)=> setStreet(e.target.value)}/>
                    <button onClick={()=>manageOrder()} className='btn btn-success'>Create Order</button>
                </div>
            </div>
        </div>
    )
}
