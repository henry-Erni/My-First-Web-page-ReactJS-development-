import { useReducer } from "react";

function reducer(state, action) {
  console.log(state, action);
  // if (action.type == "add") return state + action.payload;
  // if (action.type == "subtract") return state - action.payload;

  if (action.type == "add") 
    return {...state, count: state.count + 1, step : state.step + 10}

}

// import { useState } from "react";

const TestComponent = () => {

  const initialState = {
    count : 0, 
    step : 5
  }
  
  const [state, dispatch] = useReducer(reducer, initialState);
  const {count,step} = state;




  function handleIncrement() {
    dispatch({type: "add", payload: 2});
    // setCount( count + 1);
  }

  function handleDecrement() {
    dispatch({type: "subtract", payload: 2});
    // setCount( count + 1);
  }

  return (
    <div>
      <p>Count: {count}</p>
      <p>Step: {step}</p>
      <button onClick={() => handleIncrement()}>Increment</button>
      <button onClick={() => handleDecrement()}>Decrement</button>
    </div>
  );
};

export default TestComponent;  