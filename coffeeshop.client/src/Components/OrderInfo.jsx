import React from 'react'
import { CANCEL_ORDER_URL, PAY_ORDER_URL } from '../utils/Constants'
import { userManager } from '../utils/authService';

export default function OrderInfo({ order, setOrder }) {

  async function manageRequest(route) {
    let user = await userManager.getUser();
    let token = user.access_token;

    let request = JSON.stringify({
      "id": order.id
    })

    console.log(request);
    console.log(route);

    await fetch(route, {
      method: "PUT",
      body: request,
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token}`
      }
    }).then(() => {
      setOrder(null);
    });
  }
  return (
    <div>
      <div key={order.id} className="card col-sm-6 my-3 mx-4">
        <img className="card-img-top py-2 img-thumbnail rounded" src={order.coffee.imageUrl} alt="alt"></img>
        <div className='card-body'>
          <h4 className='card-title'>{order.coffee.name}</h4>
          <p className='card-subtitle'>${order.costOrder}</p>
        </div>
        <div className='card-footer'>
          {order.ingredients.map(ing =>
            <div key={ing.id}>
              <p>{ing.name}</p>
            </div>)}
          <div className='my-4'>

            <button onClick={() => { manageRequest(PAY_ORDER_URL) }} className='btn btn-success my-2 mx-2'>Pay Order</button>
            <button onClick={() => { manageRequest(CANCEL_ORDER_URL) }} className='btn btn-danger mx-2'>Cancel Order</button>
          </div>
        </div>
      </div>
    </div>
  )
}
