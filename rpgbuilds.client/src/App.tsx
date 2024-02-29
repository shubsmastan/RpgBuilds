import { useEffect, useState } from 'react';
import './App.css';

interface Build {
  id: string;
  name: string;
  characterName: string;
  characterClass: string;
}

function App() {
  const [builds, setBuilds] = useState<Build[]>();

  async function populateBuildData() {
    const response = await fetch('https://localhost:7122/api/build');
    try {
      const data = await response.json();
      setBuilds(data);
    } catch (err) {
      console.log(response);
    }
  }

  useEffect(() => {
    populateBuildData();
  }, []);

  const contents =
    builds === undefined ? (
      <p>
        <em>
          Loading... Please refresh once the ASP.NET backend has started. See{' '}
          <a href="https://aka.ms/jspsintegrationreact">
            https://aka.ms/jspsintegrationreact
          </a>{' '}
          for more details.
        </em>
      </p>
    ) : (
      <table className="table table-striped" aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Build Name</th>
            <th>Character Name</th>
            <th>Class</th>
          </tr>
        </thead>
        <tbody>
          {builds.map((build) => (
            <tr key={build.id}>
              <td>{build.name}</td>
              <td>{build.characterName}</td>
              <td>{build.characterClass}</td>
            </tr>
          ))}
        </tbody>
      </table>
    );

  return (
    <div>
      <h1 id="tabelLabel">Your Builds</h1>
      <p>This component demonstrates fetching data from the server.</p>
      {contents}
    </div>
  );
}

export default App;
