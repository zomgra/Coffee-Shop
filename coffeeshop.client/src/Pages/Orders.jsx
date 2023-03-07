import React, { useEffect, useState } from 'react'
import { GET_ORDERS_BY_USER_URL } from '../utils/Constants';
import { userManager } from '../utils/authService';
import OrderInfo from '../Components/OrderInfo';
import '../utils/style.css'

export default function Orders({ setOrder }) {

    const [orders, setOrders] = useState([]);
    const [selectedOrder, setSelectedOrder] = useState(null);

    useEffect(() => {
        async function getOrders() {

            let user = await userManager.getUser();
            let token = user.access_token;
            fetch(`${GET_ORDERS_BY_USER_URL}`, {
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${token}`
                }
            }).then(responce => responce.json())
                .then(json => {
                    setOrders(json);
                    console.log(json);
                })
                .catch(e => console.error(e));
        }
        getOrders();
    }, [])

    function getStatusStyle(status) {
        if (status === 0) return 'open-status';
        else if (status === 1) return 'cancel-status';
        else return 'payed-status';
    }

    return (
        <div className='container'>
            {selectedOrder === null ? (
                <div className="row">
                    {orders.map(order =>
                        <div key={order.id} className="card mx-2 col-sm-6 my-3 mx-4">
                            <img className="card-img-top py-2" src={order.coffee.imageUrl} alt="alt"></img>
                            <div className='card-body'>
                                <h4 className='card-title'>{order.coffee.name}</h4>

                                <h5 className={getStatusStyle(order.status)}>STATUS</h5>

                                <p className='card-subtitle'>${order.costOrder}</p>
                            </div>
                            <div className='card-footer'>
                                {order.ingredients.map(ing =>
                                    <div key={ing.id}>
                                        <p>{ing.name}</p>
                                    </div>)}
                                {order.status ===0 && (
                                    <button onClick={() => setSelectedOrder(order)} className='btn btn-info my-2'>Select Order</button>
                                )}
                            </div>
                        </div>
                    )}
                </div>
            ) : (
                <div>
                    <OrderInfo order={selectedOrder} setOrder={setOrder} />
                </div>
            )}
            <button className='btn btn-danger' onClick={() => { setOrder(null) }}>Cloce Orders</button>
        </div>
    )
}
