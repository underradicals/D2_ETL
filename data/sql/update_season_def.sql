drop table if exists season_definition;

create table if not exists season_definition
(
    id            integer not null,
    name          text    not null,
    description   text    not null,
    icon          text    not null,
    season_number integer not null,
    start_date    text    not null,
    end_date      text    not null,
    constraint season_definition_pk primary key (id)
);


select *
from season_definition
order by season_number;

update season_definition
set name       = 'The Red War',
    start_date = '2017-09-06T17:00:00Z',
    end_date   = '2017-12-05T17:00:00Z'
where id = 965757574;


-- Curse of Osiris
update season_definition
set start_date = '2017-12-05T17:00:00Z',
    end_date   = '2018-05-08T17:00:00Z'
where id = 2973407602;

-- Warmind
update season_definition
set name       = 'Resurgence (Warmind)',
    start_date = '2018-05-08T17:00:00Z',
    end_date   = '2018-09-04T17:00:00Z'
where id = 4033618594;


-- Season of the Outlaw
update season_definition
set start_date = '2018-09-04T17:00:00Z',
    end_date   = '2018-12-04T17:00:00Z'
where id = 2026773320;


-- Season of the Forge
update season_definition
set start_date = '2018-12-04T17:00:00Z',
    end_date   = '2019-03-05T17:00:00Z'
where id = 2236269318;


-- Season of the Drifter
update season_definition
set start_date = '2019-03-05T17:00:00Z',
    end_date   = '2019-06-04T17:00:00Z'
where id = 2891088360;


-- Season of Opulence
update season_definition
set start_date = '2019-06-04T17:00:00Z',
    end_date   = '2019-09-30T17:00:00Z'
where id = 4275747712;