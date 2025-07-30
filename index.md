```mermaid

erDiagram
    users ||--o{ teams : "owner (1:N)"
    users ||--o{ team_members : "member (1:N)"
    roles ||--o{ users : "role (1:N)"
    teams ||--o{ team_members : "team (1:N)"
    team_members ||--|| players : "player (1:1)"
    players }|--|| positions : "position (N:1)"

    users {
        int id PK
        varchar first_name
        varchar last_name
        varchar email
        varchar phone_number
        varchar password
        date birthdate
        varchar address
        varchar state
        varchar role_id FK
        varchar profile_photo
        varchar gender
        boolean status
        datetime created_at
        datetime updated_at
    }

    roles {
        varchar id PK
        varchar name
        varchar description
        boolean status
        datetime created_at
        datetime updated_at
    }

    teams {
        int id PK
        varchar name
        varchar city
        varchar logo
        varchar description
        int owner_id FK
        boolean status
        datetime created_at
        datetime updated_at
    }

    team_members {
        int id PK
        int team_id FK
        int user_id FK
        date entry_date
        boolean status
        datetime created_at
        datetime updated_at
    }

    players {
        int id PK
        varchar number
        int team_member_id FK "Unique"
        int position_id FK
        boolean status
        datetime created_at
        datetime updated_at
    }

    positions {
        int id PK
        varchar name
        varchar abbreviation
        varchar description
        boolean status
        datetime created_at
        datetime updated_at
    }
