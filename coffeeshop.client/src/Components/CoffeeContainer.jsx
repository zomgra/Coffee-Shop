import React from 'react'

export default function CoffeeContainer({ coffees, onCoffeeChoose }) {

  return (
    <div className='row d-inline-flex' >
      <h1>Coffees {coffees.length}</h1>
      {coffees.map(coffee =>
        <div className='card mx-2 col-4 my-2' key={coffee.id}>
          <img className="card-img-top py-2" src={coffee.imageUrl} alt="alt"></img> 
          <div className='card-body'>
            <h4 className='card-title'>{coffee.name}</h4>
            <p className='card-subtitle'>{coffee.cost}</p>
          </div>
          <div className='card-footer'>
            
            <a onClick={()=> onCoffeeChoose(coffee)} href="#" className='btn btn-info'>Create Order</a>
            
          </div>
        </div>
      )}
    </div>
  );
}
