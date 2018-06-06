# Contents
* [Ldap](#ldap)

# LDAP
## Scope
* Create an user GitLabSRV with password Password1
* Create an OU Gitlab

* Working config /etc/gitlab/gitlab.rb 

```
gitlab_rails['ldap_enabled'] = true
gitlab_rails['ldap_servers'] = {
'main' => {
  'label' => 'GitLab AD',
  'host' =>  'dc.contoso.com',
  'port' => 389,
  'uid' => 'sAMAccountName',
  'encryption' => 'plain',
  'verify_certificates' => true,
  'bind_dn' => 'CN=GitLabSRV,CN=Users,DC=contoso,DC=com',
  'password' => 'Password1',
  'active_directory' => true,
  'base' => 'OU=GitLab,DC=contoso,DC=com',
  'group_base' => 'OU=Global Groups,OU=GitLab,DC=contoso,DC=com',
  'admin_group' => 'Global Admins'
  }
}

```

```
gitlab-ctl reconfigure
```


## Tools
### Linux 
Centos 

```
install openldap-clients
```

```
 ldapsearch -D "CN=GitLabSRV,CN=Users,DC=contoso,DC=com" -w Password1 -p 389 -h dc.contoso.com -b "OU=GitLab,DC=contoso,DC=com" -Z -s sub "(objectclass=*)"
```

### Windows
To add attribute and test and more
ldp.exe



