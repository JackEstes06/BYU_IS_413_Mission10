import { useEffect, useState } from 'react';
import { bowler } from './Bowler';
import 'bootstrap/dist/css/bootstrap.min.css';

function BowlerList() {
  const [bowlers, setBowlers] = useState<bowler[]>([]);

  useEffect(() => {
    const fetchBowler = async () => {
      const response = await fetch('https://localhost:5000/api/Bowler');
      const data = await response.json();
      setBowlers(data);
    };

    fetchBowler();
  }, []);
  return (
    <>
      <div className="container mt-4">
        <div className="table-responsive">
          <table className="table table-striped table-bordered">
            <thead className="thead-dark">
              <tr>
                <th>First Name</th>
                <th>Middle Initial</th>
                <th>Last Name</th>
                <th>Team Name</th>
                <th>Address</th>
                <th>City</th>
                <th>State</th>
                <th>ZIP</th>
                <th>Phone Number</th>
              </tr>
            </thead>
            <tbody>
              {bowlers.map((b) => (
                <tr key={b.bowlerID}>
                  <td>{b.bowlerFirstName}</td>
                  <td>{b.bowlerMiddleInit || '-'}</td>
                  <td>{b.bowlerLastName}</td>
                  <td>{b.team.teamName}</td>
                  <td>{b.bowlerAddress}</td>
                  <td>{b.bowlerCity}</td>
                  <td>{b.bowlerState}</td>
                  <td>{b.bowlerZip}</td>
                  <td>{b.bowlerPhoneNumber}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </>
  );
}

export default BowlerList;
