import React from 'react';
import { useState } from "react";
import { useNavigate } from 'react-router-dom';

function EditUser() {
  //const [users, setUsers] = useState('');
  const [password, setPassword] = useState('');
  const [isPending, setIsPending] = useState(false);
  const [username, setUsername] = useState('');
  const navigate = useNavigate();

  const handleSubmit = (e) => {
    e.preventDefault();

    setIsPending(true);
    
    fetch(`https://localhost:5001/User/${username}/updateUname`, {
              method: 'PUT',
              headers: { "Content-Type": "application/json"}
          }).then((response) => {
            console.log(username);
            return response.json();
          }).then(data => {
            //setUsers(data);
            navigate('/home');
            setIsPending(false);
          });
  }

  return (
    <div>
      <h1>Edit User</h1>
      <form onSubmit={handleSubmit}>
        <div className="input-container">
            <label>Username: </label>
            <input 
                value={username}
                type="text" 
                required 
                placeholder="text"
                onChange={(e) => setUsername(e.target.value)}
            />
        </div>
        <div className="input-container">
            <label>Password: </label>
            <input 
                type="text" 
                required 
                placeholder="text"
                value={password} 
                onChange={(e) => setPassword(e.target.value)}
            />
        </div>
        <div className="button-container">
            { !isPending && <button>Submit</button>}
            { isPending && <button disabled>Submitting ..... </button>}
        </div>
      </form>
    </div>
  )
}

export default EditUser