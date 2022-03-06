public class DeathPushEnabler : ExplosionForceUser
{
    private RagdollToggler _ragdollToggler;

    private void Awake()
    {
        _ragdollToggler = GetComponent<RagdollToggler>();
    }

    public void Activate()
    {
        _ragdollToggler.DoActionWithRigigbodies(rigidbody => AddExplositionForce(rigidbody));
    }

    private void OnEnable()
    {
        _ragdollToggler.Enabled += Activate;
    }

    private void OnDestroy()
    {
        _ragdollToggler.Enabled -= Activate;
    }
}