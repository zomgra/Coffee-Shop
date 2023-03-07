import { useEffect, useState } from 'react'
import CoffeeContainer from '../Components/CoffeeContainer';
import IngredientsContainer from '../Components/IngredientsContainer';
import { userManager } from '../utils/authService';
import { CREATE_ORDER_URL } from '../utils/Constants';
import Orders from './Orders';

export default function Home({ user }) {

    const [coffees, setCoffees] = useState([]);
    const [currentCoffee, setCurrentCoffee] = useState(null);
    const [currentOrder, setCurrentOrder] = useState(null);
    const [selectedViewOrders, setSelectedViewOrder] = useState(false);

    function onCoffeeChoose(coffee) {
        console.log(coffee);
        if (coffee === null) setCurrentCoffee(null);
        setCurrentCoffee(coffee);
    }
    function getCoffees() {
        try {
            fetch('https://localhost:7001/api/coffee')
                .then(response => response.json())
                .then(json => {
                    setCoffees(json)
                })

        } catch (e) {
            console.error(e);
        }
    }
    async function createOrder(order) {

        if (order === null) {
            await setCurrentOrder(null);
            await setSelectedViewOrder(false);
            await setCurrentCoffee(null);
            return;
        }

        let user = await userManager.getUser();
        let token = `Bearer ${user.access_token}`;
        console.log(order);
        await fetch(`${CREATE_ORDER_URL}`, {
            method: "POST",
            body: JSON.stringify(order),
            headers: {
                'Content-Type': 'application/json',
                'Authorization': token,
            }
        }).then(responce => responce.json())
            .then(json => {
                console.log(json);
                setCurrentOrder(json)
            }).finally(()=>{
                setCurrentCoffee(null);
            });
    }

    useEffect(() => {
        getCoffees();
    }, [])


    return (
        <div>
            <button onClick={() => { setSelectedViewOrder(true); console.log(selectedViewOrders); }}>View Orders</button>
            {currentCoffee === null ?
                (
                    (currentOrder === null && selectedViewOrders === false) ?
                        <CoffeeContainer coffees={coffees} onCoffeeChoose={onCoffeeChoose} />
                        :
                        (

                            <Orders order={currentOrder} setOrder={createOrder} />
                        )
                )
                :
                <IngredientsContainer createOrder={createOrder} coffee={currentCoffee} coffeeId={currentCoffee.id} />
            }
        </div>
    )
}
